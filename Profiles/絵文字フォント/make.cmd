@echo off
echo ファイルをコピーしています…
.\tools\xcopy /E /H /Y .\Profiles\絵文字フォント\system .\work\system
echo fallback_fonts.xmlを書き換えています…
.\tools\sed -f .\Profiles\絵文字フォント\fix_fallback_fonts.xml.sed .\work\system\etc\fallback_fonts.xml > fallback_fonts.xml_fixed
.\tools\tr -d '\r' < .\work\system\etc\fallback_fonts.xml_fixed > .\work\system\etc\fallback_fonts.xml
echo build.propを書き換えています…
.\tools\sed -f .\Profiles\絵文字フォント\fix_build.prop.sed .\work\system\build.prop > system\build.prop_fixed
.\tools\tr -d '\r' < .\work\system\build.prop_fixed > .\work\system\build.prop
echo 完了しました。