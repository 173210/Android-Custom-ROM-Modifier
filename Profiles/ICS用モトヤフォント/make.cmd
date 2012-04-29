@echo off
echo フォントをコピーしています…
XCOPY /E /H /Y .\Profiles\ICS用モトヤフォント\system .\work\system
echo 完了しました。
IF NOT ERRORLEVEL 0 EXIT 1
EXIT