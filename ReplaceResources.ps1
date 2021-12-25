$CSPROJ = "osu/osu.Game/osu.Game.csproj"

dotnet remove $CSPROJ package ppy.osu.Game.Resources
dotnet add $CSPROJ reference "osu-resources/osu.Game.Resources/osu.Game.Resources.csproj"