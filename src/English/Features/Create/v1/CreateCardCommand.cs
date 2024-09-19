namespace FSH.Starter.WebApi.English.Features.Create.v1;
public sealed record CreateCardCommand(Dictionary<string, List<bool>> UnlockedCards);
