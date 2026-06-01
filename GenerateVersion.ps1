param(
    [string]$ProjectDir = "."
)

$versionFile = Join-Path $ProjectDir "My Project\AutoVersion.vb"
$templateFile = Join-Path $ProjectDir "My Project\AutoVersion.vb.template"

if (-not (Test-Path $versionFile) -and (Test-Path $templateFile)) {
    Copy-Item $templateFile $versionFile
}

$dateStr = (Get-Date).ToString("yyyy.MM.dd")
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

$lines = @(
    "' 自动生成 - 编译前由 GenerateVersion.ps1 更新"
    "' 格式：YYYY.MM.DD.R (年.月.日.当天编译次数)"
    "<Assembly: System.Reflection.AssemblyVersion(""$version"")>"
    "<Assembly: System.Reflection.AssemblyFileVersion(""$version"")>"
)

$lines | Out-File -FilePath $versionFile -Encoding UTF8 -Force
Write-Host "Generated version: $version"
