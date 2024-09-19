namespace FSH.Starter.WebApi.English.Features.Update.v1;
public sealed record UpdateCardCommand(Dictionary<string, List<bool>> UnlockedCards);
