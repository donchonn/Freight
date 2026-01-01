@echo off
chcp 65001 >nul
echo ========================================
echo   Freight 3.0 Build Script
echo ========================================
echo.

set MSBUILD="C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
set PROJECT_DIR=%~dp0

echo [1/2] Building Freight 3.0...
%MSBUILD% "%PROJECT_DIR%Freight3.0.csproj" -t:Rebuild -p:Configuration=Release -p:Platform=x86 -v:minimal
if errorlevel 1 (
    echo.
    echo [ERROR] Freight 3.0 build failed!
    pause
    exit /b 1
)
echo [OK] Freight 3.0 build complete.
echo.

echo [2/2] Building FreightInstaller (with embedded files)...
%MSBUILD% "%PROJECT_DIR%Installer\FreightInstaller.csproj" -t:Rebuild -p:Configuration=Release -p:Platform=AnyCPU -v:minimal
if errorlevel 1 (
    echo.
    echo [ERROR] FreightInstaller build failed!
    pause
    exit /b 1
)
echo [OK] FreightInstaller build complete.
echo.

echo ========================================
echo   Build Complete!
echo ========================================
echo.
echo Output: %PROJECT_DIR%Installer\bin\Release\FreightInstaller.exe
echo.
pause
