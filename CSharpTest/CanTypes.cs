using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDB;

namespace testNS
{

    public static class CanMessageReceiver
    {
    
        public static void CanMessageReceivedCallback(object sender, STLinkBridgeWrapper.CanMessageReceivedEventArgs e)
        {
            foreach(var canMessage in e.ReceivedMessages)
            {
                if (canMessage.ID == CanMessageTypes.GpsState.ID)
                {
                    GpsStateMessage message = new GpsStateMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.GpsPosition.ID)
                {
                    GpsPositionMessage message = new GpsPositionMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.FrontGyro.ID)
                {
                    FrontGyroMessage message = new FrontGyroMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.FrontAccelerometer.ID)
                {
                    FrontAccelerometerMessage message = new FrontAccelerometerMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.FrontSensors.ID)
                {
                    FrontSensorsMessage message = new FrontSensorsMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.FrontNodeTemperatures.ID)
                {
                    FrontNodeTemperaturesMessage message = new FrontNodeTemperaturesMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.DriveControls.ID)
                {
                    DriveControlsMessage message = new DriveControlsMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RearSensors.ID)
                {
                    RearSensorsMessage message = new RearSensorsMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RearNodeTemperatures.ID)
                {
                    RearNodeTemperaturesMessage message = new RearNodeTemperaturesMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.FrontNodeState.ID)
                {
                    FrontNodeStateMessage message = new FrontNodeStateMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RearNodeStatus.ID)
                {
                    RearNodeStatusMessage message = new RearNodeStatusMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.AccumulatorStackErrors.ID)
                {
                    AccumulatorStackErrorsMessage message = new AccumulatorStackErrorsMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_Wh.ID)
                {
                    IVT_Msg_Result_WhMessage message = new IVT_Msg_Result_WhMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_W.ID)
                {
                    IVT_Msg_Result_WMessage message = new IVT_Msg_Result_WMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.AmsClientStatus.ID)
                {
                    AmsClientStatusMessage message = new AmsClientStatusMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PrechargeProgress.ID)
                {
                    PrechargeProgressMessage message = new PrechargeProgressMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.AmsStatus.ID)
                {
                    AmsStatusMessage message = new AmsStatusMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.AccumulatorMinMaxTemperatures.ID)
                {
                    AccumulatorMinMaxTemperaturesMessage message = new AccumulatorMinMaxTemperaturesMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.AccumulatorMinMaxVoltages.ID)
                {
                    AccumulatorMinMaxVoltagesMessage message = new AccumulatorMinMaxVoltagesMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.Ams_Cell_Voltages.ID)
                {
                    Ams_Cell_VoltagesMessage message = new Ams_Cell_VoltagesMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.AmsCellTemperatures.ID)
                {
                    AmsCellTemperaturesMessage message = new AmsCellTemperaturesMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_U3.ID)
                {
                    IVT_Msg_Result_U3Message message = new IVT_Msg_Result_U3Message();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_U2.ID)
                {
                    IVT_Msg_Result_U2Message message = new IVT_Msg_Result_U2Message();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_U1.ID)
                {
                    IVT_Msg_Result_U1Message message = new IVT_Msg_Result_U1Message();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_T.ID)
                {
                    IVT_Msg_Result_TMessage message = new IVT_Msg_Result_TMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_I.ID)
                {
                    IVT_Msg_Result_IMessage message = new IVT_Msg_Result_IMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.IVT_Msg_Result_As.ID)
                {
                    IVT_Msg_Result_AsMessage message = new IVT_Msg_Result_AsMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PowerElectronicsErrors.ID)
                {
                    PowerElectronicsErrorsMessage message = new PowerElectronicsErrorsMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FR_PDO_3_TX.ID)
                {
                    PE_FR_PDO_3_TXMessage message = new PE_FR_PDO_3_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FR_PDO_2_TX.ID)
                {
                    PE_FR_PDO_2_TXMessage message = new PE_FR_PDO_2_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FR_PDO_1_TX.ID)
                {
                    PE_FR_PDO_1_TXMessage message = new PE_FR_PDO_1_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FL_PDO_3_TX.ID)
                {
                    PE_FL_PDO_3_TXMessage message = new PE_FL_PDO_3_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FL_PDO_2_TX.ID)
                {
                    PE_FL_PDO_2_TXMessage message = new PE_FL_PDO_2_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FL_PDO_1_TX.ID)
                {
                    PE_FL_PDO_1_TXMessage message = new PE_FL_PDO_1_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RR_PDO_3_TX.ID)
                {
                    PE_RR_PDO_3_TXMessage message = new PE_RR_PDO_3_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RR_PDO_2_TX.ID)
                {
                    PE_RR_PDO_2_TXMessage message = new PE_RR_PDO_2_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RR_PDO_1_TX.ID)
                {
                    PE_RR_PDO_1_TXMessage message = new PE_RR_PDO_1_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_FR_PDO_3_RX.ID)
                {
                    RN_PE_FR_PDO_3_RXMessage message = new RN_PE_FR_PDO_3_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_FR_PDO_2_RX.ID)
                {
                    RN_PE_FR_PDO_2_RXMessage message = new RN_PE_FR_PDO_2_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_FR_PDO_1_RX.ID)
                {
                    RN_PE_FR_PDO_1_RXMessage message = new RN_PE_FR_PDO_1_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_FL_PDO_3_RX.ID)
                {
                    RN_PE_FL_PDO_3_RXMessage message = new RN_PE_FL_PDO_3_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_FL_PDO_2_RX.ID)
                {
                    RN_PE_FL_PDO_2_RXMessage message = new RN_PE_FL_PDO_2_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_FL_PDO_1_RX.ID)
                {
                    RN_PE_FL_PDO_1_RXMessage message = new RN_PE_FL_PDO_1_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_RR_PDO_3_RX.ID)
                {
                    RN_PE_RR_PDO_3_RXMessage message = new RN_PE_RR_PDO_3_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_RR_PDO_2_RX.ID)
                {
                    RN_PE_RR_PDO_2_RXMessage message = new RN_PE_RR_PDO_2_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_RR_PDO_1_RX.ID)
                {
                    RN_PE_RR_PDO_1_RXMessage message = new RN_PE_RR_PDO_1_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RL_PDO_3_TX.ID)
                {
                    PE_RL_PDO_3_TXMessage message = new PE_RL_PDO_3_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RL_PDO_2_TX.ID)
                {
                    PE_RL_PDO_2_TXMessage message = new PE_RL_PDO_2_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RL_PDO_1_TX.ID)
                {
                    PE_RL_PDO_1_TXMessage message = new PE_RL_PDO_1_TXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_RL_PDO_3_RX.ID)
                {
                    RN_PE_RL_PDO_3_RXMessage message = new RN_PE_RL_PDO_3_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_RL_PDO_2_RX.ID)
                {
                    RN_PE_RL_PDO_2_RXMessage message = new RN_PE_RL_PDO_2_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.RN_PE_RL_PDO_1_RX.ID)
                {
                    RN_PE_RL_PDO_1_RXMessage message = new RN_PE_RL_PDO_1_RXMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RR_NMT.ID)
                {
                    PE_RR_NMTMessage message = new PE_RR_NMTMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_RL_NMT.ID)
                {
                    PE_RL_NMTMessage message = new PE_RL_NMTMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FR_NMT.ID)
                {
                    PE_FR_NMTMessage message = new PE_FR_NMTMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PE_FL_NMT.ID)
                {
                    PE_FL_NMTMessage message = new PE_FL_NMTMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
                else 
                if (canMessage.ID == CanMessageTypes.PrechargeRequest.ID)
                {
                    PrechargeRequestMessage message = new PrechargeRequestMessage();
                    message.Data = canMessage.data;
                    message.SystemTimeStamp = DateTime.Now.Ticks;
                    message.NotifySubscribers();
                }
            }
        }
        
        
        
    }

    public static class CanMessageTypes
    {
    
        
        static CanMessageTypes()
        {
            AllCanMessageTypes.Add(GpsState);
            AllCanMessageTypes.Add(GpsPosition);
            AllCanMessageTypes.Add(FrontGyro);
            AllCanMessageTypes.Add(FrontAccelerometer);
            AllCanMessageTypes.Add(FrontSensors);
            AllCanMessageTypes.Add(FrontNodeTemperatures);
            AllCanMessageTypes.Add(DriveControls);
            AllCanMessageTypes.Add(RearSensors);
            AllCanMessageTypes.Add(RearNodeTemperatures);
            AllCanMessageTypes.Add(FrontNodeState);
            AllCanMessageTypes.Add(RearNodeStatus);
            AllCanMessageTypes.Add(AccumulatorStackErrors);
            AllCanMessageTypes.Add(IVT_Msg_Result_Wh);
            AllCanMessageTypes.Add(IVT_Msg_Result_W);
            AllCanMessageTypes.Add(AmsClientStatus);
            AllCanMessageTypes.Add(PrechargeProgress);
            AllCanMessageTypes.Add(AmsStatus);
            AllCanMessageTypes.Add(AccumulatorMinMaxTemperatures);
            AllCanMessageTypes.Add(AccumulatorMinMaxVoltages);
            AllCanMessageTypes.Add(Ams_Cell_Voltages);
            AllCanMessageTypes.Add(AmsCellTemperatures);
            AllCanMessageTypes.Add(IVT_Msg_Result_U3);
            AllCanMessageTypes.Add(IVT_Msg_Result_U2);
            AllCanMessageTypes.Add(IVT_Msg_Result_U1);
            AllCanMessageTypes.Add(IVT_Msg_Result_T);
            AllCanMessageTypes.Add(IVT_Msg_Result_I);
            AllCanMessageTypes.Add(IVT_Msg_Result_As);
            AllCanMessageTypes.Add(PowerElectronicsErrors);
            AllCanMessageTypes.Add(PE_FR_PDO_3_TX);
            AllCanMessageTypes.Add(PE_FR_PDO_2_TX);
            AllCanMessageTypes.Add(PE_FR_PDO_1_TX);
            AllCanMessageTypes.Add(PE_FL_PDO_3_TX);
            AllCanMessageTypes.Add(PE_FL_PDO_2_TX);
            AllCanMessageTypes.Add(PE_FL_PDO_1_TX);
            AllCanMessageTypes.Add(PE_RR_PDO_3_TX);
            AllCanMessageTypes.Add(PE_RR_PDO_2_TX);
            AllCanMessageTypes.Add(PE_RR_PDO_1_TX);
            AllCanMessageTypes.Add(RN_PE_FR_PDO_3_RX);
            AllCanMessageTypes.Add(RN_PE_FR_PDO_2_RX);
            AllCanMessageTypes.Add(RN_PE_FR_PDO_1_RX);
            AllCanMessageTypes.Add(RN_PE_FL_PDO_3_RX);
            AllCanMessageTypes.Add(RN_PE_FL_PDO_2_RX);
            AllCanMessageTypes.Add(RN_PE_FL_PDO_1_RX);
            AllCanMessageTypes.Add(RN_PE_RR_PDO_3_RX);
            AllCanMessageTypes.Add(RN_PE_RR_PDO_2_RX);
            AllCanMessageTypes.Add(RN_PE_RR_PDO_1_RX);
            AllCanMessageTypes.Add(PE_RL_PDO_3_TX);
            AllCanMessageTypes.Add(PE_RL_PDO_2_TX);
            AllCanMessageTypes.Add(PE_RL_PDO_1_TX);
            AllCanMessageTypes.Add(RN_PE_RL_PDO_3_RX);
            AllCanMessageTypes.Add(RN_PE_RL_PDO_2_RX);
            AllCanMessageTypes.Add(RN_PE_RL_PDO_1_RX);
            AllCanMessageTypes.Add(PE_RR_NMT);
            AllCanMessageTypes.Add(PE_RL_NMT);
            AllCanMessageTypes.Add(PE_FR_NMT);
            AllCanMessageTypes.Add(PE_FL_NMT);
            AllCanMessageTypes.Add(PrechargeRequest);
        }
        
        static List<CanMessageType> AllCanMessageTypes = new List<CanMessageType>();
        
        public static CanMessageType GpsState = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.GpsState__gps_ok,
            })
        {
            Comment       = "",
            DLC           =   1,
            ID            =   1,
            Name          = "GpsState",
            QualifiedName = "GpsState",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType GpsPosition = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.GpsPosition__latitude,
                CanSignalTypes.GpsPosition__longitude,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   197,
            Name          = "GpsPosition",
            QualifiedName = "GpsPosition",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType FrontGyro = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FrontGyro__gyro_z,
                CanSignalTypes.FrontGyro__gyro_y,
                CanSignalTypes.FrontGyro__gyro_x,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   199,
            Name          = "FrontGyro",
            QualifiedName = "FrontGyro",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType FrontAccelerometer = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FrontAccelerometer__acc_z,
                CanSignalTypes.FrontAccelerometer__acc_y,
                CanSignalTypes.FrontAccelerometer__acc_x,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   198,
            Name          = "FrontAccelerometer",
            QualifiedName = "FrontAccelerometer",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType FrontSensors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FrontSensors__rotor_temp_fl,
                CanSignalTypes.FrontSensors__rotor_temp_FR,
                CanSignalTypes.FrontSensors__damper_fr,
                CanSignalTypes.FrontSensors__damper_fl,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   195,
            Name          = "FrontSensors",
            QualifiedName = "FrontSensors",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType FrontNodeTemperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FrontNodeTemperatures__water_temp_fr,
                CanSignalTypes.FrontNodeTemperatures__water_temp_fl,
                CanSignalTypes.FrontNodeTemperatures__gearbox_temp_fr,
                CanSignalTypes.FrontNodeTemperatures__gearbox_temp_fl,
                CanSignalTypes.FrontNodeTemperatures__brake_temp_fr,
                CanSignalTypes.FrontNodeTemperatures__brake_temp_fl,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   194,
            Name          = "FrontNodeTemperatures",
            QualifiedName = "FrontNodeTemperatures",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType DriveControls = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.DriveControls__apps,
                CanSignalTypes.DriveControls__steering_angle,
                CanSignalTypes.DriveControls__FN_Brake_System,
                CanSignalTypes.DriveControls__FN_Brake_Pedal,
                CanSignalTypes.DriveControls__apps_2_voltage,
                CanSignalTypes.DriveControls__apps_1_voltage,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   193,
            Name          = "DriveControls",
            QualifiedName = "DriveControls",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType RearSensors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RearSensors__rotor_temp_rr,
                CanSignalTypes.RearSensors__rotor_temp_rl,
                CanSignalTypes.RearSensors__damper_rr,
                CanSignalTypes.RearSensors__damper_rl,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   178,
            Name          = "RearSensors",
            QualifiedName = "RearSensors",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RearNodeTemperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_RR,
                CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_RL,
                CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_Radiator,
                CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_PE,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   177,
            Name          = "RearNodeTemperatures",
            QualifiedName = "RearNodeTemperatures",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType FrontNodeState = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FrontNodeState__fn_front_torque_scale,
                CanSignalTypes.FrontNodeState__fn_speed_limit,
                CanSignalTypes.FrontNodeState__fn_max_torque,
                CanSignalTypes.FrontNodeState__fn_status,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   207,
            Name          = "FrontNodeState",
            QualifiedName = "FrontNodeState",
            SendingNode   = "FrontNode",
        };
        
