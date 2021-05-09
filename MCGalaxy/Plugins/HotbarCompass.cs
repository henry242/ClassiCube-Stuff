//INSTALL INSTRUCTIONS
//Make level blocks 100-107 going clockwise from bottom. For instance: bottom, bottom-left, left, etc.
//Use +compass in the motd to use this.
using System;
using System.Threading;

using MCGalaxy;
using MCGalaxy.Tasks;
using MCGalaxy.Network;
using BlockID = System.UInt16;

namespace MCGalaxy {

    public class Compass : Plugin {
        public override string creator { get { return "henry242"; } }
        public override string MCGalaxy_Version { get { return "1.9.2.8"; } }
        public override string name { get { return "HotbarCompass"; } }
		SchedulerTask tak;
        public override void Load(bool startup) {
            Server.MainScheduler.QueueRepeat(CheckDirection, null, TimeSpan.FromMilliseconds(100));
        }
		public override void Unload(bool shutdown) {
			Server.MainScheduler.Cancel(tak);
		}

        void CheckDirection(SchedulerTask tak) {
            Player[] players = PlayerInfo.Online.Items;
            foreach (Player p in players) {
	        if (p.level.Config.MOTD.ToLower().Contains("+compass")) {
			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 339 && Orientation.PackedToDegrees(p.Rot.RotY) < 361 || Orientation.PackedToDegrees(p.Rot.RotY) >= 0 && Orientation.PackedToDegrees(p.Rot.RotY) < 33) {
			    p.Send(Packet.SetHotbar(100, 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 33 && Orientation.PackedToDegrees(p.Rot.RotY) < 68) {
			    p.Send(Packet.SetHotbar(101, 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 68 && Orientation.PackedToDegrees(p.Rot.RotY) < 113) {
			    p.Send(Packet.SetHotbar(102, 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 113 && Orientation.PackedToDegrees(p.Rot.RotY) < 158) {
			    p.Send(Packet.SetHotbar(103, 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 153 && Orientation.PackedToDegrees(p.Rot.RotY) < 203) {
			    p.Send(Packet.SetHotbar(104 , 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 203 && Orientation.PackedToDegrees(p.Rot.RotY) < 258) {
			    p.Send(Packet.SetHotbar(105, 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 258 && Orientation.PackedToDegrees(p.Rot.RotY) < 293) {
			    p.Send(Packet.SetHotbar(106, 8, true));
			}

			if (Orientation.PackedToDegrees(p.Rot.RotY) >= 293 && Orientation.PackedToDegrees(p.Rot.RotY) < 339) {
			    p.Send(Packet.SetHotbar(107, 8, true));
			}
		}
            }
        }

        
    }
}
