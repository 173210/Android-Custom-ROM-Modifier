xcopy
echo ファイルを確認しています…
IF NOT EXIST .\work\system\build.prop EXIT 1
echo ファイルをコピーしています…
XCOPY /E /H /Y .\Profiles\CM9,SC-02C最適化\system .\work\system
echo build.propを書き換えています…
.\tools\sed -f .\Profiles\CM9,SC-02C最適化\fix_build.prop.sed .\work\system\build.prop > .\work\system\build.prop_fixed
.\tools\tr -d '\r' < .\work\system\build.prop_fixed > .\work\system\build.prop
echo updater-scriptを書き換えています…
.\tools\sed -e "/galaxys2/d" .\work\META-INF\com\google\android\updater-script > .\work\META-INF\com\google\android\updater-script_fixed
.\tools\sed -e "/GT-I9100/d" .\work\META-INF\com\google\android\updater-script_fixed > .\work\META-INF\com\google\android\updater-script_fixed1
.\tools\tr -d '\r' < .\work\META-INF\com\google\android\updater-script_fixed1 > .\work\META-INF\com\google\android\updater-script
del .\work\META-INF\com\google\android\updater-script_fixed
del .\work\META-INF\com\google\android\updater-script_fixed1
echo 完了しました。
pause