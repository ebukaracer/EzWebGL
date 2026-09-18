# EzWebGL
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-blue)](http://makeapullrequest.com) [![License: MIT](https://img.shields.io/badge/License-MIT-blue)](https://ebukaracer.github.io/ebukaracer/md/LICENSE.html)

A simple yet sleek WebGL template for Unity web games.

![gif](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/A.gif)

## Installation
- Open the Unity Package Manager
- Click the (+) button.
- Select **Install package from git URL**.
- Enter the URL below and click **Install**:
   ```text
   https://github.com/ebukaracer/EzWebGL.git#upm
   ```

## Setup
### Importing the Template
After installation, 
- navigate to: `Racer > EzWebGL > Import Template (force)` 

To import or update the WebGL template.

## Usage Guide

#### Default settings:
To use this template with its default settings, select `EzWebGL` from the listed templates:
![img](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/B.png)

#### Custom settings:
- `Optimize for pixel art:` Handy if you're targeting pixel art style.
	- Value: `true` or `false`

- `Hide footer:` Whether or not to hide the buttons below the container/frame.
	- Value: `true` or `false`

- `Border colour:` Changes the border colour of the container/frame and footer(if not hidden). 
	- Value:  `transparent`, hex-colour codes e.g. `#FF0000`, `#0000FF`, etc., hardcoded colours e.g. `red`, `blue`, etc.

## Notes
- To change the default background colour, navigate to: `Player Settings > Splash Image > Background > Background Color`:\
  ![img](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/C.png)\
  Any colour you set there will be applied to this template; you can observe it during the initial load of your game.
  
- To change the default favicon, navigate to `EzWebGL/TemplateData` and replace the default `favicon.ico` with your own, bearing the same name and extension.

- In case you're hosting your Unity WebGL game on [itch.io](itch.io), Unity usually defaults to a resolution of `960 X 600`. This tends to clip off this template's contents due to the size of the container which itch website uses to render WebGL games.

	*Here's my hacky way of achieving a fitting dimension:*
	- Inside Unity, set the default Width and Height to `860 X 500`  as seen above.
	-  On the Itch website, while editing your game, set the Width and Height values to `960 X 600`: 
	   ![img](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/D.png)

- To remove this package completely, 
	- navigate to: `Racer > EzWebGL > Remove package`

## Credits
- WebGL Templates on [Unity docs](https://docs.unity3d.com/Manual/webgl-templates.html) 
- Inspired by [BetterMinimal](https://seansleblanc.itch.io/better-minimal-webgl-template)

## [Contributing](https://ebukaracer.github.io/ebukaracer/md/CONTRIBUTING.html) 
Contributions are welcome! Please open an issue or submit a pull request.
