using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Procon2017MCTProtocol {
    public static class Parameter {
        /// <summary>
        /// Diablo Ⅱと被るけど，プレイする人いないのでへーきへーき
        /// </summary>
        public static readonly Uri ProconPuzzUri = new Uri("http://localhost:4000/ProconPuzzle");
    }

    [ServiceContract]
    public interface IProconPuzzleService {
        [OperationContract]
        void Polygon(SendablePolygon poly);
        [OperationContract]
        void QRCode(string code_string);
    }

    [DataContract]
    public struct SendablePoint {
        [DataMember]
        public int X;
        [DataMember]
        public int Y;

        public SendablePoint(int X, int Y) {
            this.X = X;
            this.Y = Y;
        }

    }

    [DataContract]
    public class SendablePolygon {
        [DataMember]
        public List<SendablePoint> Points { get; set; }
    }
}
