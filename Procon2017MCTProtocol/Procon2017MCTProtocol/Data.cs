using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Procon2017MCTProtocol
{
    [ServiceContract]
    public interface IProconPuzzleService {
        [OperationContract]
        SendablePolygon Polygon();
        [OperationContract]
        string QRCode();
    }

    public struct SendablePoint {
        public int X;
        public int Y;

        public SendablePoint(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }

    }

    public class SendablePolygon {
        public List<SendablePoint> Points { get; set; }
    }
}
