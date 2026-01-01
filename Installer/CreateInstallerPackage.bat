@echo off
echo ==========================================
echo    Freight 3.0 Installer Package Creator
echo ==========================================
echo.

set SOURCE_DIR=..\bin\x86\Release
set INSTALLER_DIR=bin\Release
set OUTPUT_DIR=Package

echo Creating package directory...
if exist "%OUTPUT_DIR%" rmdir /s /q "%OUTPUT_DIR%"
mkdir "%OUTPUT_DIR%"

echo.
echo Copying installer...
copy "%INSTALLER_DIR%\FreightInstaller.exe" "%OUTPUT_DIR%\" > nul

echo Copying application files...
copy "%SOURCE_DIR%\Freight 3.0.exe" "%OUTPUT_DIR%\" > nul
copy "%SOURCE_DIR%\Freight 3.0.exe.config" "%OUTPUT_DIR%\" > nul
copy "%SOURCE_DIR%\Newtonsoft.Json.dll" "%OUTPUT_DIR%\" > nul
copy "%SOURCE_DIR%\config.json" "%OUTPUT_DIR%\" > nul

echo.
echo ==========================================
echo    Package created successfully!
echo ==========================================
echo.
echo Location: %CD%\%OUTPUT_DIR%
echo.
echo Contents:
dir /b "%OUTPUT_DIR%"
echo.
echo To install: Run FreightInstaller.exe as Administrator
echo To uninstall: Run FreightInstaller.exe /uninstall as Administrator
echo.
pause
