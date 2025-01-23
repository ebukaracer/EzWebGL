# EzWebGL
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-blue)](http://makeapullrequest.com) [![License: MIT](https://img.shields.io/badge/License-MIT-blue)](https://ebukaracer.github.io/ebukaracer/md/LICENSE.html)

Simple yet sleek WebGL template for Unity HTML games.

![gif](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/A.gif)

[Read Docs](https://ebukaracer.github.io/EzWebGL)

## Installation
- Hit `(+)`, choose `Add package from Git URL`(Unity 2019.4+)
- Paste the `URL` for this package inside the box: https://github.com/ebukaracer/EzWebGL.git#upm
- Hit `Add`

*Alternatively check out [this](https://ebukaracer.github.io/ebukaracer/md/INSTALLGUIDE.html)*

## Setup
After installation, navigate to `Racer > EzWebGL > Import Template` to import the WebGL template.

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
	- Value:  `transparent`, hex-colour codes e.g. `#FF0000`, `#0000FF`, etc, hardcoded colours e.g. `red`, `blue`, etc.

### Notes
- To change the default background colour navigate to: `Player Settings > Splash Image > Background > Background Color`. Any colour you set there would be applied to this template, you can observe it during the initial load of your game: 
   ![img](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/C.png)

- To change the default favicon, navigate to `EzWebGL/TemplateData` and replace the default `favicon.ico` with your own, bearing the same name and extension.

- In case you're hosting your Unity WebGL game on [itch.io](itch.io), Unity usually defaults to a resolution of `960 X 600`, this tends to clip off this template's contents caused by the size of the container which itch website uses to render WebGL games.

	*Here's my hacky way of achieving a fitting dimension:*
	- Inside Unity, set the default Width and Height to `860 X 500`  as seen above.
	-  On the Itch website, while editing your game, set the Width and Height values to `960 X 600`: 
	   ![img](https://raw.githubusercontent.com/ebukaracer/ebukaracer/unlisted/EzWebGL-Images/D.png)

- To remove this package completely(leaving no trace), navigate to: `Racer > EzWebGL > Remove package`

## Credits
- WebGL Templates on [Unity docs](https://docs.unity3d.com/Manual/webgl-templates.html) 
- Inspired by [BetterMinimal](https://seansleblanc.itch.io/better-minimal-webgl-template)

## [Contributing](https://ebukaracer.github.io/ebukaracer/md/CONTRIBUTING.html) 
Contributions are welcome! Please open an issue or submit a pull request.