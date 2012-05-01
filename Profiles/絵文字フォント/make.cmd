@echo off
echo ファイルをコピーしています…
XCOPY /E /H /Y .\Profiles\絵文字フォント\system .\work\system
echo fallback_fonts.xmlを書き換えています…
.\tools\sed -f .\Profiles\絵文字フォント\fix_fallback_fonts.xml.sed .\work\system\etc\fallback_fonts.xml > .\work\system\etc\fallback_fonts.xml_fixed
.\tools\tr -d '\r' < .\work\system\etc\fallback_fonts.xml_fixed > .\work\system\etc\fallback_fonts.xml
echo build.propを書き換えています…
.\tools\sed -f .\Profiles\絵文字フォント\fix_build.prop.sed .\work\system\build.prop > .\work\system\build.prop_fixed
.\tools\tr -d '\r' < .\work\system\build.prop_fixed > .\work\system\build.prop
del .\work\system\etc\fallback_fonts.xml_fixed
del .\work\system\build.prop_fixed
echo 完了しました。