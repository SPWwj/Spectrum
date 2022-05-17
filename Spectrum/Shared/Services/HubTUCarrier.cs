
using Spectrum.Shared.Models;

namespace Spectrum.Shared.Services
{
    public class HubTUCarrier
    {
        public string? ConnectionId { get; set; }
        public string? ReceiverConId { get; set; }
        public Mission? Parcel { get; set; }
        public IEnumerable<Mission>? Missions { get; set; }
        public Person? Person { get; set; }
        public CarrierType Type { get; set; }

        public virtual HubTUCarrier? Receive(List<Mission> missions, Person receiver)
        {
            switch (Type)
            {
                case CarrierType.Add:
                missions.Add(Parcel!);
                break;

                case CarrierType.Remove:
                missions.Remove(Parcel!);
                break;

                case CarrierType.Update:
                missions.Find(x => x.Id == Parcel!.Id)!.Status = Parcel!.Status;
                break;
                case CarrierType.OpeningBoardcast:
                if (receiver.Role != PersonRole.Admin && !receiver!.Updated)
                {
                    return new HubTUCarrier()
                    {
                        ReceiverConId = this.ConnectionId,
                        Person = receiver,
                        Type = CarrierType.Request,
                        Missions = missions
                    };
                }
                break;

                case CarrierType.Request:
                if (receiver.Role == PersonRole.Admin)
                {
                    return new HubTUCarrier()
                    {
                        ReceiverConId = this.ConnectionId,
                        Person = receiver,
                        Type = CarrierType.SendAll,
                        Missions = missions
                    };
                }
                break;

                case CarrierType.SendAll:
                missions.AddRange(Missions!);
                receiver.Updated = true;
                break;

                default:
                throw new InvalidOperationException();

            }
            return null;
        }
    }

    public enum CarrierType
    {
        Add, Remove, Update, Request, SendAll, OpeningBoardcast, JoinRoom
    }
}
