# 自动版本号生成脚本 — 在 Pre-build 事件中调用
# 格式：YYYY.MM.DD.R （年.月.日.当天编译次数）
# 用法：添加到 VS 预先生成事件：
#   powershell -ExecutionPolicy Bypass -File "$(ProjectDir)GenerateVersion.ps1" "$(ProjectDir)"

param(
    [string]$ProjectDir = "."
)

$versionFile = Join-Path $ProjectDir "My Project\AutoVersion.vb"
$templateFile = Join-Path $ProjectDir "My Project\AutoVersion.vb.template"

# 如果 AutoVersion.vb 不存在，从模板复制
if (-not (Test-Path $versionFile) -and (Test-Path $templateFile)) {
    Copy-Item $templateFile $versionFile
}

$dateStr = (Get-Date).ToString("yyyy.MM.dd")
$today = (Get-Date).Date

# 检查是否已存在当天版本，累加编译次数
$buildNum = 1
if (Test-Path $versionFile) {
    $content = Get-Content $versionFile -Raw
    $match = [regex]::Match($content, 'AssemblyVersion\("(\d+\.\d+\.\d+)\.(\d+)"\)')
    if ($match.Success) {
        $existingDate = $match.Groups[1].Value
        $existingBuild = [int]$match.Groups[2].Value
        if ($existingDate -eq $dateStr) {
            $buildNum = $existingBuild + 1
        }
    }
}

$version = "$dateStr.$buildNum"

$content = @"
' 自动生成 — 编译前由 GenerateVersion.ps1 更新
' 格式：YYYY.MM.DD.R （年.月.日.当天编译次数）
<Assembly: System.Reflection.AssemblyVersion("$version")>
<Assembly: System.Reflection.AssemblyFileVersion("$version")>
"@

Set-Content -Path $versionFile -Value $content -Encoding UTF8
Write-Host "Generated version: $version"
