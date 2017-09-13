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
        void QRCode(QRCodeData codeData);
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

        public SendablePolygon(int count) {
            Points = new List<SendablePoint>(count);
        }

        public SendablePolygon() {
            Points = new List<SendablePoint>();
        }
    }

    [DataContract]
    public class QRCodeData {
        public bool IsHint { get; set; }

        [DataMember]
        public List<SendablePolygon> Polygons { get; set; }

        [DataMember]
        public List<SendablePolygon> Frames { get; set; }

        public QRCodeData(List<SendablePolygon> polies, List<SendablePolygon> frames) {
            Polygons = polies;
            Frames = frames;
        }
    }
}