        public static CanMessageType RearNodeStatus = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RearNodeStatus__rn_status,
            })
        {
            Comment       = "",
            DLC           =   4,
            ID            =   191,
            Name          = "RearNodeStatus",
            QualifiedName = "RearNodeStatus",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType AccumulatorStackErrors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AccumulatorStackErrors__stack6_errors,
                CanSignalTypes.AccumulatorStackErrors__stack5_errors,
                CanSignalTypes.AccumulatorStackErrors__stack4_errors,
                CanSignalTypes.AccumulatorStackErrors__stack3_errors,
                CanSignalTypes.AccumulatorStackErrors__stack2_errors,
                CanSignalTypes.AccumulatorStackErrors__stack1_errors,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   161,
            Name          = "AccumulatorStackErrors",
            QualifiedName = "AccumulatorStackErrors",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType IVT_Msg_Result_Wh = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_Wh__IVT_ResultState_And_MsgCount_Wh,
                CanSignalTypes.IVT_Msg_Result_Wh__IVT_Result_Wh,
                CanSignalTypes.IVT_Msg_Result_Wh__IVT_MuxID_Wh,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1320,
            Name          = "IVT_Msg_Result_Wh",
            QualifiedName = "IVT_Msg_Result_Wh",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType IVT_Msg_Result_W = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_W__IVT_ResultState_And_MsgCount_W,
                CanSignalTypes.IVT_Msg_Result_W__IVT_Result_W,
                CanSignalTypes.IVT_Msg_Result_W__IVT_MuxID_W,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1318,
            Name          = "IVT_Msg_Result_W",
            QualifiedName = "IVT_Msg_Result_W",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType AmsClientStatus = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AmsClientStatus__AmsClient_Trigger_Ams,
                CanSignalTypes.AmsClientStatus__AmsClient_Start_TS,
                CanSignalTypes.AmsClientStatus__AmsClient_FN_Buttons,
                CanSignalTypes.AmsClientStatus__AmsClient_FrontNode_Status,
                CanSignalTypes.AmsClientStatus__AmsClient_Enable_Communication,
            })
        {
            Comment       = "",
            DLC           =   5,
            ID            =   241,
            Name          = "AmsClientStatus",
            QualifiedName = "AmsClientStatus",
            SendingNode   = "AmsClient",
        };
        
        public static CanMessageType PrechargeProgress = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PrechargeProgress__progress,
                CanSignalTypes.PrechargeProgress__fail_air1_open,
                CanSignalTypes.PrechargeProgress__fail_timeout,
                CanSignalTypes.PrechargeProgress__succeeded,
            })
        {
            Comment       = "",
            DLC           =   2,
            ID            =   168,
            Name          = "PrechargeProgress",
            QualifiedName = "PrechargeProgress",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType AmsStatus = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AmsStatus__Ams_Watchdog,
                CanSignalTypes.AmsStatus__Ams_Precharge_Time,
                CanSignalTypes.AmsStatus__Ams_Accumulator_Errors,
                CanSignalTypes.AmsStatus__Ams_Accumulator_SoC,
                CanSignalTypes.AmsStatus__ams_status,
            })
        {
            Comment       = "",
            DLC           =   5,
            ID            =   175,
            Name          = "AmsStatus",
            QualifiedName = "AmsStatus",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType AccumulatorMinMaxTemperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_AvgTemp,
                CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MinTemp,
                CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MinTemp_Pos_Stack,
                CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MaxTemp,
                CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MaxTemp_Pos_Stack,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   167,
            Name          = "AccumulatorMinMaxTemperatures",
            QualifiedName = "AccumulatorMinMaxTemperatures",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType AccumulatorMinMaxVoltages = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AccumulatorMinMaxVoltages__Ams_AvgVoltage,
                CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MinVoltage,
                CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MinVoltage_Pos_Stack,
                CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MaxVoltage,
                CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MaxVoltage_Pos_Stack,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   166,
            Name          = "AccumulatorMinMaxVoltages",
            QualifiedName = "AccumulatorMinMaxVoltages",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType Ams_Cell_Voltages = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.Ams_Cell_Voltages__Ams_Voltage3,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   163,
            Name          = "Ams_Cell_Voltages",
            QualifiedName = "Ams_Cell_Voltages",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType AmsCellTemperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AmsCellTemperatures__Ams_Temp3,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   162,
            Name          = "AmsCellTemperatures",
            QualifiedName = "AmsCellTemperatures",
            SendingNode   = "Ams",
        };
        
        public static CanMessageType IVT_Msg_Result_U3 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_U3__IVT_ResultState_And_MsgCount_U3,
                CanSignalTypes.IVT_Msg_Result_U3__IVT_Result_U3,
                CanSignalTypes.IVT_Msg_Result_U3__IVT_MuxID_U3,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1316,
            Name          = "IVT_Msg_Result_U3",
            QualifiedName = "IVT_Msg_Result_U3",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType IVT_Msg_Result_U2 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_U2__IVT_ResultState_And_MsgCount_U2,
                CanSignalTypes.IVT_Msg_Result_U2__IVT_Result_U2,
                CanSignalTypes.IVT_Msg_Result_U2__IVT_MuxID_U2,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1315,
            Name          = "IVT_Msg_Result_U2",
            QualifiedName = "IVT_Msg_Result_U2",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType IVT_Msg_Result_U1 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_U1__IVT_ResultState_And_MsgCount_U1,
                CanSignalTypes.IVT_Msg_Result_U1__IVT_Result_U1,
                CanSignalTypes.IVT_Msg_Result_U1__IVT_MuxID_U1,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1314,
            Name          = "IVT_Msg_Result_U1",
            QualifiedName = "IVT_Msg_Result_U1",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType IVT_Msg_Result_T = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_T__IVT_ResultState_And_MsgCount_T,
                CanSignalTypes.IVT_Msg_Result_T__IVT_Result_T,
                CanSignalTypes.IVT_Msg_Result_T__IVT_MuxID_T,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1317,
            Name          = "IVT_Msg_Result_T",
            QualifiedName = "IVT_Msg_Result_T",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType IVT_Msg_Result_I = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_I__IVT_ResultState_And_MsgCount_I,
                CanSignalTypes.IVT_Msg_Result_I__IVT_Result_I,
                CanSignalTypes.IVT_Msg_Result_I__IVT_MuxID_I,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1313,
            Name          = "IVT_Msg_Result_I",
            QualifiedName = "IVT_Msg_Result_I",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType IVT_Msg_Result_As = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.IVT_Msg_Result_As__IVT_ResultState_And_MsgCount_As,
                CanSignalTypes.IVT_Msg_Result_As__IVT_Result_As,
                CanSignalTypes.IVT_Msg_Result_As__IVT_MuxID_As,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   1319,
            Name          = "IVT_Msg_Result_As",
            QualifiedName = "IVT_Msg_Result_As",
            SendingNode   = "IVT",
        };
        
        public static CanMessageType PowerElectronicsErrors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PowerElectronicsErrors__pe_rr_errors,
                CanSignalTypes.PowerElectronicsErrors__pe_rl_errors,
                CanSignalTypes.PowerElectronicsErrors__pe_fr_errors,
                CanSignalTypes.PowerElectronicsErrors__pe_fl_errors,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   179,
            Name          = "PowerElectronicsErrors",
            QualifiedName = "PowerElectronicsErrors",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType PE_FR_PDO_3_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Iq,
                CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Id,
                CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Uq,
                CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Ud,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   909,
            Name          = "PE_FR_PDO_3_TX",
            QualifiedName = "PE_FR_PDO_3_TX",
            SendingNode   = "PE_FR",
        };
        
        public static CanMessageType PE_FR_PDO_2_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Temp_Stator,
                CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Measured_Udc,
                CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Temp_Inverter,
                CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Power_Estimate,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   653,
            Name          = "PE_FR_PDO_2_TX",
            QualifiedName = "PE_FR_PDO_2_TX",
            SendingNode   = "PE_FR",
        };
        
        public static CanMessageType PE_FR_PDO_1_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Errors,
                CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Speed_Estimate,
                CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Torque_Estimate,
                CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Drive_Engaged,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   397,
            Name          = "PE_FR_PDO_1_TX",
            QualifiedName = "PE_FR_PDO_1_TX",
            SendingNode   = "PE_FR",
        };
        
        public static CanMessageType PE_FL_PDO_3_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Iq,
                CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Id,
                CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Uq,
                CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Ud,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   902,
            Name          = "PE_FL_PDO_3_TX",
            QualifiedName = "PE_FL_PDO_3_TX",
            SendingNode   = "PE_FL",
        };
        
        public static CanMessageType PE_FL_PDO_2_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Temp_Stator,
                CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Measured_Udc,
                CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Temp_Inverter,
                CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Power_Estimate,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   646,
            Name          = "PE_FL_PDO_2_TX",
            QualifiedName = "PE_FL_PDO_2_TX",
            SendingNode   = "PE_FL",
        };
        
        public static CanMessageType PE_FL_PDO_1_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Errors,
                CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Speed_Estimate,
                CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Torque_Estimate,
                CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Drive_Engaged,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   390,
            Name          = "PE_FL_PDO_1_TX",
            QualifiedName = "PE_FL_PDO_1_TX",
            SendingNode   = "PE_FL",
        };
        
        public static CanMessageType PE_RR_PDO_3_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Iq,
                CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Id,
                CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Uq,
                CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Ud,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   905,
            Name          = "PE_RR_PDO_3_TX",
            QualifiedName = "PE_RR_PDO_3_TX",
            SendingNode   = "PE_RR",
        };
        
        public static CanMessageType PE_RR_PDO_2_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Temp_Stator,
                CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Measured_Udc,
                CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Temp_Inverter,
                CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Power_Estimate,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   649,
            Name          = "PE_RR_PDO_2_TX",
            QualifiedName = "PE_RR_PDO_2_TX",
            SendingNode   = "PE_RR",
        };
        
        public static CanMessageType PE_RR_PDO_1_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Errors,
                CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Speed_Estimate,
                CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Torque_Estimate,
                CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Drive_Engaged,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   393,
            Name          = "PE_RR_PDO_1_TX",
            QualifiedName = "PE_RR_PDO_1_TX",
            SendingNode   = "PE_RR",
        };
        
        public static CanMessageType RN_PE_FR_PDO_3_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Max_Power,
                CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Speed_Limit,
                CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Torque_Set_Point,
                CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   1037,
            Name          = "RN_PE_FR_PDO_3_RX",
            QualifiedName = "RN_PE_FR_PDO_3_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_FR_PDO_2_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Max_Power,
                CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Speed_Limit,
                CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Torque_Set_Point,
                CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   781,
            Name          = "RN_PE_FR_PDO_2_RX",
            QualifiedName = "RN_PE_FR_PDO_2_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_FR_PDO_1_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Error_Reset,
                CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Speed_Limit,
                CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Torque_Set_Point,
                CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   525,
            Name          = "RN_PE_FR_PDO_1_RX",
            QualifiedName = "RN_PE_FR_PDO_1_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_FL_PDO_3_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Max_Power,
                CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Speed_Limit,
                CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Torque_Set_Point,
                CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   1030,
            Name          = "RN_PE_FL_PDO_3_RX",
            QualifiedName = "RN_PE_FL_PDO_3_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_FL_PDO_2_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Max_Power,
                CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Speed_Limit,
                CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Torque_Set_Point,
                CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   774,
            Name          = "RN_PE_FL_PDO_2_RX",
            QualifiedName = "RN_PE_FL_PDO_2_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_FL_PDO_1_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Error_Reset,
                CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Speed_Limit,
                CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Torque_Set_Point,
                CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   518,
            Name          = "RN_PE_FL_PDO_1_RX",
            QualifiedName = "RN_PE_FL_PDO_1_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_RR_PDO_3_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Max_Power,
                CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Speed_Limit,
                CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Torque_Set_Point,
                CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   1033,
            Name          = "RN_PE_RR_PDO_3_RX",
            QualifiedName = "RN_PE_RR_PDO_3_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_RR_PDO_2_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Max_Power,
                CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Speed_Limit,
                CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Torque_Set_Point,
                CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   777,
            Name          = "RN_PE_RR_PDO_2_RX",
            QualifiedName = "RN_PE_RR_PDO_2_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_RR_PDO_1_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Error_Reset,
                CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Speed_Limit,
                CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Torque_Set_Point,
                CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   521,
            Name          = "RN_PE_RR_PDO_1_RX",
            QualifiedName = "RN_PE_RR_PDO_1_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType PE_RL_PDO_3_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Iq,
                CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Id,
                CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Uq,
                CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Ud,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   903,
            Name          = "PE_RL_PDO_3_TX",
            QualifiedName = "PE_RL_PDO_3_TX",
            SendingNode   = "PE_RL",
        };
        
        public static CanMessageType PE_RL_PDO_2_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Temp_Stator,
                CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Measured_Udc,
                CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Temp_Inverter,
                CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Power_Estimate,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   647,
            Name          = "PE_RL_PDO_2_TX",
            QualifiedName = "PE_RL_PDO_2_TX",
            SendingNode   = "PE_RL",
        };
        
        public static CanMessageType PE_RL_PDO_1_TX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Errors,
                CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Speed_Estimate,
                CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Torque_Estimate,
                CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Drive_Engaged,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   391,
            Name          = "PE_RL_PDO_1_TX",
            QualifiedName = "PE_RL_PDO_1_TX",
            SendingNode   = "PE_RL",
        };
        
        public static CanMessageType RN_PE_RL_PDO_3_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Max_Power,
                CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Speed_Limit,
                CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Torque_Set_Point,
                CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   1031,
            Name          = "RN_PE_RL_PDO_3_RX",
            QualifiedName = "RN_PE_RL_PDO_3_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_RL_PDO_2_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Max_Power,
                CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Speed_Limit,
                CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Torque_Set_Point,
                CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   775,
            Name          = "RN_PE_RL_PDO_2_RX",
            QualifiedName = "RN_PE_RL_PDO_2_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType RN_PE_RL_PDO_1_RX = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Error_Reset,
                CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Speed_Limit,
                CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Torque_Set_Point,
                CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Enable_Drive,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   519,
            Name          = "RN_PE_RL_PDO_1_RX",
            QualifiedName = "RN_PE_RL_PDO_1_RX",
            SendingNode   = "RearNode",
        };
        
        public static CanMessageType PE_RR_NMT = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RR_NMT__pe_rr_nmt,
            })
        {
            Comment       = "",
            DLC           =   1,
            ID            =   1801,
            Name          = "PE_RR_NMT",
            QualifiedName = "PE_RR_NMT",
            SendingNode   = "PE_RR",
        };
        
        public static CanMessageType PE_RL_NMT = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RL_NMT__pe_rl_nmt,
            })
        {
            Comment       = "",
            DLC           =   1,
            ID            =   1799,
            Name          = "PE_RL_NMT",
            QualifiedName = "PE_RL_NMT",
            SendingNode   = "PE_RL",
        };
        
        public static CanMessageType PE_FR_NMT = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FR_NMT__pe_fr_nmt,
            })
        {
            Comment       = "",
            DLC           =   1,
            ID            =   1805,
            Name          = "PE_FR_NMT",
            QualifiedName = "PE_FR_NMT",
            SendingNode   = "PE_FR",
        };
        
        public static CanMessageType PE_FL_NMT = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_FL_NMT__pe_fl_nmt,
            })
        {
            Comment       = "",
            DLC           =   1,
            ID            =   1798,
            Name          = "PE_FL_NMT",
            QualifiedName = "PE_FL_NMT",
            SendingNode   = "PE_FL",
        };
        
        public static CanMessageType PrechargeRequest = new CanMessageType(new List<CanSignalType>{
            })
        {
            Comment       = "",
            DLC           =   0,
            ID            =   300,
            Name          = "PrechargeRequest",
            QualifiedName = "PrechargeRequest",
            SendingNode   = "FrontNode",
        };
        
    }

    public static class CanSignalTypes
    {
    
        static List<CanSignalType> AllCanSignalTypes = new List<CanSignalType>();
        
        static CanSignalTypes()
        {
            AllCanSignalTypes.Add(GpsState__gps_ok); 
            AllCanSignalTypes.Add(GpsPosition__latitude); 
            AllCanSignalTypes.Add(GpsPosition__longitude); 
            AllCanSignalTypes.Add(FrontGyro__gyro_z); 
            AllCanSignalTypes.Add(FrontGyro__gyro_y); 
            AllCanSignalTypes.Add(FrontGyro__gyro_x); 
            AllCanSignalTypes.Add(FrontAccelerometer__acc_z); 
            AllCanSignalTypes.Add(FrontAccelerometer__acc_y); 
            AllCanSignalTypes.Add(FrontAccelerometer__acc_x); 
            AllCanSignalTypes.Add(FrontSensors__rotor_temp_fl); 
            AllCanSignalTypes.Add(FrontSensors__rotor_temp_FR); 
            AllCanSignalTypes.Add(FrontSensors__damper_fr); 
            AllCanSignalTypes.Add(FrontSensors__damper_fl); 
            AllCanSignalTypes.Add(FrontNodeTemperatures__water_temp_fr); 
            AllCanSignalTypes.Add(FrontNodeTemperatures__water_temp_fl); 
            AllCanSignalTypes.Add(FrontNodeTemperatures__gearbox_temp_fr); 
            AllCanSignalTypes.Add(FrontNodeTemperatures__gearbox_temp_fl); 
            AllCanSignalTypes.Add(FrontNodeTemperatures__brake_temp_fr); 
            AllCanSignalTypes.Add(FrontNodeTemperatures__brake_temp_fl); 
            AllCanSignalTypes.Add(DriveControls__apps); 
            AllCanSignalTypes.Add(DriveControls__steering_angle); 
            AllCanSignalTypes.Add(DriveControls__FN_Brake_System); 
            AllCanSignalTypes.Add(DriveControls__FN_Brake_Pedal); 
            AllCanSignalTypes.Add(DriveControls__apps_2_voltage); 
            AllCanSignalTypes.Add(DriveControls__apps_1_voltage); 
            AllCanSignalTypes.Add(RearSensors__rotor_temp_rr); 
            AllCanSignalTypes.Add(RearSensors__rotor_temp_rl); 
            AllCanSignalTypes.Add(RearSensors__damper_rr); 
            AllCanSignalTypes.Add(RearSensors__damper_rl); 
            AllCanSignalTypes.Add(RearNodeTemperatures__RN_Water_Motor_RR); 
            AllCanSignalTypes.Add(RearNodeTemperatures__RN_Water_Motor_RL); 
            AllCanSignalTypes.Add(RearNodeTemperatures__RN_Water_Motor_Radiator); 
            AllCanSignalTypes.Add(RearNodeTemperatures__RN_Water_Motor_PE); 
            AllCanSignalTypes.Add(FrontNodeState__fn_front_torque_scale); 
            AllCanSignalTypes.Add(FrontNodeState__fn_speed_limit); 
            AllCanSignalTypes.Add(FrontNodeState__fn_max_torque); 
            AllCanSignalTypes.Add(FrontNodeState__fn_status); 
            AllCanSignalTypes.Add(RearNodeStatus__rn_status); 
            AllCanSignalTypes.Add(AccumulatorStackErrors__stack6_errors); 
            AllCanSignalTypes.Add(AccumulatorStackErrors__stack5_errors); 
            AllCanSignalTypes.Add(AccumulatorStackErrors__stack4_errors); 
            AllCanSignalTypes.Add(AccumulatorStackErrors__stack3_errors); 
            AllCanSignalTypes.Add(AccumulatorStackErrors__stack2_errors); 
            AllCanSignalTypes.Add(AccumulatorStackErrors__stack1_errors); 
            AllCanSignalTypes.Add(IVT_Msg_Result_Wh__IVT_ResultState_And_MsgCount_Wh); 
            AllCanSignalTypes.Add(IVT_Msg_Result_Wh__IVT_Result_Wh); 
            AllCanSignalTypes.Add(IVT_Msg_Result_Wh__IVT_MuxID_Wh); 
            AllCanSignalTypes.Add(IVT_Msg_Result_W__IVT_ResultState_And_MsgCount_W); 
            AllCanSignalTypes.Add(IVT_Msg_Result_W__IVT_Result_W); 
            AllCanSignalTypes.Add(IVT_Msg_Result_W__IVT_MuxID_W); 
            AllCanSignalTypes.Add(AmsClientStatus__AmsClient_Trigger_Ams); 
            AllCanSignalTypes.Add(AmsClientStatus__AmsClient_Start_TS); 
            AllCanSignalTypes.Add(AmsClientStatus__AmsClient_FN_Buttons); 
            AllCanSignalTypes.Add(AmsClientStatus__AmsClient_FrontNode_Status); 
            AllCanSignalTypes.Add(AmsClientStatus__AmsClient_Enable_Communication); 
            AllCanSignalTypes.Add(PrechargeProgress__progress); 
            AllCanSignalTypes.Add(PrechargeProgress__fail_air1_open); 
            AllCanSignalTypes.Add(PrechargeProgress__fail_timeout); 
            AllCanSignalTypes.Add(PrechargeProgress__succeeded); 
            AllCanSignalTypes.Add(AmsStatus__Ams_Watchdog); 
            AllCanSignalTypes.Add(AmsStatus__Ams_Precharge_Time); 
            AllCanSignalTypes.Add(AmsStatus__Ams_Accumulator_Errors); 
            AllCanSignalTypes.Add(AmsStatus__Ams_Accumulator_SoC); 
            AllCanSignalTypes.Add(AmsStatus__ams_status); 
            AllCanSignalTypes.Add(AccumulatorMinMaxTemperatures__Ams_AvgTemp); 
            AllCanSignalTypes.Add(AccumulatorMinMaxTemperatures__Ams_MinTemp); 
            AllCanSignalTypes.Add(AccumulatorMinMaxTemperatures__Ams_MinTemp_Pos_Stack); 
            AllCanSignalTypes.Add(AccumulatorMinMaxTemperatures__Ams_MaxTemp); 
            AllCanSignalTypes.Add(AccumulatorMinMaxTemperatures__Ams_MaxTemp_Pos_Stack); 
            AllCanSignalTypes.Add(AccumulatorMinMaxVoltages__Ams_AvgVoltage); 
            AllCanSignalTypes.Add(AccumulatorMinMaxVoltages__Ams_MinVoltage); 
            AllCanSignalTypes.Add(AccumulatorMinMaxVoltages__Ams_MinVoltage_Pos_Stack); 
            AllCanSignalTypes.Add(AccumulatorMinMaxVoltages__Ams_MaxVoltage); 
            AllCanSignalTypes.Add(AccumulatorMinMaxVoltages__Ams_MaxVoltage_Pos_Stack); 
            AllCanSignalTypes.Add(Ams_Cell_Voltages__Ams_Voltage3); 
            AllCanSignalTypes.Add(AmsCellTemperatures__Ams_Temp3); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U3__IVT_ResultState_And_MsgCount_U3); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U3__IVT_Result_U3); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U3__IVT_MuxID_U3); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U2__IVT_ResultState_And_MsgCount_U2); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U2__IVT_Result_U2); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U2__IVT_MuxID_U2); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U1__IVT_ResultState_And_MsgCount_U1); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U1__IVT_Result_U1); 
            AllCanSignalTypes.Add(IVT_Msg_Result_U1__IVT_MuxID_U1); 
            AllCanSignalTypes.Add(IVT_Msg_Result_T__IVT_ResultState_And_MsgCount_T); 
            AllCanSignalTypes.Add(IVT_Msg_Result_T__IVT_Result_T); 
            AllCanSignalTypes.Add(IVT_Msg_Result_T__IVT_MuxID_T); 
            AllCanSignalTypes.Add(IVT_Msg_Result_I__IVT_ResultState_And_MsgCount_I); 
            AllCanSignalTypes.Add(IVT_Msg_Result_I__IVT_Result_I); 
            AllCanSignalTypes.Add(IVT_Msg_Result_I__IVT_MuxID_I); 
            AllCanSignalTypes.Add(IVT_Msg_Result_As__IVT_ResultState_And_MsgCount_As); 
            AllCanSignalTypes.Add(IVT_Msg_Result_As__IVT_Result_As); 
            AllCanSignalTypes.Add(IVT_Msg_Result_As__IVT_MuxID_As); 
            AllCanSignalTypes.Add(PowerElectronicsErrors__pe_rr_errors); 
            AllCanSignalTypes.Add(PowerElectronicsErrors__pe_rl_errors); 
            AllCanSignalTypes.Add(PowerElectronicsErrors__pe_fr_errors); 
            AllCanSignalTypes.Add(PowerElectronicsErrors__pe_fl_errors); 
            AllCanSignalTypes.Add(PE_FR_PDO_3_TX__PE_FR_Iq); 
            AllCanSignalTypes.Add(PE_FR_PDO_3_TX__PE_FR_Id); 
            AllCanSignalTypes.Add(PE_FR_PDO_3_TX__PE_FR_Uq); 
            AllCanSignalTypes.Add(PE_FR_PDO_3_TX__PE_FR_Ud); 
            AllCanSignalTypes.Add(PE_FR_PDO_2_TX__PE_FR_Temp_Stator); 
            AllCanSignalTypes.Add(PE_FR_PDO_2_TX__PE_FR_Measured_Udc); 
            AllCanSignalTypes.Add(PE_FR_PDO_2_TX__PE_FR_Temp_Inverter); 
            AllCanSignalTypes.Add(PE_FR_PDO_2_TX__PE_FR_Power_Estimate); 
            AllCanSignalTypes.Add(PE_FR_PDO_1_TX__PE_FR_Errors); 
            AllCanSignalTypes.Add(PE_FR_PDO_1_TX__PE_FR_Speed_Estimate); 
            AllCanSignalTypes.Add(PE_FR_PDO_1_TX__PE_FR_Torque_Estimate); 
            AllCanSignalTypes.Add(PE_FR_PDO_1_TX__PE_FR_Drive_Engaged); 
            AllCanSignalTypes.Add(PE_FL_PDO_3_TX__PE_FL_Iq); 
            AllCanSignalTypes.Add(PE_FL_PDO_3_TX__PE_FL_Id); 
            AllCanSignalTypes.Add(PE_FL_PDO_3_TX__PE_FL_Uq); 
            AllCanSignalTypes.Add(PE_FL_PDO_3_TX__PE_FL_Ud); 
            AllCanSignalTypes.Add(PE_FL_PDO_2_TX__PE_FL_Temp_Stator); 
            AllCanSignalTypes.Add(PE_FL_PDO_2_TX__PE_FL_Measured_Udc); 
            AllCanSignalTypes.Add(PE_FL_PDO_2_TX__PE_FL_Temp_Inverter); 
            AllCanSignalTypes.Add(PE_FL_PDO_2_TX__PE_FL_Power_Estimate); 
            AllCanSignalTypes.Add(PE_FL_PDO_1_TX__PE_FL_Errors); 
            AllCanSignalTypes.Add(PE_FL_PDO_1_TX__PE_FL_Speed_Estimate); 
            AllCanSignalTypes.Add(PE_FL_PDO_1_TX__PE_FL_Torque_Estimate); 
            AllCanSignalTypes.Add(PE_FL_PDO_1_TX__PE_FL_Drive_Engaged); 
            AllCanSignalTypes.Add(PE_RR_PDO_3_TX__PE_RR_Iq); 
            AllCanSignalTypes.Add(PE_RR_PDO_3_TX__PE_RR_Id); 
            AllCanSignalTypes.Add(PE_RR_PDO_3_TX__PE_RR_Uq); 
            AllCanSignalTypes.Add(PE_RR_PDO_3_TX__PE_RR_Ud); 
            AllCanSignalTypes.Add(PE_RR_PDO_2_TX__PE_RR_Temp_Stator); 
            AllCanSignalTypes.Add(PE_RR_PDO_2_TX__PE_RR_Measured_Udc); 
            AllCanSignalTypes.Add(PE_RR_PDO_2_TX__PE_RR_Temp_Inverter); 
            AllCanSignalTypes.Add(PE_RR_PDO_2_TX__PE_RR_Power_Estimate); 
            AllCanSignalTypes.Add(PE_RR_PDO_1_TX__PE_RR_Errors); 
            AllCanSignalTypes.Add(PE_RR_PDO_1_TX__PE_RR_Speed_Estimate); 
            AllCanSignalTypes.Add(PE_RR_PDO_1_TX__PE_RR_Torque_Estimate); 
            AllCanSignalTypes.Add(PE_RR_PDO_1_TX__PE_RR_Drive_Engaged); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_3_RX__RN_PE_FR_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_3_RX__RN_PE_FR_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_3_RX__RN_PE_FR_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_3_RX__RN_PE_FR_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_2_RX__RN_PE_FR_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_2_RX__RN_PE_FR_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_2_RX__RN_PE_FR_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_2_RX__RN_PE_FR_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_1_RX__RN_PE_FR_Error_Reset); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_1_RX__RN_PE_FR_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_1_RX__RN_PE_FR_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_FR_PDO_1_RX__RN_PE_FR_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_3_RX__RN_PE_FL_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_3_RX__RN_PE_FL_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_3_RX__RN_PE_FL_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_3_RX__RN_PE_FL_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_2_RX__RN_PE_FL_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_2_RX__RN_PE_FL_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_2_RX__RN_PE_FL_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_2_RX__RN_PE_FL_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_1_RX__RN_PE_FL_Error_Reset); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_1_RX__RN_PE_FL_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_1_RX__RN_PE_FL_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_FL_PDO_1_RX__RN_PE_FL_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_3_RX__RN_PE_RR_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_3_RX__RN_PE_RR_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_3_RX__RN_PE_RR_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_3_RX__RN_PE_RR_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_2_RX__RN_PE_RR_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_2_RX__RN_PE_RR_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_2_RX__RN_PE_RR_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_2_RX__RN_PE_RR_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_1_RX__RN_PE_RR_Error_Reset); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_1_RX__RN_PE_RR_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_1_RX__RN_PE_RR_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_RR_PDO_1_RX__RN_PE_RR_Enable_Drive); 
            AllCanSignalTypes.Add(PE_RL_PDO_3_TX__PE_RL_Iq); 
            AllCanSignalTypes.Add(PE_RL_PDO_3_TX__PE_RL_Id); 
            AllCanSignalTypes.Add(PE_RL_PDO_3_TX__PE_RL_Uq); 
            AllCanSignalTypes.Add(PE_RL_PDO_3_TX__PE_RL_Ud); 
            AllCanSignalTypes.Add(PE_RL_PDO_2_TX__PE_RL_Temp_Stator); 
            AllCanSignalTypes.Add(PE_RL_PDO_2_TX__PE_RL_Measured_Udc); 
            AllCanSignalTypes.Add(PE_RL_PDO_2_TX__PE_RL_Temp_Inverter); 
            AllCanSignalTypes.Add(PE_RL_PDO_2_TX__PE_RL_Power_Estimate); 
            AllCanSignalTypes.Add(PE_RL_PDO_1_TX__PE_RL_Errors); 
            AllCanSignalTypes.Add(PE_RL_PDO_1_TX__PE_RL_Speed_Estimate); 
            AllCanSignalTypes.Add(PE_RL_PDO_1_TX__PE_RL_Torque_Estimate); 
            AllCanSignalTypes.Add(PE_RL_PDO_1_TX__PE_RL_Drive_Engaged); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_3_RX__RN_PE_RL_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_3_RX__RN_PE_RL_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_3_RX__RN_PE_RL_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_3_RX__RN_PE_RL_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_2_RX__RN_PE_RL_Max_Power); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_2_RX__RN_PE_RL_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_2_RX__RN_PE_RL_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_2_RX__RN_PE_RL_Enable_Drive); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_1_RX__RN_PE_RL_Error_Reset); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_1_RX__RN_PE_RL_Speed_Limit); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_1_RX__RN_PE_RL_Torque_Set_Point); 
            AllCanSignalTypes.Add(RN_PE_RL_PDO_1_RX__RN_PE_RL_Enable_Drive); 
            AllCanSignalTypes.Add(PE_RR_NMT__pe_rr_nmt); 
            AllCanSignalTypes.Add(PE_RL_NMT__pe_rl_nmt); 
            AllCanSignalTypes.Add(PE_FR_NMT__pe_fr_nmt); 
            AllCanSignalTypes.Add(PE_FL_NMT__pe_fl_nmt); 

            foreach (var signalType in AllCanSignalTypes)
            {
                signalType.CalculateBitMask();
            }
        }
        
        public static CanSignalType GpsState__gps_ok = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 1,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "gps_ok",
            QualifiedName = "GpsState.gps_ok",
            Unit          = "",
        };
        
        public static CanSignalType GpsPosition__latitude = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Float,
            Length        = 32,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "latitude",
            QualifiedName = "GpsPosition.latitude",
            Unit          = "degrees",
        };
        
        public static CanSignalType GpsPosition__longitude = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Float,
            Length        = 32,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "longitude",
            QualifiedName = "GpsPosition.longitude",
            Unit          = "degrees",
        };
        
        public static CanSignalType FrontGyro__gyro_z = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "gyro_z",
            QualifiedName = "FrontGyro.gyro_z",
            Unit          = "",
        };
        
        public static CanSignalType FrontGyro__gyro_y = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "gyro_y",
            QualifiedName = "FrontGyro.gyro_y",
            Unit          = "",
        };
        
        public static CanSignalType FrontGyro__gyro_x = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "gyro_x",
            QualifiedName = "FrontGyro.gyro_x",
            Unit          = "",
        };
        
        public static CanSignalType FrontAccelerometer__acc_z = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Float,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 32,
            Comment       = "",
            Name          = "acc_z",
            QualifiedName = "FrontAccelerometer.acc_z",
            Unit          = "m/s^2",
        };
        
        public static CanSignalType FrontAccelerometer__acc_y = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Float,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "acc_y",
            QualifiedName = "FrontAccelerometer.acc_y",
            Unit          = "m/s^2",
        };
        
        public static CanSignalType FrontAccelerometer__acc_x = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Float,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 0,
            Comment       = "",
            Name          = "acc_x",
            QualifiedName = "FrontAccelerometer.acc_x",
            Unit          = "m/s^2",
        };
        
        public static CanSignalType FrontSensors__rotor_temp_fl = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 32,
            Comment       = "",
            Name          = "rotor_temp_fl",
            QualifiedName = "FrontSensors.rotor_temp_fl",
            Unit          = "",
        };
        
        public static CanSignalType FrontSensors__rotor_temp_FR = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 40,
            Comment       = "",
            Name          = "rotor_temp_FR",
            QualifiedName = "FrontSensors.rotor_temp_FR",
            Unit          = "",
        };
        
        public static CanSignalType FrontSensors__damper_fr = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 16,
            Comment       = "",
            Name          = "damper_fr",
            QualifiedName = "FrontSensors.damper_fr",
            Unit          = "",
        };
        
        public static CanSignalType FrontSensors__damper_fl = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 0,
            Comment       = "",
            Name          = "damper_fl",
            QualifiedName = "FrontSensors.damper_fl",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeTemperatures__water_temp_fr = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 40,
            Comment       = "",
            Name          = "water_temp_fr",
            QualifiedName = "FrontNodeTemperatures.water_temp_fr",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeTemperatures__water_temp_fl = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 32,
            Comment       = "",
            Name          = "water_temp_fl",
            QualifiedName = "FrontNodeTemperatures.water_temp_fl",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeTemperatures__gearbox_temp_fr = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 24,
            Comment       = "",
            Name          = "gearbox_temp_fr",
            QualifiedName = "FrontNodeTemperatures.gearbox_temp_fr",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeTemperatures__gearbox_temp_fl = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 16,
            Comment       = "",
            Name          = "gearbox_temp_fl",
            QualifiedName = "FrontNodeTemperatures.gearbox_temp_fl",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeTemperatures__brake_temp_fr = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 4,
            StartBit      = 8,
            Comment       = "",
            Name          = "brake_temp_fr",
            QualifiedName = "FrontNodeTemperatures.brake_temp_fr",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeTemperatures__brake_temp_fl = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 1020,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 4,
            StartBit      = 0,
            Comment       = "",
            Name          = "brake_temp_fl",
            QualifiedName = "FrontNodeTemperatures.brake_temp_fl",
            Unit          = "",
        };
        
        public static CanSignalType DriveControls__apps = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 40,
            Comment       = "",
            Name          = "apps",
            QualifiedName = "DriveControls.apps",
            Unit          = "",
        };
        
        public static CanSignalType DriveControls__steering_angle = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 254,
            MinValue      = -256,
            Offset        = 0,
            ScaleFactor   = 2,
            StartBit      = 32,
            Comment       = "",
            Name          = "steering_angle",
            QualifiedName = "DriveControls.steering_angle",
            Unit          = "",
        };
        
        public static CanSignalType DriveControls__FN_Brake_System = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 24,
            Comment       = "",
            Name          = "FN_Brake_System",
            QualifiedName = "DriveControls.FN_Brake_System",
            Unit          = "",
        };
        
        public static CanSignalType DriveControls__FN_Brake_Pedal = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 16,
            Comment       = "",
            Name          = "FN_Brake_Pedal",
            QualifiedName = "DriveControls.FN_Brake_Pedal",
            Unit          = "",
        };
        
        public static CanSignalType DriveControls__apps_2_voltage = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 127.5,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 8,
            Comment       = "",
            Name          = "apps_2_voltage",
            QualifiedName = "DriveControls.apps_2_voltage",
            Unit          = "",
        };
        
        public static CanSignalType DriveControls__apps_1_voltage = new CanSignalType(new List<string>{
            "FrontNode", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 127.5,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 0,
            Comment       = "",
            Name          = "apps_1_voltage",
            QualifiedName = "DriveControls.apps_1_voltage",
            Unit          = "",
        };
        
        public static CanSignalType RearSensors__rotor_temp_rr = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 8,
            Comment       = "",
            Name          = "rotor_temp_rr",
            QualifiedName = "RearSensors.rotor_temp_rr",
            Unit          = "",
        };
        
        public static CanSignalType RearSensors__rotor_temp_rl = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 132.5,
            MinValue      = 5,
            Offset        = 5,
            ScaleFactor   = 0.5,
            StartBit      = 0,
            Comment       = "",
            Name          = "rotor_temp_rl",
            QualifiedName = "RearSensors.rotor_temp_rl",
            Unit          = "",
        };
        
        public static CanSignalType RearSensors__damper_rr = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 32,
            Comment       = "",
            Name          = "damper_rr",
            QualifiedName = "RearSensors.damper_rr",
            Unit          = "",
        };
        
        public static CanSignalType RearSensors__damper_rl = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 16,
            Comment       = "",
            Name          = "damper_rl",
            QualifiedName = "RearSensors.damper_rl",
            Unit          = "",
        };
        
        public static CanSignalType RearNodeTemperatures__RN_Water_Motor_RR = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 48,
            Comment       = "",
            Name          = "RN_Water_Motor_RR",
            QualifiedName = "RearNodeTemperatures.RN_Water_Motor_RR",
            Unit          = "",
        };
        
        public static CanSignalType RearNodeTemperatures__RN_Water_Motor_RL = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 32,
            Comment       = "",
            Name          = "RN_Water_Motor_RL",
            QualifiedName = "RearNodeTemperatures.RN_Water_Motor_RL",
            Unit          = "",
        };
        
        public static CanSignalType RearNodeTemperatures__RN_Water_Motor_Radiator = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 16,
            Comment       = "",
            Name          = "RN_Water_Motor_Radiator",
            QualifiedName = "RearNodeTemperatures.RN_Water_Motor_Radiator",
            Unit          = "",
        };
        
        public static CanSignalType RearNodeTemperatures__RN_Water_Motor_PE = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_Water_Motor_PE",
            QualifiedName = "RearNodeTemperatures.RN_Water_Motor_PE",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeState__fn_front_torque_scale = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 102,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.4,
            StartBit      = 40,
            Comment       = "",
            Name          = "fn_front_torque_scale",
            QualifiedName = "FrontNodeState.fn_front_torque_scale",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeState__fn_speed_limit = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 25500,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 100,
            StartBit      = 32,
            Comment       = "",
            Name          = "fn_speed_limit",
            QualifiedName = "FrontNodeState.fn_speed_limit",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeState__fn_max_torque = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 102,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.4,
            StartBit      = 24,
            Comment       = "",
            Name          = "fn_max_torque",
            QualifiedName = "FrontNodeState.fn_max_torque",
            Unit          = "",
        };
        
        public static CanSignalType FrontNodeState__fn_status = new CanSignalType(new List<string>{
            "FrontNode", "Ams", "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "TS_Start,R2D,Fan,",
            Name          = "fn_status",
            QualifiedName = "FrontNodeState.fn_status",
            Unit          = "",
        };
        
        public static CanSignalType RearNodeStatus__rn_status = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "DRS,",
            Name          = "rn_status",
            QualifiedName = "RearNodeStatus.rn_status",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorStackErrors__stack6_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "stack6_errors",
            QualifiedName = "AccumulatorStackErrors.stack6_errors",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorStackErrors__stack5_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "stack5_errors",
            QualifiedName = "AccumulatorStackErrors.stack5_errors",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorStackErrors__stack4_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "stack4_errors",
            QualifiedName = "AccumulatorStackErrors.stack4_errors",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorStackErrors__stack3_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "stack3_errors",
            QualifiedName = "AccumulatorStackErrors.stack3_errors",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorStackErrors__stack2_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "stack2_errors",
            QualifiedName = "AccumulatorStackErrors.stack2_errors",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorStackErrors__stack1_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "stack1_errors",
            QualifiedName = "AccumulatorStackErrors.stack1_errors",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_Wh__IVT_ResultState_And_MsgCount_Wh = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_Wh",
            QualifiedName = "IVT_Msg_Result_Wh.IVT_ResultState_And_MsgCount_Wh",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_Wh__IVT_Result_Wh = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_Wh",
            QualifiedName = "IVT_Msg_Result_Wh.IVT_Result_Wh",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_Wh__IVT_MuxID_Wh = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_Wh",
            QualifiedName = "IVT_Msg_Result_Wh.IVT_MuxID_Wh",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_W__IVT_ResultState_And_MsgCount_W = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_W",
            QualifiedName = "IVT_Msg_Result_W.IVT_ResultState_And_MsgCount_W",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_W__IVT_Result_W = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_W",
            QualifiedName = "IVT_Msg_Result_W.IVT_Result_W",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_W__IVT_MuxID_W = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_W",
            QualifiedName = "IVT_Msg_Result_W.IVT_MuxID_W",
            Unit          = "",
        };
        
        public static CanSignalType AmsClientStatus__AmsClient_Trigger_Ams = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "AmsClient_Trigger_Ams",
            QualifiedName = "AmsClientStatus.AmsClient_Trigger_Ams",
            Unit          = "",
        };
        
        public static CanSignalType AmsClientStatus__AmsClient_Start_TS = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "AmsClient_Start_TS",
            QualifiedName = "AmsClientStatus.AmsClient_Start_TS",
            Unit          = "",
        };
        
        public static CanSignalType AmsClientStatus__AmsClient_FN_Buttons = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "AmsClient_FN_Buttons",
            QualifiedName = "AmsClientStatus.AmsClient_FN_Buttons",
            Unit          = "",
        };
        
        public static CanSignalType AmsClientStatus__AmsClient_FrontNode_Status = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "AmsClient_FrontNode_Status",
            QualifiedName = "AmsClientStatus.AmsClient_FrontNode_Status",
            Unit          = "",
        };
        
        public static CanSignalType AmsClientStatus__AmsClient_Enable_Communication = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "AmsClient_Enable_Communication",
            QualifiedName = "AmsClientStatus.AmsClient_Enable_Communication",
            Unit          = "",
        };
        
        public static CanSignalType PrechargeProgress__progress = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 100,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "progress",
            QualifiedName = "PrechargeProgress.progress",
            Unit          = "",
        };
        
        public static CanSignalType PrechargeProgress__fail_air1_open = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 1,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "fail_air1_open",
            QualifiedName = "PrechargeProgress.fail_air1_open",
            Unit          = "",
        };
        
        public static CanSignalType PrechargeProgress__fail_timeout = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 1,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 9,
            Comment       = "",
            Name          = "fail_timeout",
            QualifiedName = "PrechargeProgress.fail_timeout",
            Unit          = "",
        };
        
        public static CanSignalType PrechargeProgress__succeeded = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 1,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 10,
            Comment       = "",
            Name          = "succeeded",
            QualifiedName = "PrechargeProgress.succeeded",
            Unit          = "",
        };
        
        public static CanSignalType AmsStatus__Ams_Watchdog = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "Ams_Watchdog",
            QualifiedName = "AmsStatus.Ams_Watchdog",
            Unit          = "",
        };
        
        public static CanSignalType AmsStatus__Ams_Precharge_Time = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "Ams_Precharge_Time",
            QualifiedName = "AmsStatus.Ams_Precharge_Time",
            Unit          = "",
        };
        
        public static CanSignalType AmsStatus__Ams_Accumulator_Errors = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "Ams_Accumulator_Errors",
            QualifiedName = "AmsStatus.Ams_Accumulator_Errors",
            Unit          = "",
        };
        
        public static CanSignalType AmsStatus__Ams_Accumulator_SoC = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "Ams_Accumulator_SoC",
            QualifiedName = "AmsStatus.Ams_Accumulator_SoC",
            Unit          = "",
        };
        
        public static CanSignalType AmsStatus__ams_status = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "TS_On,",
            Name          = "ams_status",
            QualifiedName = "AmsStatus.ams_status",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxTemperatures__Ams_AvgTemp = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "Ams_AvgTemp",
            QualifiedName = "AccumulatorMinMaxTemperatures.Ams_AvgTemp",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxTemperatures__Ams_MinTemp = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 40,
            Comment       = "",
            Name          = "Ams_MinTemp",
            QualifiedName = "AccumulatorMinMaxTemperatures.Ams_MinTemp",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxTemperatures__Ams_MinTemp_Pos_Stack = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "Ams_MinTemp_Pos_Stack",
            QualifiedName = "AccumulatorMinMaxTemperatures.Ams_MinTemp_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxTemperatures__Ams_MaxTemp = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 16,
            Comment       = "",
            Name          = "Ams_MaxTemp",
            QualifiedName = "AccumulatorMinMaxTemperatures.Ams_MaxTemp",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxTemperatures__Ams_MaxTemp_Pos_Stack = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "Ams_MaxTemp_Pos_Stack",
            QualifiedName = "AccumulatorMinMaxTemperatures.Ams_MaxTemp_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxVoltages__Ams_AvgVoltage = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "Ams_AvgVoltage",
            QualifiedName = "AccumulatorMinMaxVoltages.Ams_AvgVoltage",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxVoltages__Ams_MinVoltage = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65.535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 40,
            Comment       = "",
            Name          = "Ams_MinVoltage",
            QualifiedName = "AccumulatorMinMaxVoltages.Ams_MinVoltage",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxVoltages__Ams_MinVoltage_Pos_Stack = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "Ams_MinVoltage_Pos_Stack",
            QualifiedName = "AccumulatorMinMaxVoltages.Ams_MinVoltage_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxVoltages__Ams_MaxVoltage = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65.535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "Ams_MaxVoltage",
            QualifiedName = "AccumulatorMinMaxVoltages.Ams_MaxVoltage",
            Unit          = "",
        };
        
        public static CanSignalType AccumulatorMinMaxVoltages__Ams_MaxVoltage_Pos_Stack = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "Ams_MaxVoltage_Pos_Stack",
            QualifiedName = "AccumulatorMinMaxVoltages.Ams_MaxVoltage_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType Ams_Cell_Voltages__Ams_Voltage3 = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65.535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 48,
            Comment       = "",
            Name          = "Ams_Voltage3",
            QualifiedName = "Ams_Cell_Voltages.Ams_Voltage3",
            Unit          = "",
        };
        
        public static CanSignalType AmsCellTemperatures__Ams_Temp3 = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655.35,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 48,
            Comment       = "",
            Name          = "Ams_Temp3",
            QualifiedName = "AmsCellTemperatures.Ams_Temp3",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U3__IVT_ResultState_And_MsgCount_U3 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_U3",
            QualifiedName = "IVT_Msg_Result_U3.IVT_ResultState_And_MsgCount_U3",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U3__IVT_Result_U3 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 32000,
            MinValue      = -32000,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_U3",
            QualifiedName = "IVT_Msg_Result_U3.IVT_Result_U3",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U3__IVT_MuxID_U3 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_U3",
            QualifiedName = "IVT_Msg_Result_U3.IVT_MuxID_U3",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U2__IVT_ResultState_And_MsgCount_U2 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_U2",
            QualifiedName = "IVT_Msg_Result_U2.IVT_ResultState_And_MsgCount_U2",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U2__IVT_Result_U2 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 32000,
            MinValue      = -32000,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_U2",
            QualifiedName = "IVT_Msg_Result_U2.IVT_Result_U2",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U2__IVT_MuxID_U2 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_U2",
            QualifiedName = "IVT_Msg_Result_U2.IVT_MuxID_U2",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U1__IVT_ResultState_And_MsgCount_U1 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_U1",
            QualifiedName = "IVT_Msg_Result_U1.IVT_ResultState_And_MsgCount_U1",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U1__IVT_Result_U1 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 32000,
            MinValue      = -32000,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_U1",
            QualifiedName = "IVT_Msg_Result_U1.IVT_Result_U1",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U1__IVT_MuxID_U1 = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_U1",
            QualifiedName = "IVT_Msg_Result_U1.IVT_MuxID_U1",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_T__IVT_ResultState_And_MsgCount_T = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_T",
            QualifiedName = "IVT_Msg_Result_T.IVT_ResultState_And_MsgCount_T",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_T__IVT_Result_T = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 214748364.7,
            MinValue      = -214748364.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_T",
            QualifiedName = "IVT_Msg_Result_T.IVT_Result_T",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_T__IVT_MuxID_T = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_T",
            QualifiedName = "IVT_Msg_Result_T.IVT_MuxID_T",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_I__IVT_ResultState_And_MsgCount_I = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_I",
            QualifiedName = "IVT_Msg_Result_I.IVT_ResultState_And_MsgCount_I",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_I__IVT_Result_I = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 32000,
            MinValue      = -32000,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_I",
            QualifiedName = "IVT_Msg_Result_I.IVT_Result_I",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_I__IVT_MuxID_I = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_I",
            QualifiedName = "IVT_Msg_Result_I.IVT_MuxID_I",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_As__IVT_ResultState_And_MsgCount_As = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 8,
            Comment       = "",
            Name          = "IVT_ResultState_And_MsgCount_As",
            QualifiedName = "IVT_Msg_Result_As.IVT_ResultState_And_MsgCount_As",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_As__IVT_Result_As = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 32,
            MaxValue      = 2147483.647,
            MinValue      = -2147483.648,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 16,
            Comment       = "",
            Name          = "IVT_Result_As",
            QualifiedName = "IVT_Msg_Result_As.IVT_Result_As",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_As__IVT_MuxID_As = new CanSignalType(new List<string>{
            "Ams", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "IVT_MuxID_As",
            QualifiedName = "IVT_Msg_Result_As.IVT_MuxID_As",
            Unit          = "",
        };
        
        public static CanSignalType PowerElectronicsErrors__pe_rr_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 48,
            Comment       = "",
            Name          = "pe_rr_errors",
            QualifiedName = "PowerElectronicsErrors.pe_rr_errors",
            Unit          = "",
        };
        
        public static CanSignalType PowerElectronicsErrors__pe_rl_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "pe_rl_errors",
            QualifiedName = "PowerElectronicsErrors.pe_rl_errors",
            Unit          = "",
        };
        
        public static CanSignalType PowerElectronicsErrors__pe_fr_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "pe_fr_errors",
            QualifiedName = "PowerElectronicsErrors.pe_fr_errors",
            Unit          = "",
        };
        
        public static CanSignalType PowerElectronicsErrors__pe_fl_errors = new CanSignalType(new List<string>{
            "FrontNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "pe_fl_errors",
            QualifiedName = "PowerElectronicsErrors.pe_fl_errors",
            Unit          = "",
        };
        
        public static CanSignalType PE_FR_PDO_3_TX__PE_FR_Iq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_FR_Iq",
            QualifiedName = "PE_FR_PDO_3_TX.PE_FR_Iq",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_FR_PDO_3_TX__PE_FR_Id = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_FR_Id",
            QualifiedName = "PE_FR_PDO_3_TX.PE_FR_Id",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_FR_PDO_3_TX__PE_FR_Uq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_FR_Uq",
            QualifiedName = "PE_FR_PDO_3_TX.PE_FR_Uq",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_FR_PDO_3_TX__PE_FR_Ud = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_FR_Ud",
            QualifiedName = "PE_FR_PDO_3_TX.PE_FR_Ud",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_FR_PDO_2_TX__PE_FR_Temp_Stator = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_FR_Temp_Stator",
            QualifiedName = "PE_FR_PDO_2_TX.PE_FR_Temp_Stator",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_FR_PDO_2_TX__PE_FR_Measured_Udc = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_FR_Measured_Udc",
            QualifiedName = "PE_FR_PDO_2_TX.PE_FR_Measured_Udc",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_FR_PDO_2_TX__PE_FR_Temp_Inverter = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_FR_Temp_Inverter",
            QualifiedName = "PE_FR_PDO_2_TX.PE_FR_Temp_Inverter",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_FR_PDO_2_TX__PE_FR_Power_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 327670,
            MinValue      = -327680,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_FR_Power_Estimate",
            QualifiedName = "PE_FR_PDO_2_TX.PE_FR_Power_Estimate",
            Unit          = "DW",
        };
        
        public static CanSignalType PE_FR_PDO_1_TX__PE_FR_Errors = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "PE_FR_Errors",
            QualifiedName = "PE_FR_PDO_1_TX.PE_FR_Errors",
            Unit          = "",
        };
        
        public static CanSignalType PE_FR_PDO_1_TX__PE_FR_Speed_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "PE_FR_Speed_Estimate",
            QualifiedName = "PE_FR_PDO_1_TX.PE_FR_Speed_Estimate",
            Unit          = "RPM",
        };
        
        public static CanSignalType PE_FR_PDO_1_TX__PE_FR_Torque_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "",
            Name          = "PE_FR_Torque_Estimate",
            QualifiedName = "PE_FR_PDO_1_TX.PE_FR_Torque_Estimate",
            Unit          = "mNm",
        };
        
        public static CanSignalType PE_FR_PDO_1_TX__PE_FR_Drive_Engaged = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_FR_Drive_Engaged",
            QualifiedName = "PE_FR_PDO_1_TX.PE_FR_Drive_Engaged",
            Unit          = "",
        };
        
        public static CanSignalType PE_FL_PDO_3_TX__PE_FL_Iq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_FL_Iq",
            QualifiedName = "PE_FL_PDO_3_TX.PE_FL_Iq",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_FL_PDO_3_TX__PE_FL_Id = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_FL_Id",
            QualifiedName = "PE_FL_PDO_3_TX.PE_FL_Id",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_FL_PDO_3_TX__PE_FL_Uq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_FL_Uq",
            QualifiedName = "PE_FL_PDO_3_TX.PE_FL_Uq",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_FL_PDO_3_TX__PE_FL_Ud = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_FL_Ud",
            QualifiedName = "PE_FL_PDO_3_TX.PE_FL_Ud",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_FL_PDO_2_TX__PE_FL_Temp_Stator = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_FL_Temp_Stator",
            QualifiedName = "PE_FL_PDO_2_TX.PE_FL_Temp_Stator",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_FL_PDO_2_TX__PE_FL_Measured_Udc = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_FL_Measured_Udc",
            QualifiedName = "PE_FL_PDO_2_TX.PE_FL_Measured_Udc",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_FL_PDO_2_TX__PE_FL_Temp_Inverter = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_FL_Temp_Inverter",
            QualifiedName = "PE_FL_PDO_2_TX.PE_FL_Temp_Inverter",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_FL_PDO_2_TX__PE_FL_Power_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 327670,
            MinValue      = -327680,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_FL_Power_Estimate",
            QualifiedName = "PE_FL_PDO_2_TX.PE_FL_Power_Estimate",
            Unit          = "DW",
        };
        
        public static CanSignalType PE_FL_PDO_1_TX__PE_FL_Errors = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "PE_FL_Errors",
            QualifiedName = "PE_FL_PDO_1_TX.PE_FL_Errors",
            Unit          = "",
        };
        
        public static CanSignalType PE_FL_PDO_1_TX__PE_FL_Speed_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "PE_FL_Speed_Estimate",
            QualifiedName = "PE_FL_PDO_1_TX.PE_FL_Speed_Estimate",
            Unit          = "RPM",
        };
        
        public static CanSignalType PE_FL_PDO_1_TX__PE_FL_Torque_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "",
            Name          = "PE_FL_Torque_Estimate",
            QualifiedName = "PE_FL_PDO_1_TX.PE_FL_Torque_Estimate",
            Unit          = "mNm",
        };
        
        public static CanSignalType PE_FL_PDO_1_TX__PE_FL_Drive_Engaged = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_FL_Drive_Engaged",
            QualifiedName = "PE_FL_PDO_1_TX.PE_FL_Drive_Engaged",
            Unit          = "",
        };
        
        public static CanSignalType PE_RR_PDO_3_TX__PE_RR_Iq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_RR_Iq",
            QualifiedName = "PE_RR_PDO_3_TX.PE_RR_Iq",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_RR_PDO_3_TX__PE_RR_Id = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_RR_Id",
            QualifiedName = "PE_RR_PDO_3_TX.PE_RR_Id",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_RR_PDO_3_TX__PE_RR_Uq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_RR_Uq",
            QualifiedName = "PE_RR_PDO_3_TX.PE_RR_Uq",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_RR_PDO_3_TX__PE_RR_Ud = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_RR_Ud",
            QualifiedName = "PE_RR_PDO_3_TX.PE_RR_Ud",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_RR_PDO_2_TX__PE_RR_Temp_Stator = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_RR_Temp_Stator",
            QualifiedName = "PE_RR_PDO_2_TX.PE_RR_Temp_Stator",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_RR_PDO_2_TX__PE_RR_Measured_Udc = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_RR_Measured_Udc",
            QualifiedName = "PE_RR_PDO_2_TX.PE_RR_Measured_Udc",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_RR_PDO_2_TX__PE_RR_Temp_Inverter = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_RR_Temp_Inverter",
            QualifiedName = "PE_RR_PDO_2_TX.PE_RR_Temp_Inverter",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_RR_PDO_2_TX__PE_RR_Power_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 327670,
            MinValue      = -327680,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_RR_Power_Estimate",
            QualifiedName = "PE_RR_PDO_2_TX.PE_RR_Power_Estimate",
            Unit          = "DW",
        };
        
        public static CanSignalType PE_RR_PDO_1_TX__PE_RR_Errors = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "PE_RR_Errors",
            QualifiedName = "PE_RR_PDO_1_TX.PE_RR_Errors",
            Unit          = "",
        };
        
        public static CanSignalType PE_RR_PDO_1_TX__PE_RR_Speed_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "PE_RR_Speed_Estimate",
            QualifiedName = "PE_RR_PDO_1_TX.PE_RR_Speed_Estimate",
            Unit          = "RPM",
        };
        
        public static CanSignalType PE_RR_PDO_1_TX__PE_RR_Torque_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "",
            Name          = "PE_RR_Torque_Estimate",
            QualifiedName = "PE_RR_PDO_1_TX.PE_RR_Torque_Estimate",
            Unit          = "mNm",
        };
        
        public static CanSignalType PE_RR_PDO_1_TX__PE_RR_Drive_Engaged = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_RR_Drive_Engaged",
            QualifiedName = "PE_RR_PDO_1_TX.PE_RR_Drive_Engaged",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FR_PDO_3_RX__RN_PE_FR_Max_Power = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_FR_Max_Power",
            QualifiedName = "RN_PE_FR_PDO_3_RX.RN_PE_FR_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_FR_PDO_3_RX__RN_PE_FR_Speed_Limit = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_FR_Speed_Limit",
            QualifiedName = "RN_PE_FR_PDO_3_RX.RN_PE_FR_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_FR_PDO_3_RX__RN_PE_FR_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_FR_Torque_Set_Point",
            QualifiedName = "RN_PE_FR_PDO_3_RX.RN_PE_FR_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_FR_PDO_3_RX__RN_PE_FR_Enable_Drive = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_FR_Enable_Drive",
            QualifiedName = "RN_PE_FR_PDO_3_RX.RN_PE_FR_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FR_PDO_2_RX__RN_PE_FR_Max_Power = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_FR_Max_Power",
            QualifiedName = "RN_PE_FR_PDO_2_RX.RN_PE_FR_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_FR_PDO_2_RX__RN_PE_FR_Speed_Limit = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_FR_Speed_Limit",
            QualifiedName = "RN_PE_FR_PDO_2_RX.RN_PE_FR_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_FR_PDO_2_RX__RN_PE_FR_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_FR_Torque_Set_Point",
            QualifiedName = "RN_PE_FR_PDO_2_RX.RN_PE_FR_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_FR_PDO_2_RX__RN_PE_FR_Enable_Drive = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_FR_Enable_Drive",
            QualifiedName = "RN_PE_FR_PDO_2_RX.RN_PE_FR_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FR_PDO_1_RX__RN_PE_FR_Error_Reset = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_FR_Error_Reset",
            QualifiedName = "RN_PE_FR_PDO_1_RX.RN_PE_FR_Error_Reset",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FR_PDO_1_RX__RN_PE_FR_Speed_Limit = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_FR_Speed_Limit",
            QualifiedName = "RN_PE_FR_PDO_1_RX.RN_PE_FR_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_FR_PDO_1_RX__RN_PE_FR_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_FR_Torque_Set_Point",
            QualifiedName = "RN_PE_FR_PDO_1_RX.RN_PE_FR_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_FR_PDO_1_RX__RN_PE_FR_Enable_Drive = new CanSignalType(new List<string>{
            "PE_FR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_FR_Enable_Drive",
            QualifiedName = "RN_PE_FR_PDO_1_RX.RN_PE_FR_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FL_PDO_3_RX__RN_PE_FL_Max_Power = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_FL_Max_Power",
            QualifiedName = "RN_PE_FL_PDO_3_RX.RN_PE_FL_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_FL_PDO_3_RX__RN_PE_FL_Speed_Limit = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_FL_Speed_Limit",
            QualifiedName = "RN_PE_FL_PDO_3_RX.RN_PE_FL_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_FL_PDO_3_RX__RN_PE_FL_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_FL_Torque_Set_Point",
            QualifiedName = "RN_PE_FL_PDO_3_RX.RN_PE_FL_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_FL_PDO_3_RX__RN_PE_FL_Enable_Drive = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_FL_Enable_Drive",
            QualifiedName = "RN_PE_FL_PDO_3_RX.RN_PE_FL_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FL_PDO_2_RX__RN_PE_FL_Max_Power = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_FL_Max_Power",
            QualifiedName = "RN_PE_FL_PDO_2_RX.RN_PE_FL_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_FL_PDO_2_RX__RN_PE_FL_Speed_Limit = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_FL_Speed_Limit",
            QualifiedName = "RN_PE_FL_PDO_2_RX.RN_PE_FL_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_FL_PDO_2_RX__RN_PE_FL_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_FL_Torque_Set_Point",
            QualifiedName = "RN_PE_FL_PDO_2_RX.RN_PE_FL_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_FL_PDO_2_RX__RN_PE_FL_Enable_Drive = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_FL_Enable_Drive",
            QualifiedName = "RN_PE_FL_PDO_2_RX.RN_PE_FL_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FL_PDO_1_RX__RN_PE_FL_Error_Reset = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_FL_Error_Reset",
            QualifiedName = "RN_PE_FL_PDO_1_RX.RN_PE_FL_Error_Reset",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_FL_PDO_1_RX__RN_PE_FL_Speed_Limit = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_FL_Speed_Limit",
            QualifiedName = "RN_PE_FL_PDO_1_RX.RN_PE_FL_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_FL_PDO_1_RX__RN_PE_FL_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_FL_Torque_Set_Point",
            QualifiedName = "RN_PE_FL_PDO_1_RX.RN_PE_FL_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_FL_PDO_1_RX__RN_PE_FL_Enable_Drive = new CanSignalType(new List<string>{
            "PE_FL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_FL_Enable_Drive",
            QualifiedName = "RN_PE_FL_PDO_1_RX.RN_PE_FL_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RR_PDO_3_RX__RN_PE_RR_Max_Power = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_RR_Max_Power",
            QualifiedName = "RN_PE_RR_PDO_3_RX.RN_PE_RR_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_RR_PDO_3_RX__RN_PE_RR_Speed_Limit = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_RR_Speed_Limit",
            QualifiedName = "RN_PE_RR_PDO_3_RX.RN_PE_RR_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_RR_PDO_3_RX__RN_PE_RR_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_RR_Torque_Set_Point",
            QualifiedName = "RN_PE_RR_PDO_3_RX.RN_PE_RR_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_RR_PDO_3_RX__RN_PE_RR_Enable_Drive = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_RR_Enable_Drive",
            QualifiedName = "RN_PE_RR_PDO_3_RX.RN_PE_RR_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RR_PDO_2_RX__RN_PE_RR_Max_Power = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_RR_Max_Power",
            QualifiedName = "RN_PE_RR_PDO_2_RX.RN_PE_RR_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_RR_PDO_2_RX__RN_PE_RR_Speed_Limit = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_RR_Speed_Limit",
            QualifiedName = "RN_PE_RR_PDO_2_RX.RN_PE_RR_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_RR_PDO_2_RX__RN_PE_RR_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_RR_Torque_Set_Point",
            QualifiedName = "RN_PE_RR_PDO_2_RX.RN_PE_RR_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_RR_PDO_2_RX__RN_PE_RR_Enable_Drive = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_RR_Enable_Drive",
            QualifiedName = "RN_PE_RR_PDO_2_RX.RN_PE_RR_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RR_PDO_1_RX__RN_PE_RR_Error_Reset = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_RR_Error_Reset",
            QualifiedName = "RN_PE_RR_PDO_1_RX.RN_PE_RR_Error_Reset",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RR_PDO_1_RX__RN_PE_RR_Speed_Limit = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_RR_Speed_Limit",
            QualifiedName = "RN_PE_RR_PDO_1_RX.RN_PE_RR_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_RR_PDO_1_RX__RN_PE_RR_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_RR_Torque_Set_Point",
            QualifiedName = "RN_PE_RR_PDO_1_RX.RN_PE_RR_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_RR_PDO_1_RX__RN_PE_RR_Enable_Drive = new CanSignalType(new List<string>{
            "PE_RR", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_RR_Enable_Drive",
            QualifiedName = "RN_PE_RR_PDO_1_RX.RN_PE_RR_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType PE_RL_PDO_3_TX__PE_RL_Iq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_RL_Iq",
            QualifiedName = "PE_RL_PDO_3_TX.PE_RL_Iq",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_RL_PDO_3_TX__PE_RL_Id = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 3276.7,
            MinValue      = -3276.8,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_RL_Id",
            QualifiedName = "PE_RL_PDO_3_TX.PE_RL_Id",
            Unit          = "dA",
        };
        
        public static CanSignalType PE_RL_PDO_3_TX__PE_RL_Uq = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_RL_Uq",
            QualifiedName = "PE_RL_PDO_3_TX.PE_RL_Uq",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_RL_PDO_3_TX__PE_RL_Ud = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_RL_Ud",
            QualifiedName = "PE_RL_PDO_3_TX.PE_RL_Ud",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_RL_PDO_2_TX__PE_RL_Temp_Stator = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "PE_RL_Temp_Stator",
            QualifiedName = "PE_RL_PDO_2_TX.PE_RL_Temp_Stator",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_RL_PDO_2_TX__PE_RL_Measured_Udc = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 16,
            Comment       = "",
            Name          = "PE_RL_Measured_Udc",
            QualifiedName = "PE_RL_PDO_2_TX.PE_RL_Measured_Udc",
            Unit          = "dV",
        };
        
        public static CanSignalType PE_RL_PDO_2_TX__PE_RL_Temp_Inverter = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 48,
            Comment       = "",
            Name          = "PE_RL_Temp_Inverter",
            QualifiedName = "PE_RL_PDO_2_TX.PE_RL_Temp_Inverter",
            Unit          = "degC",
        };
        
        public static CanSignalType PE_RL_PDO_2_TX__PE_RL_Power_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 327670,
            MinValue      = -327680,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_RL_Power_Estimate",
            QualifiedName = "PE_RL_PDO_2_TX.PE_RL_Power_Estimate",
            Unit          = "DW",
        };
        
        public static CanSignalType PE_RL_PDO_1_TX__PE_RL_Errors = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "PE_RL_Errors",
            QualifiedName = "PE_RL_PDO_1_TX.PE_RL_Errors",
            Unit          = "",
        };
        
        public static CanSignalType PE_RL_PDO_1_TX__PE_RL_Speed_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "PE_RL_Speed_Estimate",
            QualifiedName = "PE_RL_PDO_1_TX.PE_RL_Speed_Estimate",
            Unit          = "RPM",
        };
        
        public static CanSignalType PE_RL_PDO_1_TX__PE_RL_Torque_Estimate = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "",
            Name          = "PE_RL_Torque_Estimate",
            QualifiedName = "PE_RL_PDO_1_TX.PE_RL_Torque_Estimate",
            Unit          = "mNm",
        };
        
        public static CanSignalType PE_RL_PDO_1_TX__PE_RL_Drive_Engaged = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "PE_RL_Drive_Engaged",
            QualifiedName = "PE_RL_PDO_1_TX.PE_RL_Drive_Engaged",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RL_PDO_3_RX__RN_PE_RL_Max_Power = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_RL_Max_Power",
            QualifiedName = "RN_PE_RL_PDO_3_RX.RN_PE_RL_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_RL_PDO_3_RX__RN_PE_RL_Speed_Limit = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_RL_Speed_Limit",
            QualifiedName = "RN_PE_RL_PDO_3_RX.RN_PE_RL_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_RL_PDO_3_RX__RN_PE_RL_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_RL_Torque_Set_Point",
            QualifiedName = "RN_PE_RL_PDO_3_RX.RN_PE_RL_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_RL_PDO_3_RX__RN_PE_RL_Enable_Drive = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_RL_Enable_Drive",
            QualifiedName = "RN_PE_RL_PDO_3_RX.RN_PE_RL_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RL_PDO_2_RX__RN_PE_RL_Max_Power = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 655350,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 10,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_RL_Max_Power",
            QualifiedName = "RN_PE_RL_PDO_2_RX.RN_PE_RL_Max_Power",
            Unit          = "DW",
        };
        
        public static CanSignalType RN_PE_RL_PDO_2_RX__RN_PE_RL_Speed_Limit = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_RL_Speed_Limit",
            QualifiedName = "RN_PE_RL_PDO_2_RX.RN_PE_RL_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_RL_PDO_2_RX__RN_PE_RL_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_RL_Torque_Set_Point",
            QualifiedName = "RN_PE_RL_PDO_2_RX.RN_PE_RL_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_RL_PDO_2_RX__RN_PE_RL_Enable_Drive = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_RL_Enable_Drive",
            QualifiedName = "RN_PE_RL_PDO_2_RX.RN_PE_RL_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RL_PDO_1_RX__RN_PE_RL_Error_Reset = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 40,
            Comment       = "",
            Name          = "RN_PE_RL_Error_Reset",
            QualifiedName = "RN_PE_RL_PDO_1_RX.RN_PE_RL_Error_Reset",
            Unit          = "",
        };
        
        public static CanSignalType RN_PE_RL_PDO_1_RX__RN_PE_RL_Speed_Limit = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_PE_RL_Speed_Limit",
            QualifiedName = "RN_PE_RL_PDO_1_RX.RN_PE_RL_Speed_Limit",
            Unit          = "RPM",
        };
        
        public static CanSignalType RN_PE_RL_PDO_1_RX__RN_PE_RL_Torque_Set_Point = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 32.767,
            MinValue      = -32.768,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 8,
            Comment       = "22.5",
            Name          = "RN_PE_RL_Torque_Set_Point",
            QualifiedName = "RN_PE_RL_PDO_1_RX.RN_PE_RL_Torque_Set_Point",
            Unit          = "mNm",
        };
        
        public static CanSignalType RN_PE_RL_PDO_1_RX__RN_PE_RL_Enable_Drive = new CanSignalType(new List<string>{
            "PE_RL", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_PE_RL_Enable_Drive",
            QualifiedName = "RN_PE_RL_PDO_1_RX.RN_PE_RL_Enable_Drive",
            Unit          = "",
        };
        
        public static CanSignalType PE_RR_NMT__pe_rr_nmt = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "pe_rr_nmt",
            QualifiedName = "PE_RR_NMT.pe_rr_nmt",
            Unit          = "",
        };
        
        public static CanSignalType PE_RL_NMT__pe_rl_nmt = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "pe_rl_nmt",
            QualifiedName = "PE_RL_NMT.pe_rl_nmt",
            Unit          = "",
        };
        
        public static CanSignalType PE_FR_NMT__pe_fr_nmt = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "pe_fr_nmt",
            QualifiedName = "PE_FR_NMT.pe_fr_nmt",
            Unit          = "",
        };
        
        public static CanSignalType PE_FL_NMT__pe_fl_nmt = new CanSignalType(new List<string>{
            "RearNode", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 255,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "pe_fl_nmt",
            QualifiedName = "PE_FL_NMT.pe_fl_nmt",
            Unit          = "",
        };
        
    }

    
    public class GpsStateMessage : CanMessage<GpsStateMessage>
    {
        public GpsStateMessage()
        {
            MessageType = CanMessageTypes.GpsState;
        }
        public static readonly CanSignalType gps_ok = CanSignalTypes.GpsState__gps_ok;
        public sbyte Getgps_ok()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(gps_ok);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setgps_ok(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(gps_ok, (UInt64)value);
        }
    }
    
    
    public class GpsPositionMessage : CanMessage<GpsPositionMessage>
    {
        public GpsPositionMessage()
        {
            MessageType = CanMessageTypes.GpsPosition;
        }
        public static readonly CanSignalType latitude = CanSignalTypes.GpsPosition__latitude;
        public float Getlatitude()
        {
            // Get bits from raw data storage and cast
            float tempValue = (float)ExtractBits(latitude);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setlatitude(float value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(latitude, (UInt64)value);
        }
        public static readonly CanSignalType longitude = CanSignalTypes.GpsPosition__longitude;
        public float Getlongitude()
        {
            // Get bits from raw data storage and cast
            float tempValue = (float)ExtractBits(longitude);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setlongitude(float value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(longitude, (UInt64)value);
        }
    }
    
    
    public class FrontGyroMessage : CanMessage<FrontGyroMessage>
    {
        public FrontGyroMessage()
        {
            MessageType = CanMessageTypes.FrontGyro;
        }
        public static readonly CanSignalType gyro_z = CanSignalTypes.FrontGyro__gyro_z;
        public Int16 Getgyro_z()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(gyro_z);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setgyro_z(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(gyro_z, (UInt64)value);
        }
        public static readonly CanSignalType gyro_y = CanSignalTypes.FrontGyro__gyro_y;
        public Int16 Getgyro_y()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(gyro_y);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setgyro_y(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(gyro_y, (UInt64)value);
        }
        public static readonly CanSignalType gyro_x = CanSignalTypes.FrontGyro__gyro_x;
        public Int16 Getgyro_x()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(gyro_x);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setgyro_x(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(gyro_x, (UInt64)value);
        }
    }
    
    
    public class FrontAccelerometerMessage : CanMessage<FrontAccelerometerMessage>
    {
        public FrontAccelerometerMessage()
        {
            MessageType = CanMessageTypes.FrontAccelerometer;
        }
        public static readonly CanSignalType acc_z = CanSignalTypes.FrontAccelerometer__acc_z;
        public float Getacc_z()
        {
            // Get bits from raw data storage and cast
            float tempValue = (float)ExtractBits(acc_z);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void Setacc_z(float value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(acc_z, (UInt64)value);
        }
        public static readonly CanSignalType acc_y = CanSignalTypes.FrontAccelerometer__acc_y;
        public float Getacc_y()
        {
            // Get bits from raw data storage and cast
            float tempValue = (float)ExtractBits(acc_y);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void Setacc_y(float value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(acc_y, (UInt64)value);
        }
        public static readonly CanSignalType acc_x = CanSignalTypes.FrontAccelerometer__acc_x;
        public float Getacc_x()
        {
            // Get bits from raw data storage and cast
            float tempValue = (float)ExtractBits(acc_x);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void Setacc_x(float value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(acc_x, (UInt64)value);
        }
    }
    
    
    public class FrontSensorsMessage : CanMessage<FrontSensorsMessage>
    {
        public FrontSensorsMessage()
        {
            MessageType = CanMessageTypes.FrontSensors;
        }
        public static readonly CanSignalType rotor_temp_fl = CanSignalTypes.FrontSensors__rotor_temp_fl;
        public sbyte Getrotor_temp_fl()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(rotor_temp_fl);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setrotor_temp_fl(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(rotor_temp_fl, (UInt64)value);
        }
        public static readonly CanSignalType rotor_temp_FR = CanSignalTypes.FrontSensors__rotor_temp_FR;
        public sbyte Getrotor_temp_FR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(rotor_temp_FR);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setrotor_temp_FR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(rotor_temp_FR, (UInt64)value);
        }
        public static readonly CanSignalType damper_fr = CanSignalTypes.FrontSensors__damper_fr;
        public UInt16 Getdamper_fr()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(damper_fr);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void Setdamper_fr(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(damper_fr, (UInt64)value);
        }
        public static readonly CanSignalType damper_fl = CanSignalTypes.FrontSensors__damper_fl;
        public UInt16 Getdamper_fl()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(damper_fl);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void Setdamper_fl(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(damper_fl, (UInt64)value);
        }
    }
    
    
    public class FrontNodeTemperaturesMessage : CanMessage<FrontNodeTemperaturesMessage>
    {
        public FrontNodeTemperaturesMessage()
        {
            MessageType = CanMessageTypes.FrontNodeTemperatures;
        }
        public static readonly CanSignalType water_temp_fr = CanSignalTypes.FrontNodeTemperatures__water_temp_fr;
        public sbyte Getwater_temp_fr()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(water_temp_fr);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setwater_temp_fr(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(water_temp_fr, (UInt64)value);
        }
        public static readonly CanSignalType water_temp_fl = CanSignalTypes.FrontNodeTemperatures__water_temp_fl;
        public sbyte Getwater_temp_fl()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(water_temp_fl);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setwater_temp_fl(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(water_temp_fl, (UInt64)value);
        }
        public static readonly CanSignalType gearbox_temp_fr = CanSignalTypes.FrontNodeTemperatures__gearbox_temp_fr;
        public sbyte Getgearbox_temp_fr()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(gearbox_temp_fr);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setgearbox_temp_fr(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(gearbox_temp_fr, (UInt64)value);
        }
        public static readonly CanSignalType gearbox_temp_fl = CanSignalTypes.FrontNodeTemperatures__gearbox_temp_fl;
        public sbyte Getgearbox_temp_fl()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(gearbox_temp_fl);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setgearbox_temp_fl(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(gearbox_temp_fl, (UInt64)value);
        }
        public static readonly CanSignalType brake_temp_fr = CanSignalTypes.FrontNodeTemperatures__brake_temp_fr;
        public sbyte Getbrake_temp_fr()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(brake_temp_fr);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 4;
            return tempValue;
        }
        
        public void Setbrake_temp_fr(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 4;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(brake_temp_fr, (UInt64)value);
        }
        public static readonly CanSignalType brake_temp_fl = CanSignalTypes.FrontNodeTemperatures__brake_temp_fl;
        public sbyte Getbrake_temp_fl()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(brake_temp_fl);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 4;
            return tempValue;
        }
        
        public void Setbrake_temp_fl(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 4;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(brake_temp_fl, (UInt64)value);
        }
    }
    
    
    public class DriveControlsMessage : CanMessage<DriveControlsMessage>
    {
        public DriveControlsMessage()
        {
            MessageType = CanMessageTypes.DriveControls;
        }
        public static readonly CanSignalType apps = CanSignalTypes.DriveControls__apps;
        public sbyte Getapps()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(apps);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setapps(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(apps, (UInt64)value);
        }
        public static readonly CanSignalType steering_angle = CanSignalTypes.DriveControls__steering_angle;
        public byte Getsteering_angle()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(steering_angle);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 2;
            return tempValue;
        }
        
        public void Setsteering_angle(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 2;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(steering_angle, (UInt64)value);
        }
        public static readonly CanSignalType FN_Brake_System = CanSignalTypes.DriveControls__FN_Brake_System;
        public sbyte GetFN_Brake_System()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Brake_System);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Brake_System(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Brake_System, (UInt64)value);
        }
        public static readonly CanSignalType FN_Brake_Pedal = CanSignalTypes.DriveControls__FN_Brake_Pedal;
        public sbyte GetFN_Brake_Pedal()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Brake_Pedal);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Brake_Pedal(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Brake_Pedal, (UInt64)value);
        }
        public static readonly CanSignalType apps_2_voltage = CanSignalTypes.DriveControls__apps_2_voltage;
        public sbyte Getapps_2_voltage()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(apps_2_voltage);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setapps_2_voltage(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(apps_2_voltage, (UInt64)value);
        }
        public static readonly CanSignalType apps_1_voltage = CanSignalTypes.DriveControls__apps_1_voltage;
        public sbyte Getapps_1_voltage()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(apps_1_voltage);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setapps_1_voltage(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(apps_1_voltage, (UInt64)value);
        }
    }
    
    
    public class RearSensorsMessage : CanMessage<RearSensorsMessage>
    {
        public RearSensorsMessage()
        {
            MessageType = CanMessageTypes.RearSensors;
        }
        public static readonly CanSignalType rotor_temp_rr = CanSignalTypes.RearSensors__rotor_temp_rr;
        public sbyte Getrotor_temp_rr()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(rotor_temp_rr);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setrotor_temp_rr(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(rotor_temp_rr, (UInt64)value);
        }
        public static readonly CanSignalType rotor_temp_rl = CanSignalTypes.RearSensors__rotor_temp_rl;
        public sbyte Getrotor_temp_rl()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(rotor_temp_rl);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void Setrotor_temp_rl(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(rotor_temp_rl, (UInt64)value);
        }
        public static readonly CanSignalType damper_rr = CanSignalTypes.RearSensors__damper_rr;
        public UInt16 Getdamper_rr()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(damper_rr);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void Setdamper_rr(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(damper_rr, (UInt64)value);
        }
        public static readonly CanSignalType damper_rl = CanSignalTypes.RearSensors__damper_rl;
        public UInt16 Getdamper_rl()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(damper_rl);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void Setdamper_rl(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(damper_rl, (UInt64)value);
        }
    }
    
    
    public class RearNodeTemperaturesMessage : CanMessage<RearNodeTemperaturesMessage>
    {
        public RearNodeTemperaturesMessage()
        {
            MessageType = CanMessageTypes.RearNodeTemperatures;
        }
        public static readonly CanSignalType RN_Water_Motor_RR = CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_RR;
        public UInt16 GetRN_Water_Motor_RR()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Water_Motor_RR);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetRN_Water_Motor_RR(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Water_Motor_RR, (UInt64)value);
        }
        public static readonly CanSignalType RN_Water_Motor_RL = CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_RL;
        public UInt16 GetRN_Water_Motor_RL()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Water_Motor_RL);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetRN_Water_Motor_RL(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Water_Motor_RL, (UInt64)value);
        }
        public static readonly CanSignalType RN_Water_Motor_Radiator = CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_Radiator;
        public UInt16 GetRN_Water_Motor_Radiator()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Water_Motor_Radiator);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetRN_Water_Motor_Radiator(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Water_Motor_Radiator, (UInt64)value);
        }
        public static readonly CanSignalType RN_Water_Motor_PE = CanSignalTypes.RearNodeTemperatures__RN_Water_Motor_PE;
        public UInt16 GetRN_Water_Motor_PE()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Water_Motor_PE);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetRN_Water_Motor_PE(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Water_Motor_PE, (UInt64)value);
        }
    }
    
    
    public class FrontNodeStateMessage : CanMessage<FrontNodeStateMessage>
    {
        public FrontNodeStateMessage()
        {
            MessageType = CanMessageTypes.FrontNodeState;
        }
        public static readonly CanSignalType fn_front_torque_scale = CanSignalTypes.FrontNodeState__fn_front_torque_scale;
        public sbyte Getfn_front_torque_scale()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(fn_front_torque_scale);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= (sbyte)2.5;
            return tempValue;
        }
        
        public void Setfn_front_torque_scale(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= (sbyte)2.5;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(fn_front_torque_scale, (UInt64)value);
        }
        public static readonly CanSignalType fn_speed_limit = CanSignalTypes.FrontNodeState__fn_speed_limit;
        public sbyte Getfn_speed_limit()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(fn_speed_limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 100;
            return tempValue;
        }
        
        public void Setfn_speed_limit(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 100;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(fn_speed_limit, (UInt64)value);
        }
        public static readonly CanSignalType fn_max_torque = CanSignalTypes.FrontNodeState__fn_max_torque;
        public sbyte Getfn_max_torque()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(fn_max_torque);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= (sbyte)2.5;
            return tempValue;
        }
        
        public void Setfn_max_torque(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= (sbyte)2.5;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(fn_max_torque, (UInt64)value);
        }
        public static readonly CanSignalType fn_status = CanSignalTypes.FrontNodeState__fn_status;
        public UInt16 Getfn_status()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(fn_status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setfn_status(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(fn_status, (UInt64)value);
        }
    }
    
    
    public class RearNodeStatusMessage : CanMessage<RearNodeStatusMessage>
    {
        public RearNodeStatusMessage()
        {
            MessageType = CanMessageTypes.RearNodeStatus;
        }
        public static readonly CanSignalType rn_status = CanSignalTypes.RearNodeStatus__rn_status;
        public sbyte Getrn_status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(rn_status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setrn_status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(rn_status, (UInt64)value);
        }
    }
    
    
    public class AccumulatorStackErrorsMessage : CanMessage<AccumulatorStackErrorsMessage>
    {
        public AccumulatorStackErrorsMessage()
        {
            MessageType = CanMessageTypes.AccumulatorStackErrors;
        }
        public static readonly CanSignalType stack6_errors = CanSignalTypes.AccumulatorStackErrors__stack6_errors;
        public sbyte Getstack6_errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(stack6_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setstack6_errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(stack6_errors, (UInt64)value);
        }
        public static readonly CanSignalType stack5_errors = CanSignalTypes.AccumulatorStackErrors__stack5_errors;
        public sbyte Getstack5_errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(stack5_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setstack5_errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(stack5_errors, (UInt64)value);
        }
        public static readonly CanSignalType stack4_errors = CanSignalTypes.AccumulatorStackErrors__stack4_errors;
        public sbyte Getstack4_errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(stack4_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setstack4_errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(stack4_errors, (UInt64)value);
        }
        public static readonly CanSignalType stack3_errors = CanSignalTypes.AccumulatorStackErrors__stack3_errors;
        public sbyte Getstack3_errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(stack3_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setstack3_errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(stack3_errors, (UInt64)value);
        }
        public static readonly CanSignalType stack2_errors = CanSignalTypes.AccumulatorStackErrors__stack2_errors;
        public sbyte Getstack2_errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(stack2_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setstack2_errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(stack2_errors, (UInt64)value);
        }
        public static readonly CanSignalType stack1_errors = CanSignalTypes.AccumulatorStackErrors__stack1_errors;
        public sbyte Getstack1_errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(stack1_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setstack1_errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(stack1_errors, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_WhMessage : CanMessage<IVT_Msg_Result_WhMessage>
    {
        public IVT_Msg_Result_WhMessage()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_Wh;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_Wh = CanSignalTypes.IVT_Msg_Result_Wh__IVT_ResultState_And_MsgCount_Wh;
        public byte GetIVT_ResultState_And_MsgCount_Wh()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_Wh);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_Wh(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_Wh, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_Wh = CanSignalTypes.IVT_Msg_Result_Wh__IVT_Result_Wh;
        public Int32 GetIVT_Result_Wh()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_Wh);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_Result_Wh(Int32 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_Wh, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_Wh = CanSignalTypes.IVT_Msg_Result_Wh__IVT_MuxID_Wh;
        public sbyte GetIVT_MuxID_Wh()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_Wh);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_Wh(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_Wh, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_WMessage : CanMessage<IVT_Msg_Result_WMessage>
    {
        public IVT_Msg_Result_WMessage()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_W;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_W = CanSignalTypes.IVT_Msg_Result_W__IVT_ResultState_And_MsgCount_W;
        public byte GetIVT_ResultState_And_MsgCount_W()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_W);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_W(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_W, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_W = CanSignalTypes.IVT_Msg_Result_W__IVT_Result_W;
        public Int32 GetIVT_Result_W()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_W);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_Result_W(Int32 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_W, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_W = CanSignalTypes.IVT_Msg_Result_W__IVT_MuxID_W;
        public sbyte GetIVT_MuxID_W()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_W);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_W(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_W, (UInt64)value);
        }
    }
    
    
    public class AmsClientStatusMessage : CanMessage<AmsClientStatusMessage>
    {
        public AmsClientStatusMessage()
        {
            MessageType = CanMessageTypes.AmsClientStatus;
        }
        public static readonly CanSignalType AmsClient_Trigger_Ams = CanSignalTypes.AmsClientStatus__AmsClient_Trigger_Ams;
        public sbyte GetAmsClient_Trigger_Ams()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AmsClient_Trigger_Ams);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAmsClient_Trigger_Ams(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AmsClient_Trigger_Ams, (UInt64)value);
        }
        public static readonly CanSignalType AmsClient_Start_TS = CanSignalTypes.AmsClientStatus__AmsClient_Start_TS;
        public sbyte GetAmsClient_Start_TS()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AmsClient_Start_TS);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAmsClient_Start_TS(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AmsClient_Start_TS, (UInt64)value);
        }
        public static readonly CanSignalType AmsClient_FN_Buttons = CanSignalTypes.AmsClientStatus__AmsClient_FN_Buttons;
        public sbyte GetAmsClient_FN_Buttons()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AmsClient_FN_Buttons);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAmsClient_FN_Buttons(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AmsClient_FN_Buttons, (UInt64)value);
        }
        public static readonly CanSignalType AmsClient_FrontNode_Status = CanSignalTypes.AmsClientStatus__AmsClient_FrontNode_Status;
        public sbyte GetAmsClient_FrontNode_Status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AmsClient_FrontNode_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAmsClient_FrontNode_Status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AmsClient_FrontNode_Status, (UInt64)value);
        }
        public static readonly CanSignalType AmsClient_Enable_Communication = CanSignalTypes.AmsClientStatus__AmsClient_Enable_Communication;
        public sbyte GetAmsClient_Enable_Communication()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AmsClient_Enable_Communication);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAmsClient_Enable_Communication(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AmsClient_Enable_Communication, (UInt64)value);
        }
    }
    
    
    public class PrechargeProgressMessage : CanMessage<PrechargeProgressMessage>
    {
        public PrechargeProgressMessage()
        {
            MessageType = CanMessageTypes.PrechargeProgress;
        }
        public static readonly CanSignalType progress = CanSignalTypes.PrechargeProgress__progress;
        public sbyte Getprogress()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(progress);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setprogress(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(progress, (UInt64)value);
        }
        public static readonly CanSignalType fail_air1_open = CanSignalTypes.PrechargeProgress__fail_air1_open;
        public sbyte Getfail_air1_open()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(fail_air1_open);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setfail_air1_open(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(fail_air1_open, (UInt64)value);
        }
        public static readonly CanSignalType fail_timeout = CanSignalTypes.PrechargeProgress__fail_timeout;
        public sbyte Getfail_timeout()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(fail_timeout);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setfail_timeout(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(fail_timeout, (UInt64)value);
        }
        public static readonly CanSignalType succeeded = CanSignalTypes.PrechargeProgress__succeeded;
        public sbyte Getsucceeded()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(succeeded);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setsucceeded(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(succeeded, (UInt64)value);
        }
    }
    
    
    public class AmsStatusMessage : CanMessage<AmsStatusMessage>
    {
        public AmsStatusMessage()
        {
            MessageType = CanMessageTypes.AmsStatus;
        }
        public static readonly CanSignalType Ams_Watchdog = CanSignalTypes.AmsStatus__Ams_Watchdog;
        public sbyte GetAms_Watchdog()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_Watchdog);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_Watchdog(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_Watchdog, (UInt64)value);
        }
        public static readonly CanSignalType Ams_Precharge_Time = CanSignalTypes.AmsStatus__Ams_Precharge_Time;
        public sbyte GetAms_Precharge_Time()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_Precharge_Time);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_Precharge_Time(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_Precharge_Time, (UInt64)value);
        }
        public static readonly CanSignalType Ams_Accumulator_Errors = CanSignalTypes.AmsStatus__Ams_Accumulator_Errors;
        public sbyte GetAms_Accumulator_Errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_Accumulator_Errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_Accumulator_Errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_Accumulator_Errors, (UInt64)value);
        }
        public static readonly CanSignalType Ams_Accumulator_SoC = CanSignalTypes.AmsStatus__Ams_Accumulator_SoC;
        public sbyte GetAms_Accumulator_SoC()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_Accumulator_SoC);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_Accumulator_SoC(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_Accumulator_SoC, (UInt64)value);
        }
        public static readonly CanSignalType ams_status = CanSignalTypes.AmsStatus__ams_status;
        public sbyte Getams_status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(ams_status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setams_status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(ams_status, (UInt64)value);
        }
    }
    
    
    public class AccumulatorMinMaxTemperaturesMessage : CanMessage<AccumulatorMinMaxTemperaturesMessage>
    {
        public AccumulatorMinMaxTemperaturesMessage()
        {
            MessageType = CanMessageTypes.AccumulatorMinMaxTemperatures;
        }
        public static readonly CanSignalType Ams_AvgTemp = CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_AvgTemp;
        public byte GetAms_AvgTemp()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(Ams_AvgTemp);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_AvgTemp(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_AvgTemp, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MinTemp = CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MinTemp;
        public UInt16 GetAms_MinTemp()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(Ams_MinTemp);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAms_MinTemp(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MinTemp, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MinTemp_Pos_Stack = CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MinTemp_Pos_Stack;
        public sbyte GetAms_MinTemp_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_MinTemp_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_MinTemp_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MinTemp_Pos_Stack, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MaxTemp = CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MaxTemp;
        public UInt16 GetAms_MaxTemp()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(Ams_MaxTemp);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAms_MaxTemp(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MaxTemp, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MaxTemp_Pos_Stack = CanSignalTypes.AccumulatorMinMaxTemperatures__Ams_MaxTemp_Pos_Stack;
        public sbyte GetAms_MaxTemp_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_MaxTemp_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_MaxTemp_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MaxTemp_Pos_Stack, (UInt64)value);
        }
    }
    
    
    public class AccumulatorMinMaxVoltagesMessage : CanMessage<AccumulatorMinMaxVoltagesMessage>
    {
        public AccumulatorMinMaxVoltagesMessage()
        {
            MessageType = CanMessageTypes.AccumulatorMinMaxVoltages;
        }
        public static readonly CanSignalType Ams_AvgVoltage = CanSignalTypes.AccumulatorMinMaxVoltages__Ams_AvgVoltage;
        public byte GetAms_AvgVoltage()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(Ams_AvgVoltage);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_AvgVoltage(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_AvgVoltage, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MinVoltage = CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MinVoltage;
        public UInt16 GetAms_MinVoltage()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(Ams_MinVoltage);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAms_MinVoltage(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MinVoltage, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MinVoltage_Pos_Stack = CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MinVoltage_Pos_Stack;
        public sbyte GetAms_MinVoltage_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_MinVoltage_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_MinVoltage_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MinVoltage_Pos_Stack, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MaxVoltage = CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MaxVoltage;
        public UInt16 GetAms_MaxVoltage()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(Ams_MaxVoltage);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAms_MaxVoltage(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MaxVoltage, (UInt64)value);
        }
        public static readonly CanSignalType Ams_MaxVoltage_Pos_Stack = CanSignalTypes.AccumulatorMinMaxVoltages__Ams_MaxVoltage_Pos_Stack;
        public sbyte GetAms_MaxVoltage_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(Ams_MaxVoltage_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAms_MaxVoltage_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_MaxVoltage_Pos_Stack, (UInt64)value);
        }
    }
    
    
    public class Ams_Cell_VoltagesMessage : CanMessage<Ams_Cell_VoltagesMessage>
    {
        public Ams_Cell_VoltagesMessage()
        {
            MessageType = CanMessageTypes.Ams_Cell_Voltages;
        }
        public static readonly CanSignalType Ams_Voltage3 = CanSignalTypes.Ams_Cell_Voltages__Ams_Voltage3;
        public UInt16 GetAms_Voltage3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(Ams_Voltage3);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAms_Voltage3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_Voltage3, (UInt64)value);
        }
    }
    
    
    public class AmsCellTemperaturesMessage : CanMessage<AmsCellTemperaturesMessage>
    {
        public AmsCellTemperaturesMessage()
        {
            MessageType = CanMessageTypes.AmsCellTemperatures;
        }
        public static readonly CanSignalType Ams_Temp3 = CanSignalTypes.AmsCellTemperatures__Ams_Temp3;
        public UInt16 GetAms_Temp3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(Ams_Temp3);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAms_Temp3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(Ams_Temp3, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_U3Message : CanMessage<IVT_Msg_Result_U3Message>
    {
        public IVT_Msg_Result_U3Message()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_U3;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_U3 = CanSignalTypes.IVT_Msg_Result_U3__IVT_ResultState_And_MsgCount_U3;
        public byte GetIVT_ResultState_And_MsgCount_U3()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_U3);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_U3(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_U3, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_U3 = CanSignalTypes.IVT_Msg_Result_U3__IVT_Result_U3;
        public Int32 GetIVT_Result_U3()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_U3);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_Result_U3(Int32 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_U3, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_U3 = CanSignalTypes.IVT_Msg_Result_U3__IVT_MuxID_U3;
        public sbyte GetIVT_MuxID_U3()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_U3);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_U3(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_U3, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_U2Message : CanMessage<IVT_Msg_Result_U2Message>
    {
        public IVT_Msg_Result_U2Message()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_U2;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_U2 = CanSignalTypes.IVT_Msg_Result_U2__IVT_ResultState_And_MsgCount_U2;
        public byte GetIVT_ResultState_And_MsgCount_U2()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_U2);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_U2(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_U2, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_U2 = CanSignalTypes.IVT_Msg_Result_U2__IVT_Result_U2;
        public Int32 GetIVT_Result_U2()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_U2);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_Result_U2(Int32 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_U2, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_U2 = CanSignalTypes.IVT_Msg_Result_U2__IVT_MuxID_U2;
        public sbyte GetIVT_MuxID_U2()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_U2);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_U2(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_U2, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_U1Message : CanMessage<IVT_Msg_Result_U1Message>
    {
        public IVT_Msg_Result_U1Message()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_U1;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_U1 = CanSignalTypes.IVT_Msg_Result_U1__IVT_ResultState_And_MsgCount_U1;
        public byte GetIVT_ResultState_And_MsgCount_U1()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_U1);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_U1(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_U1, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_U1 = CanSignalTypes.IVT_Msg_Result_U1__IVT_Result_U1;
        public Int32 GetIVT_Result_U1()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_U1);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_Result_U1(Int32 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_U1, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_U1 = CanSignalTypes.IVT_Msg_Result_U1__IVT_MuxID_U1;
        public sbyte GetIVT_MuxID_U1()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_U1);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_U1(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_U1, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_TMessage : CanMessage<IVT_Msg_Result_TMessage>
    {
        public IVT_Msg_Result_TMessage()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_T;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_T = CanSignalTypes.IVT_Msg_Result_T__IVT_ResultState_And_MsgCount_T;
        public byte GetIVT_ResultState_And_MsgCount_T()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_T);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_T(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_T, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_T = CanSignalTypes.IVT_Msg_Result_T__IVT_Result_T;
        public Int32 GetIVT_Result_T()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_T);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetIVT_Result_T(Int32 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_T, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_T = CanSignalTypes.IVT_Msg_Result_T__IVT_MuxID_T;
        public sbyte GetIVT_MuxID_T()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_T);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_T(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_T, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_IMessage : CanMessage<IVT_Msg_Result_IMessage>
    {
        public IVT_Msg_Result_IMessage()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_I;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_I = CanSignalTypes.IVT_Msg_Result_I__IVT_ResultState_And_MsgCount_I;
        public byte GetIVT_ResultState_And_MsgCount_I()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_I);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_I(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_I, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_I = CanSignalTypes.IVT_Msg_Result_I__IVT_Result_I;
        public Int32 GetIVT_Result_I()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_I);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetIVT_Result_I(Int32 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_I, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_I = CanSignalTypes.IVT_Msg_Result_I__IVT_MuxID_I;
        public sbyte GetIVT_MuxID_I()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_I);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_I(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_I, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_AsMessage : CanMessage<IVT_Msg_Result_AsMessage>
    {
        public IVT_Msg_Result_AsMessage()
        {
            MessageType = CanMessageTypes.IVT_Msg_Result_As;
        }
        public static readonly CanSignalType IVT_ResultState_And_MsgCount_As = CanSignalTypes.IVT_Msg_Result_As__IVT_ResultState_And_MsgCount_As;
        public byte GetIVT_ResultState_And_MsgCount_As()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(IVT_ResultState_And_MsgCount_As);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_ResultState_And_MsgCount_As(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_ResultState_And_MsgCount_As, (UInt64)value);
        }
        public static readonly CanSignalType IVT_Result_As = CanSignalTypes.IVT_Msg_Result_As__IVT_Result_As;
        public Int32 GetIVT_Result_As()
        {
            // Get bits from raw data storage and cast
            Int32 tempValue = (Int32)ExtractBits(IVT_Result_As);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetIVT_Result_As(Int32 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_Result_As, (UInt64)value);
        }
        public static readonly CanSignalType IVT_MuxID_As = CanSignalTypes.IVT_Msg_Result_As__IVT_MuxID_As;
        public sbyte GetIVT_MuxID_As()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(IVT_MuxID_As);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetIVT_MuxID_As(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(IVT_MuxID_As, (UInt64)value);
        }
    }
    
    
    public class PowerElectronicsErrorsMessage : CanMessage<PowerElectronicsErrorsMessage>
    {
        public PowerElectronicsErrorsMessage()
        {
            MessageType = CanMessageTypes.PowerElectronicsErrors;
        }
        public static readonly CanSignalType pe_rr_errors = CanSignalTypes.PowerElectronicsErrors__pe_rr_errors;
        public Int16 Getpe_rr_errors()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(pe_rr_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_rr_errors(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_rr_errors, (UInt64)value);
        }
        public static readonly CanSignalType pe_rl_errors = CanSignalTypes.PowerElectronicsErrors__pe_rl_errors;
        public Int16 Getpe_rl_errors()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(pe_rl_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_rl_errors(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_rl_errors, (UInt64)value);
        }
        public static readonly CanSignalType pe_fr_errors = CanSignalTypes.PowerElectronicsErrors__pe_fr_errors;
        public Int16 Getpe_fr_errors()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(pe_fr_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_fr_errors(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_fr_errors, (UInt64)value);
        }
        public static readonly CanSignalType pe_fl_errors = CanSignalTypes.PowerElectronicsErrors__pe_fl_errors;
        public Int16 Getpe_fl_errors()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(pe_fl_errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_fl_errors(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_fl_errors, (UInt64)value);
        }
    }
    
    
    public class PE_FR_PDO_3_TXMessage : CanMessage<PE_FR_PDO_3_TXMessage>
    {
        public PE_FR_PDO_3_TXMessage()
        {
            MessageType = CanMessageTypes.PE_FR_PDO_3_TX;
        }
        public static readonly CanSignalType PE_FR_Iq = CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Iq;
        public Int16 GetPE_FR_Iq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Iq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FR_Iq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Iq, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Id = CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Id;
        public Int16 GetPE_FR_Id()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Id);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FR_Id(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Id, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Uq = CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Uq;
        public Int16 GetPE_FR_Uq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Uq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FR_Uq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Uq, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Ud = CanSignalTypes.PE_FR_PDO_3_TX__PE_FR_Ud;
        public Int16 GetPE_FR_Ud()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Ud);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FR_Ud(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Ud, (UInt64)value);
        }
    }
    
    
    public class PE_FR_PDO_2_TXMessage : CanMessage<PE_FR_PDO_2_TXMessage>
    {
        public PE_FR_PDO_2_TXMessage()
        {
            MessageType = CanMessageTypes.PE_FR_PDO_2_TX;
        }
        public static readonly CanSignalType PE_FR_Temp_Stator = CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Temp_Stator;
        public Int16 GetPE_FR_Temp_Stator()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Temp_Stator);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FR_Temp_Stator(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Temp_Stator, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Measured_Udc = CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Measured_Udc;
        public Int16 GetPE_FR_Measured_Udc()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Measured_Udc);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FR_Measured_Udc(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Measured_Udc, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Temp_Inverter = CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Temp_Inverter;
        public Int16 GetPE_FR_Temp_Inverter()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Temp_Inverter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FR_Temp_Inverter(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Temp_Inverter, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Power_Estimate = CanSignalTypes.PE_FR_PDO_2_TX__PE_FR_Power_Estimate;
        public Int16 GetPE_FR_Power_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Power_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetPE_FR_Power_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Power_Estimate, (UInt64)value);
        }
    }
    
    
    public class PE_FR_PDO_1_TXMessage : CanMessage<PE_FR_PDO_1_TXMessage>
    {
        public PE_FR_PDO_1_TXMessage()
        {
            MessageType = CanMessageTypes.PE_FR_PDO_1_TX;
        }
        public static readonly CanSignalType PE_FR_Errors = CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Errors;
        public UInt16 GetPE_FR_Errors()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(PE_FR_Errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FR_Errors(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Errors, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Speed_Estimate = CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Speed_Estimate;
        public Int16 GetPE_FR_Speed_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Speed_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FR_Speed_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Speed_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Torque_Estimate = CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Torque_Estimate;
        public Int16 GetPE_FR_Torque_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FR_Torque_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetPE_FR_Torque_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Torque_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_FR_Drive_Engaged = CanSignalTypes.PE_FR_PDO_1_TX__PE_FR_Drive_Engaged;
        public sbyte GetPE_FR_Drive_Engaged()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_FR_Drive_Engaged);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FR_Drive_Engaged(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_Drive_Engaged, (UInt64)value);
        }
    }
    
    
    public class PE_FL_PDO_3_TXMessage : CanMessage<PE_FL_PDO_3_TXMessage>
    {
        public PE_FL_PDO_3_TXMessage()
        {
            MessageType = CanMessageTypes.PE_FL_PDO_3_TX;
        }
        public static readonly CanSignalType PE_FL_Iq = CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Iq;
        public Int16 GetPE_FL_Iq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Iq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FL_Iq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Iq, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Id = CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Id;
        public Int16 GetPE_FL_Id()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Id);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FL_Id(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Id, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Uq = CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Uq;
        public Int16 GetPE_FL_Uq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Uq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FL_Uq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Uq, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Ud = CanSignalTypes.PE_FL_PDO_3_TX__PE_FL_Ud;
        public Int16 GetPE_FL_Ud()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Ud);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FL_Ud(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Ud, (UInt64)value);
        }
    }
    
    
    public class PE_FL_PDO_2_TXMessage : CanMessage<PE_FL_PDO_2_TXMessage>
    {
        public PE_FL_PDO_2_TXMessage()
        {
            MessageType = CanMessageTypes.PE_FL_PDO_2_TX;
        }
        public static readonly CanSignalType PE_FL_Temp_Stator = CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Temp_Stator;
        public Int16 GetPE_FL_Temp_Stator()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Temp_Stator);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FL_Temp_Stator(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Temp_Stator, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Measured_Udc = CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Measured_Udc;
        public Int16 GetPE_FL_Measured_Udc()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Measured_Udc);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_FL_Measured_Udc(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Measured_Udc, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Temp_Inverter = CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Temp_Inverter;
        public Int16 GetPE_FL_Temp_Inverter()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Temp_Inverter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FL_Temp_Inverter(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Temp_Inverter, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Power_Estimate = CanSignalTypes.PE_FL_PDO_2_TX__PE_FL_Power_Estimate;
        public Int16 GetPE_FL_Power_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Power_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetPE_FL_Power_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Power_Estimate, (UInt64)value);
        }
    }
    
    
    public class PE_FL_PDO_1_TXMessage : CanMessage<PE_FL_PDO_1_TXMessage>
    {
        public PE_FL_PDO_1_TXMessage()
        {
            MessageType = CanMessageTypes.PE_FL_PDO_1_TX;
        }
        public static readonly CanSignalType PE_FL_Errors = CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Errors;
        public UInt16 GetPE_FL_Errors()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(PE_FL_Errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FL_Errors(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Errors, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Speed_Estimate = CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Speed_Estimate;
        public Int16 GetPE_FL_Speed_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Speed_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FL_Speed_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Speed_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Torque_Estimate = CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Torque_Estimate;
        public Int16 GetPE_FL_Torque_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_FL_Torque_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetPE_FL_Torque_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Torque_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_FL_Drive_Engaged = CanSignalTypes.PE_FL_PDO_1_TX__PE_FL_Drive_Engaged;
        public sbyte GetPE_FL_Drive_Engaged()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_FL_Drive_Engaged);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FL_Drive_Engaged(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_Drive_Engaged, (UInt64)value);
        }
    }
    
    
    public class PE_RR_PDO_3_TXMessage : CanMessage<PE_RR_PDO_3_TXMessage>
    {
        public PE_RR_PDO_3_TXMessage()
        {
            MessageType = CanMessageTypes.PE_RR_PDO_3_TX;
        }
        public static readonly CanSignalType PE_RR_Iq = CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Iq;
        public Int16 GetPE_RR_Iq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Iq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RR_Iq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Iq, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Id = CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Id;
        public Int16 GetPE_RR_Id()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Id);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RR_Id(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Id, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Uq = CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Uq;
        public Int16 GetPE_RR_Uq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Uq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RR_Uq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Uq, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Ud = CanSignalTypes.PE_RR_PDO_3_TX__PE_RR_Ud;
        public Int16 GetPE_RR_Ud()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Ud);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RR_Ud(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Ud, (UInt64)value);
        }
    }
    
    
    public class PE_RR_PDO_2_TXMessage : CanMessage<PE_RR_PDO_2_TXMessage>
    {
        public PE_RR_PDO_2_TXMessage()
        {
            MessageType = CanMessageTypes.PE_RR_PDO_2_TX;
        }
        public static readonly CanSignalType PE_RR_Temp_Stator = CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Temp_Stator;
        public Int16 GetPE_RR_Temp_Stator()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Temp_Stator);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RR_Temp_Stator(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Temp_Stator, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Measured_Udc = CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Measured_Udc;
        public Int16 GetPE_RR_Measured_Udc()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Measured_Udc);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RR_Measured_Udc(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Measured_Udc, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Temp_Inverter = CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Temp_Inverter;
        public Int16 GetPE_RR_Temp_Inverter()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Temp_Inverter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RR_Temp_Inverter(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Temp_Inverter, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Power_Estimate = CanSignalTypes.PE_RR_PDO_2_TX__PE_RR_Power_Estimate;
        public Int16 GetPE_RR_Power_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Power_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetPE_RR_Power_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Power_Estimate, (UInt64)value);
        }
    }
    
    
    public class PE_RR_PDO_1_TXMessage : CanMessage<PE_RR_PDO_1_TXMessage>
    {
        public PE_RR_PDO_1_TXMessage()
        {
            MessageType = CanMessageTypes.PE_RR_PDO_1_TX;
        }
        public static readonly CanSignalType PE_RR_Errors = CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Errors;
        public UInt16 GetPE_RR_Errors()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(PE_RR_Errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RR_Errors(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Errors, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Speed_Estimate = CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Speed_Estimate;
        public Int16 GetPE_RR_Speed_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Speed_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RR_Speed_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Speed_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Torque_Estimate = CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Torque_Estimate;
        public Int16 GetPE_RR_Torque_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RR_Torque_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetPE_RR_Torque_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Torque_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_RR_Drive_Engaged = CanSignalTypes.PE_RR_PDO_1_TX__PE_RR_Drive_Engaged;
        public sbyte GetPE_RR_Drive_Engaged()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_RR_Drive_Engaged);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RR_Drive_Engaged(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_Drive_Engaged, (UInt64)value);
        }
    }
    
    
    public class RN_PE_FR_PDO_3_RXMessage : CanMessage<RN_PE_FR_PDO_3_RXMessage>
    {
        public RN_PE_FR_PDO_3_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_FR_PDO_3_RX;
        }
        public static readonly CanSignalType RN_PE_FR_Max_Power = CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Max_Power;
        public UInt16 GetRN_PE_FR_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_FR_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Speed_Limit = CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Speed_Limit;
        public Int16 GetRN_PE_FR_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FR_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Torque_Set_Point = CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Torque_Set_Point;
        public Int16 GetRN_PE_FR_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FR_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Enable_Drive = CanSignalTypes.RN_PE_FR_PDO_3_RX__RN_PE_FR_Enable_Drive;
        public sbyte GetRN_PE_FR_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_FR_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_FR_PDO_2_RXMessage : CanMessage<RN_PE_FR_PDO_2_RXMessage>
    {
        public RN_PE_FR_PDO_2_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_FR_PDO_2_RX;
        }
        public static readonly CanSignalType RN_PE_FR_Max_Power = CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Max_Power;
        public UInt16 GetRN_PE_FR_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_FR_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Speed_Limit = CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Speed_Limit;
        public Int16 GetRN_PE_FR_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FR_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Torque_Set_Point = CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Torque_Set_Point;
        public Int16 GetRN_PE_FR_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FR_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Enable_Drive = CanSignalTypes.RN_PE_FR_PDO_2_RX__RN_PE_FR_Enable_Drive;
        public sbyte GetRN_PE_FR_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_FR_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_FR_PDO_1_RXMessage : CanMessage<RN_PE_FR_PDO_1_RXMessage>
    {
        public RN_PE_FR_PDO_1_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_FR_PDO_1_RX;
        }
        public static readonly CanSignalType RN_PE_FR_Error_Reset = CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Error_Reset;
        public UInt16 GetRN_PE_FR_Error_Reset()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_FR_Error_Reset);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Error_Reset(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Error_Reset, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Speed_Limit = CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Speed_Limit;
        public Int16 GetRN_PE_FR_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FR_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Torque_Set_Point = CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Torque_Set_Point;
        public Int16 GetRN_PE_FR_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FR_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FR_Enable_Drive = CanSignalTypes.RN_PE_FR_PDO_1_RX__RN_PE_FR_Enable_Drive;
        public sbyte GetRN_PE_FR_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_FR_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FR_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FR_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_FL_PDO_3_RXMessage : CanMessage<RN_PE_FL_PDO_3_RXMessage>
    {
        public RN_PE_FL_PDO_3_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_FL_PDO_3_RX;
        }
        public static readonly CanSignalType RN_PE_FL_Max_Power = CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Max_Power;
        public UInt16 GetRN_PE_FL_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_FL_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Speed_Limit = CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Speed_Limit;
        public Int16 GetRN_PE_FL_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FL_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Torque_Set_Point = CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Torque_Set_Point;
        public Int16 GetRN_PE_FL_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FL_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Enable_Drive = CanSignalTypes.RN_PE_FL_PDO_3_RX__RN_PE_FL_Enable_Drive;
        public sbyte GetRN_PE_FL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_FL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_FL_PDO_2_RXMessage : CanMessage<RN_PE_FL_PDO_2_RXMessage>
    {
        public RN_PE_FL_PDO_2_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_FL_PDO_2_RX;
        }
        public static readonly CanSignalType RN_PE_FL_Max_Power = CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Max_Power;
        public UInt16 GetRN_PE_FL_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_FL_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Speed_Limit = CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Speed_Limit;
        public Int16 GetRN_PE_FL_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FL_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Torque_Set_Point = CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Torque_Set_Point;
        public Int16 GetRN_PE_FL_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FL_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Enable_Drive = CanSignalTypes.RN_PE_FL_PDO_2_RX__RN_PE_FL_Enable_Drive;
        public sbyte GetRN_PE_FL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_FL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_FL_PDO_1_RXMessage : CanMessage<RN_PE_FL_PDO_1_RXMessage>
    {
        public RN_PE_FL_PDO_1_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_FL_PDO_1_RX;
        }
        public static readonly CanSignalType RN_PE_FL_Error_Reset = CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Error_Reset;
        public UInt16 GetRN_PE_FL_Error_Reset()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_FL_Error_Reset);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Error_Reset(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Error_Reset, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Speed_Limit = CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Speed_Limit;
        public Int16 GetRN_PE_FL_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FL_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Torque_Set_Point = CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Torque_Set_Point;
        public Int16 GetRN_PE_FL_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_FL_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_FL_Enable_Drive = CanSignalTypes.RN_PE_FL_PDO_1_RX__RN_PE_FL_Enable_Drive;
        public sbyte GetRN_PE_FL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_FL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_FL_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_FL_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_RR_PDO_3_RXMessage : CanMessage<RN_PE_RR_PDO_3_RXMessage>
    {
        public RN_PE_RR_PDO_3_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RR_PDO_3_RX;
        }
        public static readonly CanSignalType RN_PE_RR_Max_Power = CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Max_Power;
        public UInt16 GetRN_PE_RR_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_RR_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Speed_Limit = CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Speed_Limit;
        public Int16 GetRN_PE_RR_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RR_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Torque_Set_Point = CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Torque_Set_Point;
        public Int16 GetRN_PE_RR_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RR_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Enable_Drive = CanSignalTypes.RN_PE_RR_PDO_3_RX__RN_PE_RR_Enable_Drive;
        public sbyte GetRN_PE_RR_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_RR_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_RR_PDO_2_RXMessage : CanMessage<RN_PE_RR_PDO_2_RXMessage>
    {
        public RN_PE_RR_PDO_2_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RR_PDO_2_RX;
        }
        public static readonly CanSignalType RN_PE_RR_Max_Power = CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Max_Power;
        public UInt16 GetRN_PE_RR_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_RR_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Speed_Limit = CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Speed_Limit;
        public Int16 GetRN_PE_RR_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RR_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Torque_Set_Point = CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Torque_Set_Point;
        public Int16 GetRN_PE_RR_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RR_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Enable_Drive = CanSignalTypes.RN_PE_RR_PDO_2_RX__RN_PE_RR_Enable_Drive;
        public sbyte GetRN_PE_RR_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_RR_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_RR_PDO_1_RXMessage : CanMessage<RN_PE_RR_PDO_1_RXMessage>
    {
        public RN_PE_RR_PDO_1_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RR_PDO_1_RX;
        }
        public static readonly CanSignalType RN_PE_RR_Error_Reset = CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Error_Reset;
        public UInt16 GetRN_PE_RR_Error_Reset()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_RR_Error_Reset);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Error_Reset(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Error_Reset, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Speed_Limit = CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Speed_Limit;
        public Int16 GetRN_PE_RR_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RR_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Torque_Set_Point = CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Torque_Set_Point;
        public Int16 GetRN_PE_RR_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RR_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RR_Enable_Drive = CanSignalTypes.RN_PE_RR_PDO_1_RX__RN_PE_RR_Enable_Drive;
        public sbyte GetRN_PE_RR_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_RR_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RR_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RR_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class PE_RL_PDO_3_TXMessage : CanMessage<PE_RL_PDO_3_TXMessage>
    {
        public PE_RL_PDO_3_TXMessage()
        {
            MessageType = CanMessageTypes.PE_RL_PDO_3_TX;
        }
        public static readonly CanSignalType PE_RL_Iq = CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Iq;
        public Int16 GetPE_RL_Iq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Iq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RL_Iq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Iq, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Id = CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Id;
        public Int16 GetPE_RL_Id()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Id);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RL_Id(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Id, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Uq = CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Uq;
        public Int16 GetPE_RL_Uq()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Uq);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RL_Uq(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Uq, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Ud = CanSignalTypes.PE_RL_PDO_3_TX__PE_RL_Ud;
        public Int16 GetPE_RL_Ud()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Ud);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RL_Ud(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Ud, (UInt64)value);
        }
    }
    
    
    public class PE_RL_PDO_2_TXMessage : CanMessage<PE_RL_PDO_2_TXMessage>
    {
        public PE_RL_PDO_2_TXMessage()
        {
            MessageType = CanMessageTypes.PE_RL_PDO_2_TX;
        }
        public static readonly CanSignalType PE_RL_Temp_Stator = CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Temp_Stator;
        public Int16 GetPE_RL_Temp_Stator()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Temp_Stator);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RL_Temp_Stator(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Temp_Stator, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Measured_Udc = CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Measured_Udc;
        public Int16 GetPE_RL_Measured_Udc()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Measured_Udc);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetPE_RL_Measured_Udc(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Measured_Udc, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Temp_Inverter = CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Temp_Inverter;
        public Int16 GetPE_RL_Temp_Inverter()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Temp_Inverter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RL_Temp_Inverter(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Temp_Inverter, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Power_Estimate = CanSignalTypes.PE_RL_PDO_2_TX__PE_RL_Power_Estimate;
        public Int16 GetPE_RL_Power_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Power_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetPE_RL_Power_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Power_Estimate, (UInt64)value);
        }
    }
    
    
    public class PE_RL_PDO_1_TXMessage : CanMessage<PE_RL_PDO_1_TXMessage>
    {
        public PE_RL_PDO_1_TXMessage()
        {
            MessageType = CanMessageTypes.PE_RL_PDO_1_TX;
        }
        public static readonly CanSignalType PE_RL_Errors = CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Errors;
        public UInt16 GetPE_RL_Errors()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(PE_RL_Errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RL_Errors(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Errors, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Speed_Estimate = CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Speed_Estimate;
        public Int16 GetPE_RL_Speed_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Speed_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RL_Speed_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Speed_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Torque_Estimate = CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Torque_Estimate;
        public Int16 GetPE_RL_Torque_Estimate()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(PE_RL_Torque_Estimate);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetPE_RL_Torque_Estimate(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Torque_Estimate, (UInt64)value);
        }
        public static readonly CanSignalType PE_RL_Drive_Engaged = CanSignalTypes.PE_RL_PDO_1_TX__PE_RL_Drive_Engaged;
        public sbyte GetPE_RL_Drive_Engaged()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_RL_Drive_Engaged);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RL_Drive_Engaged(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_Drive_Engaged, (UInt64)value);
        }
    }
    
    
    public class RN_PE_RL_PDO_3_RXMessage : CanMessage<RN_PE_RL_PDO_3_RXMessage>
    {
        public RN_PE_RL_PDO_3_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RL_PDO_3_RX;
        }
        public static readonly CanSignalType RN_PE_RL_Max_Power = CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Max_Power;
        public UInt16 GetRN_PE_RL_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_RL_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Speed_Limit = CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Speed_Limit;
        public Int16 GetRN_PE_RL_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RL_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Torque_Set_Point = CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Torque_Set_Point;
        public Int16 GetRN_PE_RL_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RL_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Enable_Drive = CanSignalTypes.RN_PE_RL_PDO_3_RX__RN_PE_RL_Enable_Drive;
        public sbyte GetRN_PE_RL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_RL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_RL_PDO_2_RXMessage : CanMessage<RN_PE_RL_PDO_2_RXMessage>
    {
        public RN_PE_RL_PDO_2_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RL_PDO_2_RX;
        }
        public static readonly CanSignalType RN_PE_RL_Max_Power = CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Max_Power;
        public UInt16 GetRN_PE_RL_Max_Power()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_RL_Max_Power);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 10;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Max_Power(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 10;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Max_Power, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Speed_Limit = CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Speed_Limit;
        public Int16 GetRN_PE_RL_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RL_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Torque_Set_Point = CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Torque_Set_Point;
        public Int16 GetRN_PE_RL_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RL_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Enable_Drive = CanSignalTypes.RN_PE_RL_PDO_2_RX__RN_PE_RL_Enable_Drive;
        public sbyte GetRN_PE_RL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_RL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class RN_PE_RL_PDO_1_RXMessage : CanMessage<RN_PE_RL_PDO_1_RXMessage>
    {
        public RN_PE_RL_PDO_1_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RL_PDO_1_RX;
        }
        public static readonly CanSignalType RN_PE_RL_Error_Reset = CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Error_Reset;
        public UInt16 GetRN_PE_RL_Error_Reset()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_PE_RL_Error_Reset);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Error_Reset(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Error_Reset, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Speed_Limit = CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Speed_Limit;
        public Int16 GetRN_PE_RL_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RL_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Speed_Limit(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Torque_Set_Point = CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Torque_Set_Point;
        public Int16 GetRN_PE_RL_Torque_Set_Point()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_PE_RL_Torque_Set_Point);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Torque_Set_Point(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Torque_Set_Point, (UInt64)value);
        }
        public static readonly CanSignalType RN_PE_RL_Enable_Drive = CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Enable_Drive;
        public sbyte GetRN_PE_RL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_PE_RL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Enable_Drive(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Enable_Drive, (UInt64)value);
        }
    }
    
    
    public class PE_RR_NMTMessage : CanMessage<PE_RR_NMTMessage>
    {
        public PE_RR_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_RR_NMT;
        }
        public static readonly CanSignalType pe_rr_nmt = CanSignalTypes.PE_RR_NMT__pe_rr_nmt;
        public sbyte Getpe_rr_nmt()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(pe_rr_nmt);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_rr_nmt(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_rr_nmt, (UInt64)value);
        }
    }
    
    
    public class PE_RL_NMTMessage : CanMessage<PE_RL_NMTMessage>
    {
        public PE_RL_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_RL_NMT;
        }
        public static readonly CanSignalType pe_rl_nmt = CanSignalTypes.PE_RL_NMT__pe_rl_nmt;
        public sbyte Getpe_rl_nmt()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(pe_rl_nmt);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_rl_nmt(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_rl_nmt, (UInt64)value);
        }
    }
    
    
    public class PE_FR_NMTMessage : CanMessage<PE_FR_NMTMessage>
    {
        public PE_FR_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_FR_NMT;
        }
        public static readonly CanSignalType pe_fr_nmt = CanSignalTypes.PE_FR_NMT__pe_fr_nmt;
        public sbyte Getpe_fr_nmt()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(pe_fr_nmt);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_fr_nmt(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_fr_nmt, (UInt64)value);
        }
    }
    
    
    public class PE_FL_NMTMessage : CanMessage<PE_FL_NMTMessage>
    {
        public PE_FL_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_FL_NMT;
        }
        public static readonly CanSignalType pe_fl_nmt = CanSignalTypes.PE_FL_NMT__pe_fl_nmt;
        public sbyte Getpe_fl_nmt()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(pe_fl_nmt);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void Setpe_fl_nmt(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(pe_fl_nmt, (UInt64)value);
        }
    }
    
    
    public class PrechargeRequestMessage : CanMessage<PrechargeRequestMessage>
    {
        public PrechargeRequestMessage()
        {
            MessageType = CanMessageTypes.PrechargeRequest;
        }
    }
    

}
