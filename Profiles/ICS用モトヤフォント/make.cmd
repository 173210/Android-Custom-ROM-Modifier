@echo off
echo �t�@�C�����R�s�[���Ă��܂��c
xcopy.exe /E /H /Y .\Profiles\ICS�p���g���t�H���g\system .\work\system
echo fallback_fonts.xml�����������Ă��܂��c
 .\tools\sed -f .\Profiles\ICS�p���g���t�H���g\fix_fallback_fonts.xml.sed .\work\system\etc\fallback_fonts.xml > .\work\system\etc\fallback_fonts.xml_fixed
 .\tools\tr -d '\r' < .\work\system\etc\fallback_fonts.xml_fixed > .\work\system\etc\fallback_fonts.xml
echo �������܂����B
IF NOT ERRORLEVEL 0 EXIT 1
EXIT