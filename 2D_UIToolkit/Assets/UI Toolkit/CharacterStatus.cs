using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Properties;

[UxmlElement]
public partial class CharacterStatus : VisualElement
{
    static CustomStyleProperty<Color> s_FillColor = new CustomStyleProperty<Color>("--fill-color");
    static CustomStyleProperty<Color> s_BackgroundColor = new CustomStyleProperty<Color>("--background-color");

    Color m_FillColor;
    Color m_BackgroundColor;

    [SerializeField, DontCreateProperty]
    float m_Progress;

    [UxmlAttribute, CreateProperty]
    public float progress
    {
        get => m_Progress;
        set
        {
            m_Progress = Mathf.Clamp(value, 0.01f, 1f);
            MarkDirtyRepaint();
        }
    }

    public CharacterStatus()
    {
        //Custom Style Resolution
        RegisterCallback<CustomStyleResolvedEvent>(CustomStylesResolved);

        //Generate Visual Content
        generateVisualContent = GenerateVisualContent;
    }

    private void CustomStylesResolved(CustomStyleResolvedEvent evt)
    {
        if(evt.currentTarget == this)
        {
            CharacterStatus element = (CharacterStatus)evt.currentTarget;
            element.UpdateCustomStyles();
        }
    }

    void UpdateCustomStyles()
    {
        bool repaint = false;
        if(customStyle.TryGetValue(s_FillColor, out m_FillColor))
            repaint = true;
        if(customStyle.TryGetValue(s_BackgroundColor, out m_BackgroundColor))
            repaint = true;
        if(repaint)
            MarkDirtyRepaint();
    }

    private void GenerateVisualContent(MeshGenerationContext context)
    {
        float width = contentRect.width;
        float height = contentRect.height;

        //Border
        var painter = context.painter2D;
        painter.BeginPath();
        painter.lineWidth = 10f;
        painter.Arc(new Vector2(width * 0.5f, height), width * 0.5f, 180f, 0f);
        painter.ClosePath();
        painter.fillColor = m_BackgroundColor;
        painter.Fill(FillRule.NonZero);
        painter.Stroke();

        //Fill
        painter.BeginPath();
        painter.LineTo(new Vector2(width * 0.5f, height));
        painter.lineWidth = 10f;
        painter.Arc(new Vector2(width * 0.5f, height), width * 0.5f, 180f, 0f - 180f * (1f-progress));
        painter.ClosePath();
        painter.fillColor = m_FillColor;
        painter.Fill(FillRule.NonZero);
        painter.Stroke();

        //Inner Fill
        painter.BeginPath();
        painter.lineWidth = 10f;
        painter.Arc(new Vector2(width * 0.5f, height), width * 0.35f, 180f, 0f);
        painter.ClosePath();
        painter.fillColor = Color.black;
        painter.Fill(FillRule.NonZero);
        painter.Stroke();
    }

    
}
