rem @echo off
subst w: /D
subst w: %cd%/..
set path="C:\Program Files\Sublime Text 3";%path%

rem W:

start subl W:\mtg_synfynd.sublime-project
start "" "C:\Progra~1\Unity\Editor\Unity.exe" -projectPath "W:\"

C:
cd "%LOCALAPPDATA%\SourceTree\app-2.3.1"
start "" "%LOCALAPPDATA%\SourceTree\Update.exe" --processStart SourceTree.exe

rem start "" "C:\Program Files (x86)\Atlassian\SourceTree\SourceTree.exe" C:\GameDev\mtg_synfynd
rem PAUSE