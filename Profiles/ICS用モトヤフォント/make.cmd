@echo off
echo ファイルをコピーしています…
xcopy.exe /E /H /Y .\Profiles\ICS用モトヤフォント\system .\work\system
echo fallback_fonts.xmlを書き換えています…
 .\tools\sed -f .\Profiles\ICS用モトヤフォント\fix_fallback_fonts.xml.sed .\work\system\etc\fallback_fonts.xml > .\work\system\etc\fallback_fonts.xml_fixed
 .\tools\tr -d '\r' < .\work\system\etc\fallback_fonts.xml_fixed > .\work\system\etc\fallback_fonts.xml
echo 完了しました。
IF NOT ERRORLEVEL 0 EXIT 1
EXIT