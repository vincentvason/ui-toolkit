# UI Toolkit Experimentation
This project is for studying Unity UI Toolkit which is inspired from [Game Dev Guide](https://www.youtube.com/watch?v=6DcwHPxCE54).

## What is UI Toolkit?
The UI Toolkit is a collection of features, resources, and tools for developing user interfaces (UI). You can use the UI Toolkit to develop custom UI and extensions for the Unity Editor, runtime debugging tools, and runtime UI for games and applications. 
The UI Toolkit is inspired by **standard web technologies**. If you have experience developing web pages or applications, your knowledge is transferable and the core concepts will be familiar.

![image](https://github.com/vincentvason/ui-toolkit/assets/15789782/f4e4b323-d103-4155-a333-973ebb9b49c0)

*Comparison between UI Toolkit and Standard Web Technologies.*

## Contents
I experimented with two sections: the Main Menu and the Health Bar. For both sections, I created them in the [UI Toolkit](https://github.com/vincentvason/ui-toolkit/tree/main/2D_UIToolkit/Assets/UI%20Toolkit) folder.

### Main Menu
- The Main Menu in this project is simply three buttons including play, options and quit. <code>UI:UXML</code> tag is similar to <code>body</code> in web development.
- <code>Style</code> tag is used to import USS which is similar to importing CSS.
- <code>ui:VisualElement</code> is similar to the Container class, which is used in various front-end frameworks such as [Bootstrap](https://getbootstrap.com/docs/5.3/layout/containers/).
- <code>style</code> attribute is similar to <code>style</code> in web development where you can add inline CSS (USS in Unity UI Toolkit).
- <code>LocalizedButton</code> is a custom tag derived from Button, made in C#. Please see Unity C# integration section and [source code](https://github.com/vincentvason/ui-toolkit/blob/main/2D_UIToolkit/Assets/UI%20Toolkit/LocalizedButton.cs).

#### UXML
 ```
<ui:UXML xmlns:ui="UnityEngine.UIElements" xmlns:uie="UnityEditor.UIElements" editor-extension-mode="False">
    <Style src="project://database/Assets/UI%20Toolkit/MainMenu.uss?fileID=7433441132597879392&amp;guid=2e3f73c29e07be4418f82a92697d9111&amp;type=3#MainMenu" />
    <ui:VisualElement name="Panel" class="panel">
        <ui:VisualElement name="Container" class="menu" style="align-items: stretch; justify-content: space-around; border-top-left-radius: 40px; border-top-right-radius: 40px; border-bottom-right-radius: 40px; border-bottom-left-radius: 40px;">
            <ui:VisualElement name="Logo" style="flex-grow: 1; background-image: url(&quot;project://database/Assets/Environment/Tiles/house.png?fileID=2800000&amp;guid=8021a483bbfee4494bb11f0cf1bb90bf&amp;type=3#house&quot;); -unity-background-scale-mode: scale-to-fit; height: 20%;" />
            <LocalizedButton text="Play" key="play_button" name="PlayButton" />
            <LocalizedButton name="OptionsButton" text="Options" key="options_button" />
            <LocalizedButton name="QuitButton" text="Quit" key="quit_button" />
        </ui:VisualElement>
    </ui:VisualElement>
</ui:UXML>
 ```
#### USS
*Selected only some interesting parts. USS file is almost identical to CSS file.*

```
.panel {
    background-color: rgba(53, 90, 121, 0.8);
    height: 100%;
    width: 100%;
    align-items: center;
    justify-content: center;
}

.hide {
    display: none;
}

.menu {
    align-items: auto;
    justify-content: space-between;
    width: 33%;
    height: 50%;
    background-color: rgb(0, 4, 89);
    min-width: 33%;
    min-height: 50%;
    max-width: 33%;
    max-height: 50%;
}

.unity-button {
    font-size: 72px;
    justify-content: flex-start;
    flex-grow: 1;
    flex-shrink: 0;
    -unity-font-style: bold;
    border-top-width: 15px;
    border-right-width: 15px;
    border-bottom-width: 15px;
    border-left-width: 15px;
    border-top-left-radius: 40px;
    border-top-right-radius: 40px;
    border-bottom-right-radius: 40px;
    border-bottom-left-radius: 40px;
    margin-top: 15px;
    margin-right: 15px;
    margin-bottom: 15px;
    margin-left: 15px;
}
```
  

#### Result
![image](https://github.com/vincentvason/ui-toolkit/assets/15789782/898ced8e-16d5-4df4-9648-6170bf4c20bd)

### Status Bar
- <code>CharacterStatus</code> is a custom tag, derived from VisualElement (as a half-circle progress bar). Please see Unity C# integration section and [source code](https://github.com/vincentvason/ui-toolkit/blob/main/2D_UIToolkit/Assets/UI%20Toolkit/CharacterStatus.cs).
- <code>CharacterStatus</code>'s class also determine the colour of the progress bar which is indicated in [<code>CharacterStatus</code>'s USS](https://github.com/vincentvason/ui-toolkit/blob/main/2D_UIToolkit/Assets/UI%20Toolkit/CharacterStatus.uss).
- Custom attributes and binding to a parameter using <code>engine</code> tag. An attribute named <code>progress</code> is created as a character's health.

#### UXML
```
<engine:UXML xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:engine="UnityEngine.UIElements" xmlns:editor="UnityEditor.UIElements" noNamespaceSchemaLocation="../../UIElementsSchema/UIElements.xsd" editor-extension-mode="False">
    <Style src="project://database/Assets/UI%20Toolkit/CharacterStatus.uss?fileID=7433441132597879392&amp;guid=726d097c79f0fb247900454d81cdedc2&amp;type=3#CharacterStatus" />
    <engine:VisualElement style="flex-grow: 1; justify-content: flex-end; align-items: flex-start;">
        <CharacterStatus progress="1.03" name="CharacterStatus" class="green" style="height: 15%; width: 15%; left: 5%;">
            <Bindings>
                <engine:DataBinding property="progress" binding-mode="ToTarget" data-source-type="Platformer.Mechanics.Health, Assembly-CSharp" data-source-path="gaugeHP" />
            </Bindings>
        </CharacterStatus>
    </engine:VisualElement>
</engine:UXML>
```
#### USS
*Selected only some interesting parts. USS file is almost identical to CSS file.*

```
#CharacterStatus {
    --background-color: rgb(66, 66, 66);
}

.green {
    --fill-color: rgb(102, 187, 106);
}
```
#### Result
![image](https://github.com/vincentvason/ui-toolkit/assets/15789782/62eb0714-afaf-457b-8e63-72f68a57ac33)


## Unity C# Integration
- Custom Tag is created Unity C#. Using <code>UxmlElement</code>, and derived from any base tag. For example, <code>LocalizedButton</code> is derived from <code>Button</code> tag. This button is attached to the Unity Localization module, which can change text depending on the language setting.

### C#
```
...
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UIElements;

[UxmlElement]
public partial class LocalizedButton : Button
{
    public static BindingId keyProperty = nameof(key);

    [UxmlAttribute]
    public string key;

    public LocalizedButton()
    {
        this.schedule.Execute(() =>
        {
            if(!string.IsNullOrEmpty(key))
            {
                string loc = LocalizationSettings.StringDatabase.GetLocalizedString(key);

                if(!string.IsNullOrEmpty(loc))
                {
                    text = loc;
                    return;
                }

                text = key;
            }
        });
    }
}
```
![image](https://github.com/vincentvason/ui-toolkit/assets/15789782/33cbf12b-d749-415b-a695-383270dad6cc)

- Another example is, <code>CharacterStatus</code> which is derived from <code>VisualElement</code> tag. It can access <code>GenerateVisualContent</code>'s function that can draw content (similar to Canvas) in HTML.

*You can see full [source code](https://github.com/vincentvason/ui-toolkit/blob/main/2D_UIToolkit/Assets/UI%20Toolkit/CharacterStatus.cs) for more info.
```
[UxmlElement]
public partial class CharacterStatus : VisualElement
{
    static CustomStyleProperty<Color> s_FillColor = new CustomStyleProperty<Color>("--fill-color");
    static CustomStyleProperty<Color> s_BackgroundColor = new CustomStyleProperty<Color>("--background-color");
...
}
```

```
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
```







