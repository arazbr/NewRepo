Get-ChildItem -Recurse -Filter *.csproj | ForEach-Object {
    [xml]$x = Get-Content $_.FullName
    foreach($pg in $x.Project.PropertyGroup){
        # چارچوب
        if ($pg.TargetFrameworkVersion) {
            $pg.TargetFrameworkVersion = 'v4.8'
        } else {
            $t=$x.CreateElement('TargetFrameworkVersion'); $t.InnerText='v4.8'
            $pg.AppendChild($t) | Out-Null
        }
        # معماری
        if ($pg.PlatformTarget) { $pg.PlatformTarget = 'x64' }
        else {
            $p=$x.CreateElement('PlatformTarget'); $p.InnerText='x64'
            $pg.AppendChild($p) | Out-Null
        }
        # جلوگیری از اجرای ۳۲ بیتی
        if ($pg.Prefer32Bit) { $pg.Prefer32Bit='false' }
        else {
            $p2=$x.CreateElement('Prefer32Bit'); $p2.InnerText='false'
            $pg.AppendChild($p2) | Out-Null
        }
    }
    $x.Save($_.FullName)
}
