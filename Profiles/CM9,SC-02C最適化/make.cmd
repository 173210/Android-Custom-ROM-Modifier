xcopy
echo �t�@�C�����m�F���Ă��܂��c
IF NOT EXIST .\work\system\build.prop EXIT 1
echo �t�@�C�����R�s�[���Ă��܂��c
XCOPY /E /H /Y .\Profiles\CM9,SC-02C�œK��\system .\work\system
echo build.prop�����������Ă��܂��c
.\tools\sed -f .\Profiles\CM9,SC-02C�œK��\fix_build.prop.sed .\work\system\build.prop > .\work\system\build.prop_fixed
.\tools\tr -d '\r' < .\work\system\build.prop_fixed > .\work\system\build.prop
echo updater-script�����������Ă��܂��c
.\tools\sed -e "/galaxys2/d" .\work\META-INF\com\google\android\updater-script > .\work\META-INF\com\google\android\updater-script_fixed
.\tools\sed -e "/GT-I9100/d" .\work\META-INF\com\google\android\updater-script_fixed > .\work\META-INF\com\google\android\updater-script_fixed1
.\tools\tr -d '\r' < .\work\META-INF\com\google\android\updater-script_fixed1 > .\work\META-INF\com\google\android\updater-script
del .\work\META-INF\com\google\android\updater-script_fixed
del .\work\META-INF\com\google\android\updater-script_fixed1
echo �������܂����B
pause