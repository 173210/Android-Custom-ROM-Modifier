@echo off
echo �t�@�C�����R�s�[���Ă��܂��c
XCOPY /E /H /Y .\Profiles\�G�����t�H���g\system .\work\system
echo fallback_fonts.xml�����������Ă��܂��c
.\tools\sed -f .\Profiles\�G�����t�H���g\fix_fallback_fonts.xml.sed .\work\system\etc\fallback_fonts.xml > .\work\system\etc\fallback_fonts.xml_fixed
.\tools\tr -d '\r' < .\work\system\etc\fallback_fonts.xml_fixed > .\work\system\etc\fallback_fonts.xml
echo build.prop�����������Ă��܂��c
.\tools\sed -f .\Profiles\�G�����t�H���g\fix_build.prop.sed .\work\system\build.prop > .\work\system\build.prop_fixed
.\tools\tr -d '\r' < .\work\system\build.prop_fixed > .\work\system\build.prop
del .\work\system\etc\fallback_fonts.xml_fixed
del .\work\system\build.prop_fixed
echo �������܂����B