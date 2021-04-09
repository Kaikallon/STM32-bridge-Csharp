using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanDB;

namespace testNS
{

    public static class CanMessageTypes
    {

        public static class Receiver
        {
            static void MessageReceived(CanMessage canMessage)
            {
                if (canMessage.ID == PE_FR_PDO_3_TX.ID)
                {

                }
                else if (canMessage.ID == AMS_MaxMinVoltages.ID)
                {
                    var specifiedMessage = (AMS_MaxMinVoltagesMessage)canMessage;
                    
                    foreach(var signal in AMS_MaxMinVoltages.Signals.Values)
                    {
                        signal.NotifyListeners(canMessage);
                    }
                }
            }
        }


        static CanMessageTypes()
        {
            AllCanMessageTypes.Add(TireTemp_FR4);
            AllCanMessageTypes.Add(TireTemp_FR3);
            AllCanMessageTypes.Add(TireTemp_FR2);
            AllCanMessageTypes.Add(TireTemp_FR1);
            AllCanMessageTypes.Add(TireTemp_FL4);
            AllCanMessageTypes.Add(TireTemp_FL3);
            AllCanMessageTypes.Add(TireTemp_FL2);
            AllCanMessageTypes.Add(TireTemp_FL1);
            AllCanMessageTypes.Add(TireTemp_RR4);
            AllCanMessageTypes.Add(TireTemp_RR3);
            AllCanMessageTypes.Add(TireTemp_RR2);
            AllCanMessageTypes.Add(TireTemp_RR1);
            AllCanMessageTypes.Add(TireTemp_RL4);
            AllCanMessageTypes.Add(TireTemp_RL3);
            AllCanMessageTypes.Add(TireTemp_RL2);
            AllCanMessageTypes.Add(TireTemp_RL1);
            AllCanMessageTypes.Add(RN_Temperatures2);
            AllCanMessageTypes.Add(FN_GPS_Pos);
            AllCanMessageTypes.Add(FN_TV);
            AllCanMessageTypes.Add(FN_Gyro);
            AllCanMessageTypes.Add(FN_Accelerometer);
            AllCanMessageTypes.Add(PE_RR_NMT);
            AllCanMessageTypes.Add(PE_RL_NMT);
            AllCanMessageTypes.Add(PE_FR_NMT);
            AllCanMessageTypes.Add(PE_FL_NMT);
            AllCanMessageTypes.Add(FN_Sensor_Status);
            AllCanMessageTypes.Add(AMS_Stack_Errors);
            AllCanMessageTypes.Add(IVT_Msg_Result_Wh);
            AllCanMessageTypes.Add(IVT_Msg_Result_W);
            AllCanMessageTypes.Add(IVT_Msg_Result_U3);
            AllCanMessageTypes.Add(IVT_Msg_Result_U2);
            AllCanMessageTypes.Add(IVT_Msg_Result_U1);
            AllCanMessageTypes.Add(IVT_Msg_Result_T);
            AllCanMessageTypes.Add(IVT_Msg_Result_I);
            AllCanMessageTypes.Add(IVT_Msg_Result_As);
            AllCanMessageTypes.Add(AMSClient_Status);
            AllCanMessageTypes.Add(AMS_Counters);
            AllCanMessageTypes.Add(AMS_Status);
            AllCanMessageTypes.Add(AMS_MaxMinTemperatures);
            AllCanMessageTypes.Add(AMS_MaxMinVoltages);
            AllCanMessageTypes.Add(AMS_Cell_Voltages);
            AllCanMessageTypes.Add(AMS_Cell_Temperatures);
            AllCanMessageTypes.Add(RN_Sensor_Status);
            AllCanMessageTypes.Add(FN_Sensors);
            AllCanMessageTypes.Add(FN_Temperatures);
            AllCanMessageTypes.Add(FN_Driver_Controls);
            AllCanMessageTypes.Add(RN_Sensors);
            AllCanMessageTypes.Add(RN_Errors_PE);
            AllCanMessageTypes.Add(RN_Temperatures);
            AllCanMessageTypes.Add(FN_Status);
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
            AllCanMessageTypes.Add(RN_Status);
            AllCanMessageTypes.Add(PE_RL_PDO_3_TX);
            AllCanMessageTypes.Add(PE_RL_PDO_2_TX);
            AllCanMessageTypes.Add(PE_RL_PDO_1_TX);
            AllCanMessageTypes.Add(RN_PE_RL_PDO_3_RX);
            AllCanMessageTypes.Add(RN_PE_RL_PDO_2_RX);
            AllCanMessageTypes.Add(RN_PE_RL_PDO_1_RX);
        }
        
        static List<CanMessageType> AllCanMessageTypes = new List<CanMessageType>();
        
        public static CanMessageType TireTemp_FR4 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FR4__TireTemp_FR16,
                CanSignalTypes.TireTemp_FR4__TireTemp_FR15,
                CanSignalTypes.TireTemp_FR4__TireTemp_FR14,
                CanSignalTypes.TireTemp_FR4__TireTemp_FR13,
            })
        {
            Comment       = "test2",
            DLC           =   8,
            ID            =   1207,
            Name          = "TireTemp_FR4",
            QualifiedName = "TireTemp_FR4",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FR3 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FR3__TireTemp_FR12,
                CanSignalTypes.TireTemp_FR3__TireTemp_FR11,
                CanSignalTypes.TireTemp_FR3__TireTemp_FR10,
                CanSignalTypes.TireTemp_FR3__TireTemp_FR9,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1206,
            Name          = "TireTemp_FR3",
            QualifiedName = "TireTemp_FR3",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FR2 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FR2__TireTemp_FR8,
                CanSignalTypes.TireTemp_FR2__TireTemp_FR7,
                CanSignalTypes.TireTemp_FR2__TireTemp_FR6,
                CanSignalTypes.TireTemp_FR2__TireTemp_FR5,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1205,
            Name          = "TireTemp_FR2",
            QualifiedName = "TireTemp_FR2",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FR1 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FR1__TireTemp_FR4,
                CanSignalTypes.TireTemp_FR1__TireTemp_FR3,
                CanSignalTypes.TireTemp_FR1__TireTemp_FR2,
                CanSignalTypes.TireTemp_FR1__TireTemp_FR1,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1204,
            Name          = "TireTemp_FR1",
            QualifiedName = "TireTemp_FR1",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FL4 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FL4__TireTemp_FL16,
                CanSignalTypes.TireTemp_FL4__TireTemp_FL15,
                CanSignalTypes.TireTemp_FL4__TireTemp_FL14,
                CanSignalTypes.TireTemp_FL4__TireTemp_FL13,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1203,
            Name          = "TireTemp_FL4",
            QualifiedName = "TireTemp_FL4",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FL3 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FL3__TireTemp_FL12,
                CanSignalTypes.TireTemp_FL3__TireTemp_FL11,
                CanSignalTypes.TireTemp_FL3__TireTemp_FL10,
                CanSignalTypes.TireTemp_FL3__TireTemp_FL9,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1202,
            Name          = "TireTemp_FL3",
            QualifiedName = "TireTemp_FL3",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FL2 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FL2__TireTemp_FL5,
                CanSignalTypes.TireTemp_FL2__TireTemp_FL6,
                CanSignalTypes.TireTemp_FL2__TireTemp_FL7,
                CanSignalTypes.TireTemp_FL2__TireTemp_FL8,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1201,
            Name          = "TireTemp_FL2",
            QualifiedName = "TireTemp_FL2",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_FL1 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_FL1__TireTemp_FL4,
                CanSignalTypes.TireTemp_FL1__TireTemp_FL3,
                CanSignalTypes.TireTemp_FL1__TireTemp_FL2,
                CanSignalTypes.TireTemp_FL1__TireTemp_FL1,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1200,
            Name          = "TireTemp_FL1",
            QualifiedName = "TireTemp_FL1",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RR4 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RR4__TireTemp_RR16,
                CanSignalTypes.TireTemp_RR4__TireTemp_RR15,
                CanSignalTypes.TireTemp_RR4__TireTemp_RR14,
                CanSignalTypes.TireTemp_RR4__TireTemp_RR13,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1215,
            Name          = "TireTemp_RR4",
            QualifiedName = "TireTemp_RR4",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RR3 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RR3__TireTemp_RR12,
                CanSignalTypes.TireTemp_RR3__TireTemp_RR11,
                CanSignalTypes.TireTemp_RR3__TireTemp_RR10,
                CanSignalTypes.TireTemp_RR3__TireTemp_RR9,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1214,
            Name          = "TireTemp_RR3",
            QualifiedName = "TireTemp_RR3",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RR2 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RR2__TireTemp_RR8,
                CanSignalTypes.TireTemp_RR2__TireTemp_RR7,
                CanSignalTypes.TireTemp_RR2__TireTemp_RR6,
                CanSignalTypes.TireTemp_RR2__TireTemp_RR5,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1213,
            Name          = "TireTemp_RR2",
            QualifiedName = "TireTemp_RR2",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RR1 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RR1__TireTemp_RR4,
                CanSignalTypes.TireTemp_RR1__TireTemp_RR3,
                CanSignalTypes.TireTemp_RR1__TireTemp_RR2,
                CanSignalTypes.TireTemp_RR1__TireTemp_RR1,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1212,
            Name          = "TireTemp_RR1",
            QualifiedName = "TireTemp_RR1",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RL4 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RL4__TireTemp_RL16,
                CanSignalTypes.TireTemp_RL4__TireTemp_RL15,
                CanSignalTypes.TireTemp_RL4__TireTemp_RL14,
                CanSignalTypes.TireTemp_RL4__TireTemp_RL13,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1211,
            Name          = "TireTemp_RL4",
            QualifiedName = "TireTemp_RL4",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RL3 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RL3__TireTemp_RL12,
                CanSignalTypes.TireTemp_RL3__TireTemp_RL11,
                CanSignalTypes.TireTemp_RL3__TireTemp_RL10,
                CanSignalTypes.TireTemp_RL3__TireTemp_RL9,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1210,
            Name          = "TireTemp_RL3",
            QualifiedName = "TireTemp_RL3",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RL2 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RL2__TireTemp_RL8,
                CanSignalTypes.TireTemp_RL2__TireTemp_RL7,
                CanSignalTypes.TireTemp_RL2__TireTemp_RL6,
                CanSignalTypes.TireTemp_RL2__TireTemp_RL5,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1209,
            Name          = "TireTemp_RL2",
            QualifiedName = "TireTemp_RL2",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType TireTemp_RL1 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.TireTemp_RL1__TireTemp_RL4,
                CanSignalTypes.TireTemp_RL1__TireTemp_RL3,
                CanSignalTypes.TireTemp_RL1__TireTemp_RL2,
                CanSignalTypes.TireTemp_RL1__TireTemp_RL1,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   1208,
            Name          = "TireTemp_RL1",
            QualifiedName = "TireTemp_RL1",
            SendingNode   = "Tire_Temp",
        };
        
        public static CanMessageType RN_Temperatures2 = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_Temperatures2__RN_Gearbox_Temp_RR,
                CanSignalTypes.RN_Temperatures2__RN_Gearbox_Temp_RL,
                CanSignalTypes.RN_Temperatures2__RN_Ambient_Outside,
                CanSignalTypes.RN_Temperatures2__RN_Ambient_Inside,
            })
        {
            Comment       = "",
            DLC           =   4,
            ID            =   181,
            Name          = "RN_Temperatures2",
            QualifiedName = "RN_Temperatures2",
            SendingNode   = "Rear_Node",
        };
        
        public static CanMessageType FN_GPS_Pos = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_GPS_Pos__FN_GPS_Flags,
                CanSignalTypes.FN_GPS_Pos__FN_GPS_yPos,
                CanSignalTypes.FN_GPS_Pos__FN_GPS_xPos,
            })
        {
            Comment       = "",
            DLC           =   5,
            ID            =   197,
            Name          = "FN_GPS_Pos",
            QualifiedName = "FN_GPS_Pos",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType FN_TV = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_TV__FN_TV_Knob,
                CanSignalTypes.FN_TV__FN_TC_Knob,
                CanSignalTypes.FN_TV__FN_Regen_Neutral,
                CanSignalTypes.FN_TV__FN_Regen_Knob,
                CanSignalTypes.FN_TV__FN_Regen_Div,
            })
        {
            Comment       = "",
            DLC           =   5,
            ID            =   206,
            Name          = "FN_TV",
            QualifiedName = "FN_TV",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType FN_Gyro = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Gyro__FN_GyroZ,
                CanSignalTypes.FN_Gyro__FN_GyroY,
                CanSignalTypes.FN_Gyro__FN_GyroX,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   199,
            Name          = "FN_Gyro",
            QualifiedName = "FN_Gyro",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType FN_Accelerometer = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Accelerometer__FN_AccZ,
                CanSignalTypes.FN_Accelerometer__FN_AccY,
                CanSignalTypes.FN_Accelerometer__FN_AccX,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   198,
            Name          = "FN_Accelerometer",
            QualifiedName = "FN_Accelerometer",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType PE_RR_NMT = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.PE_RR_NMT__PE_RR_NMT,
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
                CanSignalTypes.PE_RL_NMT__PE_RL_NMT,
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
                CanSignalTypes.PE_FR_NMT__PE_FR_NMT,
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
                CanSignalTypes.PE_FL_NMT__PE_FL_NMT,
            })
        {
            Comment       = "",
            DLC           =   1,
            ID            =   1798,
            Name          = "PE_FL_NMT",
            QualifiedName = "PE_FL_NMT",
            SendingNode   = "PE_FL",
        };
        
        public static CanMessageType FN_Sensor_Status = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Sensor_Status__FN_Sensor_Status,
            })
        {
            Comment       = "",
            DLC           =   4,
            ID            =   196,
            Name          = "FN_Sensor_Status",
            QualifiedName = "FN_Sensor_Status",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType AMS_Stack_Errors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack6,
                CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack5,
                CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack4,
                CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack3,
                CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack2,
                CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack1,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   161,
            Name          = "AMS_Stack_Errors",
            QualifiedName = "AMS_Stack_Errors",
            SendingNode   = "AMS",
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
        
        public static CanMessageType AMSClient_Status = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMSClient_Status__AMS_Client_Trigger_AMS,
                CanSignalTypes.AMSClient_Status__AMS_Client_Start_TS,
                CanSignalTypes.AMSClient_Status__AMS_Client_FN_Buttons,
                CanSignalTypes.AMSClient_Status__AMS_Client_Front_Node_Status,
                CanSignalTypes.AMSClient_Status__AMS_Client_Enable_Communication,
            })
        {
            Comment       = "",
            DLC           =   5,
            ID            =   241,
            Name          = "AMSClient_Status",
            QualifiedName = "AMSClient_Status",
            SendingNode   = "AMS_Client",
        };
        
        public static CanMessageType AMS_Counters = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_Counters__AMS_RestartCounter,
                CanSignalTypes.AMS_Counters__AMS_PrechargeCounter,
                CanSignalTypes.AMS_Counters__AMS_TSCounter,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   168,
            Name          = "AMS_Counters",
            QualifiedName = "AMS_Counters",
            SendingNode   = "AMS",
        };
        
        public static CanMessageType AMS_Status = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_Status__AMS_Watchdog,
                CanSignalTypes.AMS_Status__AMS_Precharge_Time,
                CanSignalTypes.AMS_Status__AMS_Accumulator_Errors,
                CanSignalTypes.AMS_Status__AMS_Accumulator_SoC,
                CanSignalTypes.AMS_Status__AMS_Status,
            })
        {
            Comment       = "",
            DLC           =   5,
            ID            =   175,
            Name          = "AMS_Status",
            QualifiedName = "AMS_Status",
            SendingNode   = "AMS",
        };
        
        public static CanMessageType AMS_MaxMinTemperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_MaxMinTemperatures__AMS_AvgTemp,
                CanSignalTypes.AMS_MaxMinTemperatures__AMS_MinTemp,
                CanSignalTypes.AMS_MaxMinTemperatures__AMS_MinTemp_Pos_Stack,
                CanSignalTypes.AMS_MaxMinTemperatures__AMS_MaxTemp,
                CanSignalTypes.AMS_MaxMinTemperatures__AMS_MaxTemp_Pos_Stack,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   167,
            Name          = "AMS_MaxMinTemperatures",
            QualifiedName = "AMS_MaxMinTemperatures",
            SendingNode   = "AMS",
        };
        
        public static CanMessageType AMS_MaxMinVoltages = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_MaxMinVoltages__AMS_AvgVoltage,
                CanSignalTypes.AMS_MaxMinVoltages__AMS_MinVoltage,
                CanSignalTypes.AMS_MaxMinVoltages__AMS_MinVoltage_Pos_Stack,
                CanSignalTypes.AMS_MaxMinVoltages__AMS_MaxVoltage,
                CanSignalTypes.AMS_MaxMinVoltages__AMS_MaxVoltage_Pos_Stack,
            })
        {
            Comment       = "",
            DLC           =   7,
            ID            =   166,
            Name          = "AMS_MaxMinVoltages",
            QualifiedName = "AMS_MaxMinVoltages",
            SendingNode   = "AMS",
        };
        
        public static CanMessageType AMS_Cell_Voltages = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage3,
                CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage2,
                CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage1,
                CanSignalTypes.AMS_Cell_Voltages__AMS_UV_OV_Flags,
                CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage_Pos_Stack,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   163,
            Name          = "AMS_Cell_Voltages",
            QualifiedName = "AMS_Cell_Voltages",
            SendingNode   = "AMS",
        };
        
        public static CanMessageType AMS_Cell_Temperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp3,
                CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp2,
                CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp1,
                CanSignalTypes.AMS_Cell_Temperatures__AMS_UT_OT_Flags,
                CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp_Pos_Stack,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   162,
            Name          = "AMS_Cell_Temperatures",
            QualifiedName = "AMS_Cell_Temperatures",
            SendingNode   = "AMS",
        };
        
        public static CanMessageType RN_Sensor_Status = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_Sensor_Status__RN_Sensor_Status,
            })
        {
            Comment       = "",
            DLC           =   4,
            ID            =   180,
            Name          = "RN_Sensor_Status",
            QualifiedName = "RN_Sensor_Status",
            SendingNode   = "Rear_Node",
        };
        
        public static CanMessageType FN_Sensors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Sensors__FN_Rotor_Object_temp_FL,
                CanSignalTypes.FN_Sensors__FN_Rotor_Object_temp_FR,
                CanSignalTypes.FN_Sensors__FN_Damper_FR,
                CanSignalTypes.FN_Sensors__FN_Damper_FL,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   195,
            Name          = "FN_Sensors",
            QualifiedName = "FN_Sensors",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType FN_Temperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Temperatures__FN_WaterR,
                CanSignalTypes.FN_Temperatures__FN_WaterL,
                CanSignalTypes.FN_Temperatures__FN_Gearbox_temp_FR,
                CanSignalTypes.FN_Temperatures__FN_Gearbox_temp_FL,
                CanSignalTypes.FN_Temperatures__FN_Brake_temp_FR,
                CanSignalTypes.FN_Temperatures__FN_Brake_temp_FL,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   194,
            Name          = "FN_Temperatures",
            QualifiedName = "FN_Temperatures",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType FN_Driver_Controls = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Driver_Controls__FN_Throttle,
                CanSignalTypes.FN_Driver_Controls__FN_Steering_Angle,
                CanSignalTypes.FN_Driver_Controls__FN_Brake_System,
                CanSignalTypes.FN_Driver_Controls__FN_Brake_Pedal,
                CanSignalTypes.FN_Driver_Controls__FN_APPS2,
                CanSignalTypes.FN_Driver_Controls__FN_APPS1,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   193,
            Name          = "FN_Driver_Controls",
            QualifiedName = "FN_Driver_Controls",
            SendingNode   = "Front_Node",
        };
        
        public static CanMessageType RN_Sensors = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_Sensors__RN_Rotor_Object_Temp_RR,
                CanSignalTypes.RN_Sensors__RN_Rotor_Object_Temp_RL,
                CanSignalTypes.RN_Sensors__RN_Damper_RR,
                CanSignalTypes.RN_Sensors__RN_Damper_RL,
            })
        {
            Comment       = "",
            DLC           =   6,
            ID            =   178,
            Name          = "RN_Sensors",
            QualifiedName = "RN_Sensors",
            SendingNode   = "Rear_Node",
        };
        
        public static CanMessageType RN_Errors_PE = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_Errors_PE__RN_Error_PE_RR,
                CanSignalTypes.RN_Errors_PE__RN_Error_PE_RL,
                CanSignalTypes.RN_Errors_PE__RN_Error_PE_FR,
                CanSignalTypes.RN_Errors_PE__RN_Error_PE_FL,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   179,
            Name          = "RN_Errors_PE",
            QualifiedName = "RN_Errors_PE",
            SendingNode   = "Rear_Node",
        };
        
        public static CanMessageType RN_Temperatures = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_Temperatures__RN_Water_Motor_RR,
                CanSignalTypes.RN_Temperatures__RN_Water_Motor_RL,
                CanSignalTypes.RN_Temperatures__RN_Water_Motor_Radiator,
                CanSignalTypes.RN_Temperatures__RN_Water_Motor_PE,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   177,
            Name          = "RN_Temperatures",
            QualifiedName = "RN_Temperatures",
            SendingNode   = "Rear_Node",
        };
        
        public static CanMessageType FN_Status = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.FN_Status__FN_DiffRear,
                CanSignalTypes.FN_Status__FN_DiffFront,
                CanSignalTypes.FN_Status__FN_Front_Torque_Scale,
                CanSignalTypes.FN_Status__FN_Speed_Limit,
                CanSignalTypes.FN_Status__FN_Max_Torque,
                CanSignalTypes.FN_Status__FN_Watchdog_Status,
                CanSignalTypes.FN_Status__FN_Status,
            })
        {
            Comment       = "",
            DLC           =   8,
            ID            =   207,
            Name          = "FN_Status",
            QualifiedName = "FN_Status",
            SendingNode   = "Front_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
        };
        
        public static CanMessageType RN_Status = new CanMessageType(new List<CanSignalType>{
                CanSignalTypes.RN_Status__RN_AMS_Safestate,
                CanSignalTypes.RN_Status__RN_Status,
                CanSignalTypes.RN_Status__RN_Watchdog_Status,
            })
        {
            Comment       = "",
            DLC           =   4,
            ID            =   191,
            Name          = "RN_Status",
            QualifiedName = "RN_Status",
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
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
            SendingNode   = "Rear_Node",
        };
        
    }

    public static class CanSignalTypes
    {
    
        static List<CanSignalType> AllCanSignalTypes = new List<CanSignalType>();
        
        static CanSignalTypes()
        {
            AllCanSignalTypes.Add(TireTemp_FR4__TireTemp_FR16); 
            AllCanSignalTypes.Add(TireTemp_FR4__TireTemp_FR15); 
            AllCanSignalTypes.Add(TireTemp_FR4__TireTemp_FR14); 
            AllCanSignalTypes.Add(TireTemp_FR4__TireTemp_FR13); 
            AllCanSignalTypes.Add(TireTemp_FR3__TireTemp_FR12); 
            AllCanSignalTypes.Add(TireTemp_FR3__TireTemp_FR11); 
            AllCanSignalTypes.Add(TireTemp_FR3__TireTemp_FR10); 
            AllCanSignalTypes.Add(TireTemp_FR3__TireTemp_FR9); 
            AllCanSignalTypes.Add(TireTemp_FR2__TireTemp_FR8); 
            AllCanSignalTypes.Add(TireTemp_FR2__TireTemp_FR7); 
            AllCanSignalTypes.Add(TireTemp_FR2__TireTemp_FR6); 
            AllCanSignalTypes.Add(TireTemp_FR2__TireTemp_FR5); 
            AllCanSignalTypes.Add(TireTemp_FR1__TireTemp_FR4); 
            AllCanSignalTypes.Add(TireTemp_FR1__TireTemp_FR3); 
            AllCanSignalTypes.Add(TireTemp_FR1__TireTemp_FR2); 
            AllCanSignalTypes.Add(TireTemp_FR1__TireTemp_FR1); 
            AllCanSignalTypes.Add(TireTemp_FL4__TireTemp_FL16); 
            AllCanSignalTypes.Add(TireTemp_FL4__TireTemp_FL15); 
            AllCanSignalTypes.Add(TireTemp_FL4__TireTemp_FL14); 
            AllCanSignalTypes.Add(TireTemp_FL4__TireTemp_FL13); 
            AllCanSignalTypes.Add(TireTemp_FL3__TireTemp_FL12); 
            AllCanSignalTypes.Add(TireTemp_FL3__TireTemp_FL11); 
            AllCanSignalTypes.Add(TireTemp_FL3__TireTemp_FL10); 
            AllCanSignalTypes.Add(TireTemp_FL3__TireTemp_FL9); 
            AllCanSignalTypes.Add(TireTemp_FL2__TireTemp_FL5); 
            AllCanSignalTypes.Add(TireTemp_FL2__TireTemp_FL6); 
            AllCanSignalTypes.Add(TireTemp_FL2__TireTemp_FL7); 
            AllCanSignalTypes.Add(TireTemp_FL2__TireTemp_FL8); 
            AllCanSignalTypes.Add(TireTemp_FL1__TireTemp_FL4); 
            AllCanSignalTypes.Add(TireTemp_FL1__TireTemp_FL3); 
            AllCanSignalTypes.Add(TireTemp_FL1__TireTemp_FL2); 
            AllCanSignalTypes.Add(TireTemp_FL1__TireTemp_FL1); 
            AllCanSignalTypes.Add(TireTemp_RR4__TireTemp_RR16); 
            AllCanSignalTypes.Add(TireTemp_RR4__TireTemp_RR15); 
            AllCanSignalTypes.Add(TireTemp_RR4__TireTemp_RR14); 
            AllCanSignalTypes.Add(TireTemp_RR4__TireTemp_RR13); 
            AllCanSignalTypes.Add(TireTemp_RR3__TireTemp_RR12); 
            AllCanSignalTypes.Add(TireTemp_RR3__TireTemp_RR11); 
            AllCanSignalTypes.Add(TireTemp_RR3__TireTemp_RR10); 
            AllCanSignalTypes.Add(TireTemp_RR3__TireTemp_RR9); 
            AllCanSignalTypes.Add(TireTemp_RR2__TireTemp_RR8); 
            AllCanSignalTypes.Add(TireTemp_RR2__TireTemp_RR7); 
            AllCanSignalTypes.Add(TireTemp_RR2__TireTemp_RR6); 
            AllCanSignalTypes.Add(TireTemp_RR2__TireTemp_RR5); 
            AllCanSignalTypes.Add(TireTemp_RR1__TireTemp_RR4); 
            AllCanSignalTypes.Add(TireTemp_RR1__TireTemp_RR3); 
            AllCanSignalTypes.Add(TireTemp_RR1__TireTemp_RR2); 
            AllCanSignalTypes.Add(TireTemp_RR1__TireTemp_RR1); 
            AllCanSignalTypes.Add(TireTemp_RL4__TireTemp_RL16); 
            AllCanSignalTypes.Add(TireTemp_RL4__TireTemp_RL15); 
            AllCanSignalTypes.Add(TireTemp_RL4__TireTemp_RL14); 
            AllCanSignalTypes.Add(TireTemp_RL4__TireTemp_RL13); 
            AllCanSignalTypes.Add(TireTemp_RL3__TireTemp_RL12); 
            AllCanSignalTypes.Add(TireTemp_RL3__TireTemp_RL11); 
            AllCanSignalTypes.Add(TireTemp_RL3__TireTemp_RL10); 
            AllCanSignalTypes.Add(TireTemp_RL3__TireTemp_RL9); 
            AllCanSignalTypes.Add(TireTemp_RL2__TireTemp_RL8); 
            AllCanSignalTypes.Add(TireTemp_RL2__TireTemp_RL7); 
            AllCanSignalTypes.Add(TireTemp_RL2__TireTemp_RL6); 
            AllCanSignalTypes.Add(TireTemp_RL2__TireTemp_RL5); 
            AllCanSignalTypes.Add(TireTemp_RL1__TireTemp_RL4); 
            AllCanSignalTypes.Add(TireTemp_RL1__TireTemp_RL3); 
            AllCanSignalTypes.Add(TireTemp_RL1__TireTemp_RL2); 
            AllCanSignalTypes.Add(TireTemp_RL1__TireTemp_RL1); 
            AllCanSignalTypes.Add(RN_Temperatures2__RN_Gearbox_Temp_RR); 
            AllCanSignalTypes.Add(RN_Temperatures2__RN_Gearbox_Temp_RL); 
            AllCanSignalTypes.Add(RN_Temperatures2__RN_Ambient_Outside); 
            AllCanSignalTypes.Add(RN_Temperatures2__RN_Ambient_Inside); 
            AllCanSignalTypes.Add(FN_GPS_Pos__FN_GPS_Flags); 
            AllCanSignalTypes.Add(FN_GPS_Pos__FN_GPS_yPos); 
            AllCanSignalTypes.Add(FN_GPS_Pos__FN_GPS_xPos); 
            AllCanSignalTypes.Add(FN_TV__FN_TV_Knob); 
            AllCanSignalTypes.Add(FN_TV__FN_TC_Knob); 
            AllCanSignalTypes.Add(FN_TV__FN_Regen_Neutral); 
            AllCanSignalTypes.Add(FN_TV__FN_Regen_Knob); 
            AllCanSignalTypes.Add(FN_TV__FN_Regen_Div); 
            AllCanSignalTypes.Add(FN_Gyro__FN_GyroZ); 
            AllCanSignalTypes.Add(FN_Gyro__FN_GyroY); 
            AllCanSignalTypes.Add(FN_Gyro__FN_GyroX); 
            AllCanSignalTypes.Add(FN_Accelerometer__FN_AccZ); 
            AllCanSignalTypes.Add(FN_Accelerometer__FN_AccY); 
            AllCanSignalTypes.Add(FN_Accelerometer__FN_AccX); 
            AllCanSignalTypes.Add(PE_RR_NMT__PE_RR_NMT); 
            AllCanSignalTypes.Add(PE_RL_NMT__PE_RL_NMT); 
            AllCanSignalTypes.Add(PE_FR_NMT__PE_FR_NMT); 
            AllCanSignalTypes.Add(PE_FL_NMT__PE_FL_NMT); 
            AllCanSignalTypes.Add(FN_Sensor_Status__FN_Sensor_Status); 
            AllCanSignalTypes.Add(AMS_Stack_Errors__AMS_Errors_Stack6); 
            AllCanSignalTypes.Add(AMS_Stack_Errors__AMS_Errors_Stack5); 
            AllCanSignalTypes.Add(AMS_Stack_Errors__AMS_Errors_Stack4); 
            AllCanSignalTypes.Add(AMS_Stack_Errors__AMS_Errors_Stack3); 
            AllCanSignalTypes.Add(AMS_Stack_Errors__AMS_Errors_Stack2); 
            AllCanSignalTypes.Add(AMS_Stack_Errors__AMS_Errors_Stack1); 
            AllCanSignalTypes.Add(IVT_Msg_Result_Wh__IVT_ResultState_And_MsgCount_Wh); 
            AllCanSignalTypes.Add(IVT_Msg_Result_Wh__IVT_Result_Wh); 
            AllCanSignalTypes.Add(IVT_Msg_Result_Wh__IVT_MuxID_Wh); 
            AllCanSignalTypes.Add(IVT_Msg_Result_W__IVT_ResultState_And_MsgCount_W); 
            AllCanSignalTypes.Add(IVT_Msg_Result_W__IVT_Result_W); 
            AllCanSignalTypes.Add(IVT_Msg_Result_W__IVT_MuxID_W); 
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
            AllCanSignalTypes.Add(AMSClient_Status__AMS_Client_Trigger_AMS); 
            AllCanSignalTypes.Add(AMSClient_Status__AMS_Client_Start_TS); 
            AllCanSignalTypes.Add(AMSClient_Status__AMS_Client_FN_Buttons); 
            AllCanSignalTypes.Add(AMSClient_Status__AMS_Client_Front_Node_Status); 
            AllCanSignalTypes.Add(AMSClient_Status__AMS_Client_Enable_Communication); 
            AllCanSignalTypes.Add(AMS_Counters__AMS_RestartCounter); 
            AllCanSignalTypes.Add(AMS_Counters__AMS_PrechargeCounter); 
            AllCanSignalTypes.Add(AMS_Counters__AMS_TSCounter); 
            AllCanSignalTypes.Add(AMS_Status__AMS_Watchdog); 
            AllCanSignalTypes.Add(AMS_Status__AMS_Precharge_Time); 
            AllCanSignalTypes.Add(AMS_Status__AMS_Accumulator_Errors); 
            AllCanSignalTypes.Add(AMS_Status__AMS_Accumulator_SoC); 
            AllCanSignalTypes.Add(AMS_Status__AMS_Status); 
            AllCanSignalTypes.Add(AMS_MaxMinTemperatures__AMS_AvgTemp); 
            AllCanSignalTypes.Add(AMS_MaxMinTemperatures__AMS_MinTemp); 
            AllCanSignalTypes.Add(AMS_MaxMinTemperatures__AMS_MinTemp_Pos_Stack); 
            AllCanSignalTypes.Add(AMS_MaxMinTemperatures__AMS_MaxTemp); 
            AllCanSignalTypes.Add(AMS_MaxMinTemperatures__AMS_MaxTemp_Pos_Stack); 
            AllCanSignalTypes.Add(AMS_MaxMinVoltages__AMS_AvgVoltage); 
            AllCanSignalTypes.Add(AMS_MaxMinVoltages__AMS_MinVoltage); 
            AllCanSignalTypes.Add(AMS_MaxMinVoltages__AMS_MinVoltage_Pos_Stack); 
            AllCanSignalTypes.Add(AMS_MaxMinVoltages__AMS_MaxVoltage); 
            AllCanSignalTypes.Add(AMS_MaxMinVoltages__AMS_MaxVoltage_Pos_Stack); 
            AllCanSignalTypes.Add(AMS_Cell_Voltages__AMS_Voltage3); 
            AllCanSignalTypes.Add(AMS_Cell_Voltages__AMS_Voltage2); 
            AllCanSignalTypes.Add(AMS_Cell_Voltages__AMS_Voltage1); 
            AllCanSignalTypes.Add(AMS_Cell_Voltages__AMS_UV_OV_Flags); 
            AllCanSignalTypes.Add(AMS_Cell_Voltages__AMS_Voltage_Pos_Stack); 
            AllCanSignalTypes.Add(AMS_Cell_Temperatures__AMS_Temp3); 
            AllCanSignalTypes.Add(AMS_Cell_Temperatures__AMS_Temp2); 
            AllCanSignalTypes.Add(AMS_Cell_Temperatures__AMS_Temp1); 
            AllCanSignalTypes.Add(AMS_Cell_Temperatures__AMS_UT_OT_Flags); 
            AllCanSignalTypes.Add(AMS_Cell_Temperatures__AMS_Temp_Pos_Stack); 
            AllCanSignalTypes.Add(RN_Sensor_Status__RN_Sensor_Status); 
            AllCanSignalTypes.Add(FN_Sensors__FN_Rotor_Object_temp_FL); 
            AllCanSignalTypes.Add(FN_Sensors__FN_Rotor_Object_temp_FR); 
            AllCanSignalTypes.Add(FN_Sensors__FN_Damper_FR); 
            AllCanSignalTypes.Add(FN_Sensors__FN_Damper_FL); 
            AllCanSignalTypes.Add(FN_Temperatures__FN_WaterR); 
            AllCanSignalTypes.Add(FN_Temperatures__FN_WaterL); 
            AllCanSignalTypes.Add(FN_Temperatures__FN_Gearbox_temp_FR); 
            AllCanSignalTypes.Add(FN_Temperatures__FN_Gearbox_temp_FL); 
            AllCanSignalTypes.Add(FN_Temperatures__FN_Brake_temp_FR); 
            AllCanSignalTypes.Add(FN_Temperatures__FN_Brake_temp_FL); 
            AllCanSignalTypes.Add(FN_Driver_Controls__FN_Throttle); 
            AllCanSignalTypes.Add(FN_Driver_Controls__FN_Steering_Angle); 
            AllCanSignalTypes.Add(FN_Driver_Controls__FN_Brake_System); 
            AllCanSignalTypes.Add(FN_Driver_Controls__FN_Brake_Pedal); 
            AllCanSignalTypes.Add(FN_Driver_Controls__FN_APPS2); 
            AllCanSignalTypes.Add(FN_Driver_Controls__FN_APPS1); 
            AllCanSignalTypes.Add(RN_Sensors__RN_Rotor_Object_Temp_RR); 
            AllCanSignalTypes.Add(RN_Sensors__RN_Rotor_Object_Temp_RL); 
            AllCanSignalTypes.Add(RN_Sensors__RN_Damper_RR); 
            AllCanSignalTypes.Add(RN_Sensors__RN_Damper_RL); 
            AllCanSignalTypes.Add(RN_Errors_PE__RN_Error_PE_RR); 
            AllCanSignalTypes.Add(RN_Errors_PE__RN_Error_PE_RL); 
            AllCanSignalTypes.Add(RN_Errors_PE__RN_Error_PE_FR); 
            AllCanSignalTypes.Add(RN_Errors_PE__RN_Error_PE_FL); 
            AllCanSignalTypes.Add(RN_Temperatures__RN_Water_Motor_RR); 
            AllCanSignalTypes.Add(RN_Temperatures__RN_Water_Motor_RL); 
            AllCanSignalTypes.Add(RN_Temperatures__RN_Water_Motor_Radiator); 
            AllCanSignalTypes.Add(RN_Temperatures__RN_Water_Motor_PE); 
            AllCanSignalTypes.Add(FN_Status__FN_DiffRear); 
            AllCanSignalTypes.Add(FN_Status__FN_DiffFront); 
            AllCanSignalTypes.Add(FN_Status__FN_Front_Torque_Scale); 
            AllCanSignalTypes.Add(FN_Status__FN_Speed_Limit); 
            AllCanSignalTypes.Add(FN_Status__FN_Max_Torque); 
            AllCanSignalTypes.Add(FN_Status__FN_Watchdog_Status); 
            AllCanSignalTypes.Add(FN_Status__FN_Status); 
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
            AllCanSignalTypes.Add(RN_Status__RN_AMS_Safestate); 
            AllCanSignalTypes.Add(RN_Status__RN_Status); 
            AllCanSignalTypes.Add(RN_Status__RN_Watchdog_Status); 
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
        }
        
        public static CanSignalType TireTemp_FR4__TireTemp_FR16 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "test3",
            Name          = "TireTemp_FR16",
            QualifiedName = "TireTemp_FR4.TireTemp_FR16",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR4__TireTemp_FR15 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FR15",
            QualifiedName = "TireTemp_FR4.TireTemp_FR15",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR4__TireTemp_FR14 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FR14",
            QualifiedName = "TireTemp_FR4.TireTemp_FR14",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR4__TireTemp_FR13 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FR13",
            QualifiedName = "TireTemp_FR4.TireTemp_FR13",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR3__TireTemp_FR12 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FR12",
            QualifiedName = "TireTemp_FR3.TireTemp_FR12",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR3__TireTemp_FR11 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FR11",
            QualifiedName = "TireTemp_FR3.TireTemp_FR11",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR3__TireTemp_FR10 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FR10",
            QualifiedName = "TireTemp_FR3.TireTemp_FR10",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR3__TireTemp_FR9 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FR9",
            QualifiedName = "TireTemp_FR3.TireTemp_FR9",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR2__TireTemp_FR8 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FR8",
            QualifiedName = "TireTemp_FR2.TireTemp_FR8",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR2__TireTemp_FR7 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FR7",
            QualifiedName = "TireTemp_FR2.TireTemp_FR7",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR2__TireTemp_FR6 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FR6",
            QualifiedName = "TireTemp_FR2.TireTemp_FR6",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR2__TireTemp_FR5 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FR5",
            QualifiedName = "TireTemp_FR2.TireTemp_FR5",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR1__TireTemp_FR4 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FR4",
            QualifiedName = "TireTemp_FR1.TireTemp_FR4",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR1__TireTemp_FR3 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FR3",
            QualifiedName = "TireTemp_FR1.TireTemp_FR3",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR1__TireTemp_FR2 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FR2",
            QualifiedName = "TireTemp_FR1.TireTemp_FR2",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FR1__TireTemp_FR1 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FR1",
            QualifiedName = "TireTemp_FR1.TireTemp_FR1",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL4__TireTemp_FL16 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FL16",
            QualifiedName = "TireTemp_FL4.TireTemp_FL16",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL4__TireTemp_FL15 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FL15",
            QualifiedName = "TireTemp_FL4.TireTemp_FL15",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL4__TireTemp_FL14 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FL14",
            QualifiedName = "TireTemp_FL4.TireTemp_FL14",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL4__TireTemp_FL13 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FL13",
            QualifiedName = "TireTemp_FL4.TireTemp_FL13",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL3__TireTemp_FL12 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FL12",
            QualifiedName = "TireTemp_FL3.TireTemp_FL12",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL3__TireTemp_FL11 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FL11",
            QualifiedName = "TireTemp_FL3.TireTemp_FL11",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL3__TireTemp_FL10 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FL10",
            QualifiedName = "TireTemp_FL3.TireTemp_FL10",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL3__TireTemp_FL9 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FL9",
            QualifiedName = "TireTemp_FL3.TireTemp_FL9",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL2__TireTemp_FL5 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FL5",
            QualifiedName = "TireTemp_FL2.TireTemp_FL5",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL2__TireTemp_FL6 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FL6",
            QualifiedName = "TireTemp_FL2.TireTemp_FL6",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL2__TireTemp_FL7 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FL7",
            QualifiedName = "TireTemp_FL2.TireTemp_FL7",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL2__TireTemp_FL8 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FL8",
            QualifiedName = "TireTemp_FL2.TireTemp_FL8",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL1__TireTemp_FL4 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_FL4",
            QualifiedName = "TireTemp_FL1.TireTemp_FL4",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL1__TireTemp_FL3 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_FL3",
            QualifiedName = "TireTemp_FL1.TireTemp_FL3",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL1__TireTemp_FL2 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_FL2",
            QualifiedName = "TireTemp_FL1.TireTemp_FL2",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_FL1__TireTemp_FL1 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_FL1",
            QualifiedName = "TireTemp_FL1.TireTemp_FL1",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR4__TireTemp_RR16 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RR16",
            QualifiedName = "TireTemp_RR4.TireTemp_RR16",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR4__TireTemp_RR15 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RR15",
            QualifiedName = "TireTemp_RR4.TireTemp_RR15",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR4__TireTemp_RR14 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RR14",
            QualifiedName = "TireTemp_RR4.TireTemp_RR14",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR4__TireTemp_RR13 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RR13",
            QualifiedName = "TireTemp_RR4.TireTemp_RR13",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR3__TireTemp_RR12 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RR12",
            QualifiedName = "TireTemp_RR3.TireTemp_RR12",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR3__TireTemp_RR11 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RR11",
            QualifiedName = "TireTemp_RR3.TireTemp_RR11",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR3__TireTemp_RR10 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RR10",
            QualifiedName = "TireTemp_RR3.TireTemp_RR10",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR3__TireTemp_RR9 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RR9",
            QualifiedName = "TireTemp_RR3.TireTemp_RR9",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR2__TireTemp_RR8 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RR8",
            QualifiedName = "TireTemp_RR2.TireTemp_RR8",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR2__TireTemp_RR7 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RR7",
            QualifiedName = "TireTemp_RR2.TireTemp_RR7",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR2__TireTemp_RR6 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RR6",
            QualifiedName = "TireTemp_RR2.TireTemp_RR6",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR2__TireTemp_RR5 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RR5",
            QualifiedName = "TireTemp_RR2.TireTemp_RR5",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR1__TireTemp_RR4 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RR4",
            QualifiedName = "TireTemp_RR1.TireTemp_RR4",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR1__TireTemp_RR3 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RR3",
            QualifiedName = "TireTemp_RR1.TireTemp_RR3",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR1__TireTemp_RR2 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RR2",
            QualifiedName = "TireTemp_RR1.TireTemp_RR2",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RR1__TireTemp_RR1 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RR1",
            QualifiedName = "TireTemp_RR1.TireTemp_RR1",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL4__TireTemp_RL16 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RL16",
            QualifiedName = "TireTemp_RL4.TireTemp_RL16",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL4__TireTemp_RL15 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RL15",
            QualifiedName = "TireTemp_RL4.TireTemp_RL15",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL4__TireTemp_RL14 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RL14",
            QualifiedName = "TireTemp_RL4.TireTemp_RL14",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL4__TireTemp_RL13 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RL13",
            QualifiedName = "TireTemp_RL4.TireTemp_RL13",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL3__TireTemp_RL12 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RL12",
            QualifiedName = "TireTemp_RL3.TireTemp_RL12",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL3__TireTemp_RL11 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RL11",
            QualifiedName = "TireTemp_RL3.TireTemp_RL11",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL3__TireTemp_RL10 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RL10",
            QualifiedName = "TireTemp_RL3.TireTemp_RL10",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL3__TireTemp_RL9 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RL9",
            QualifiedName = "TireTemp_RL3.TireTemp_RL9",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL2__TireTemp_RL8 = new CanSignalType(new List<string>{
            "Vector__XXX", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RL8",
            QualifiedName = "TireTemp_RL2.TireTemp_RL8",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL2__TireTemp_RL7 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RL7",
            QualifiedName = "TireTemp_RL2.TireTemp_RL7",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL2__TireTemp_RL6 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RL6",
            QualifiedName = "TireTemp_RL2.TireTemp_RL6",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL2__TireTemp_RL5 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RL5",
            QualifiedName = "TireTemp_RL2.TireTemp_RL5",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL1__TireTemp_RL4 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 55,
            Comment       = "",
            Name          = "TireTemp_RL4",
            QualifiedName = "TireTemp_RL1.TireTemp_RL4",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL1__TireTemp_RL3 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 39,
            Comment       = "",
            Name          = "TireTemp_RL3",
            QualifiedName = "TireTemp_RL1.TireTemp_RL3",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL1__TireTemp_RL2 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 23,
            Comment       = "",
            Name          = "TireTemp_RL2",
            QualifiedName = "TireTemp_RL1.TireTemp_RL2",
            Unit          = "",
        };
        
        public static CanSignalType TireTemp_RL1__TireTemp_RL1 = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Motorola,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 6453.5,
            MinValue      = -100,
            Offset        = -100,
            ScaleFactor   = 0.1,
            StartBit      = 7,
            Comment       = "",
            Name          = "TireTemp_RL1",
            QualifiedName = "TireTemp_RL1.TireTemp_RL1",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures2__RN_Gearbox_Temp_RR = new CanSignalType(new List<string>{
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
            StartBit      = 24,
            Comment       = "",
            Name          = "RN_Gearbox_Temp_RR",
            QualifiedName = "RN_Temperatures2.RN_Gearbox_Temp_RR",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures2__RN_Gearbox_Temp_RL = new CanSignalType(new List<string>{
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
            StartBit      = 16,
            Comment       = "",
            Name          = "RN_Gearbox_Temp_RL",
            QualifiedName = "RN_Temperatures2.RN_Gearbox_Temp_RL",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures2__RN_Ambient_Outside = new CanSignalType(new List<string>{
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
            StartBit      = 8,
            Comment       = "",
            Name          = "RN_Ambient_Outside",
            QualifiedName = "RN_Temperatures2.RN_Ambient_Outside",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures2__RN_Ambient_Inside = new CanSignalType(new List<string>{
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
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_Ambient_Inside",
            QualifiedName = "RN_Temperatures2.RN_Ambient_Inside",
            Unit          = "",
        };
        
        public static CanSignalType FN_GPS_Pos__FN_GPS_Flags = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            Name          = "FN_GPS_Flags",
            QualifiedName = "FN_GPS_Pos.FN_GPS_Flags",
            Unit          = "",
        };
        
        public static CanSignalType FN_GPS_Pos__FN_GPS_yPos = new CanSignalType(new List<string>{
            "Rear_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 16383.5,
            MinValue      = -16384,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 16,
            Comment       = "",
            Name          = "FN_GPS_yPos",
            QualifiedName = "FN_GPS_Pos.FN_GPS_yPos",
            Unit          = "",
        };
        
        public static CanSignalType FN_GPS_Pos__FN_GPS_xPos = new CanSignalType(new List<string>{
            "Rear_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Signed,
            Length        = 16,
            MaxValue      = 16383.5,
            MinValue      = -16384,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 0,
            Comment       = "",
            Name          = "FN_GPS_xPos",
            QualifiedName = "FN_GPS_Pos.FN_GPS_xPos",
            Unit          = "",
        };
        
        public static CanSignalType FN_TV__FN_TV_Knob = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 25.5,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.1,
            StartBit      = 8,
            Comment       = "",
            Name          = "FN_TV_Knob",
            QualifiedName = "FN_TV.FN_TV_Knob",
            Unit          = "",
        };
        
        public static CanSignalType FN_TV__FN_TC_Knob = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 2.55,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 16,
            Comment       = "",
            Name          = "FN_TC_Knob",
            QualifiedName = "FN_TV.FN_TC_Knob",
            Unit          = "",
        };
        
        public static CanSignalType FN_TV__FN_Regen_Neutral = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 2.55,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 32,
            Comment       = "",
            Name          = "FN_Regen_Neutral",
            QualifiedName = "FN_TV.FN_Regen_Neutral",
            Unit          = "",
        };
        
        public static CanSignalType FN_TV__FN_Regen_Knob = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 2.55,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 0,
            Comment       = "",
            Name          = "FN_Regen_Knob",
            QualifiedName = "FN_TV.FN_Regen_Knob",
            Unit          = "",
        };
        
        public static CanSignalType FN_TV__FN_Regen_Div = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 2.55,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.01,
            StartBit      = 24,
            Comment       = "",
            Name          = "FN_Regen_Div",
            QualifiedName = "FN_TV.FN_Regen_Div",
            Unit          = "",
        };
        
        public static CanSignalType FN_Gyro__FN_GyroZ = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_GyroZ",
            QualifiedName = "FN_Gyro.FN_GyroZ",
            Unit          = "",
        };
        
        public static CanSignalType FN_Gyro__FN_GyroY = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_GyroY",
            QualifiedName = "FN_Gyro.FN_GyroY",
            Unit          = "",
        };
        
        public static CanSignalType FN_Gyro__FN_GyroX = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_GyroX",
            QualifiedName = "FN_Gyro.FN_GyroX",
            Unit          = "",
        };
        
        public static CanSignalType FN_Accelerometer__FN_AccZ = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_AccZ",
            QualifiedName = "FN_Accelerometer.FN_AccZ",
            Unit          = "",
        };
        
        public static CanSignalType FN_Accelerometer__FN_AccY = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_AccY",
            QualifiedName = "FN_Accelerometer.FN_AccY",
            Unit          = "",
        };
        
        public static CanSignalType FN_Accelerometer__FN_AccX = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_AccX",
            QualifiedName = "FN_Accelerometer.FN_AccX",
            Unit          = "",
        };
        
        public static CanSignalType PE_RR_NMT__PE_RR_NMT = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            Name          = "PE_RR_NMT",
            QualifiedName = "PE_RR_NMT.PE_RR_NMT",
            Unit          = "",
        };
        
        public static CanSignalType PE_RL_NMT__PE_RL_NMT = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            Name          = "PE_RL_NMT",
            QualifiedName = "PE_RL_NMT.PE_RL_NMT",
            Unit          = "",
        };
        
        public static CanSignalType PE_FR_NMT__PE_FR_NMT = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            Name          = "PE_FR_NMT",
            QualifiedName = "PE_FR_NMT.PE_FR_NMT",
            Unit          = "",
        };
        
        public static CanSignalType PE_FL_NMT__PE_FL_NMT = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            Name          = "PE_FL_NMT",
            QualifiedName = "PE_FL_NMT.PE_FL_NMT",
            Unit          = "",
        };
        
        public static CanSignalType FN_Sensor_Status__FN_Sensor_Status = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 32,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "FN_Sensor_Status",
            QualifiedName = "FN_Sensor_Status.FN_Sensor_Status",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Stack_Errors__AMS_Errors_Stack6 = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Errors_Stack6",
            QualifiedName = "AMS_Stack_Errors.AMS_Errors_Stack6",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Stack_Errors__AMS_Errors_Stack5 = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Errors_Stack5",
            QualifiedName = "AMS_Stack_Errors.AMS_Errors_Stack5",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Stack_Errors__AMS_Errors_Stack4 = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Errors_Stack4",
            QualifiedName = "AMS_Stack_Errors.AMS_Errors_Stack4",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Stack_Errors__AMS_Errors_Stack3 = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Errors_Stack3",
            QualifiedName = "AMS_Stack_Errors.AMS_Errors_Stack3",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Stack_Errors__AMS_Errors_Stack2 = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Errors_Stack2",
            QualifiedName = "AMS_Stack_Errors.AMS_Errors_Stack2",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Stack_Errors__AMS_Errors_Stack1 = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Errors_Stack1",
            QualifiedName = "AMS_Stack_Errors.AMS_Errors_Stack1",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_Wh__IVT_ResultState_And_MsgCount_Wh = new CanSignalType(new List<string>{
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
        
        public static CanSignalType IVT_Msg_Result_U3__IVT_ResultState_And_MsgCount_U3 = new CanSignalType(new List<string>{
            "AMS", 
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
            "AMS", 
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
            Name          = "IVT_Result_U3",
            QualifiedName = "IVT_Msg_Result_U3.IVT_Result_U3",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U3__IVT_MuxID_U3 = new CanSignalType(new List<string>{
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            Name          = "IVT_Result_U2",
            QualifiedName = "IVT_Msg_Result_U2.IVT_Result_U2",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U2__IVT_MuxID_U2 = new CanSignalType(new List<string>{
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            Name          = "IVT_Result_U1",
            QualifiedName = "IVT_Msg_Result_U1.IVT_Result_U1",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_U1__IVT_MuxID_U1 = new CanSignalType(new List<string>{
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            Name          = "IVT_Result_I",
            QualifiedName = "IVT_Msg_Result_I.IVT_Result_I",
            Unit          = "",
        };
        
        public static CanSignalType IVT_Msg_Result_I__IVT_MuxID_I = new CanSignalType(new List<string>{
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
            "AMS", 
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
        
        public static CanSignalType AMSClient_Status__AMS_Client_Trigger_AMS = new CanSignalType(new List<string>{
            "AMS", 
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
            Name          = "AMS_Client_Trigger_AMS",
            QualifiedName = "AMSClient_Status.AMS_Client_Trigger_AMS",
            Unit          = "",
        };
        
        public static CanSignalType AMSClient_Status__AMS_Client_Start_TS = new CanSignalType(new List<string>{
            "AMS", 
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
            Name          = "AMS_Client_Start_TS",
            QualifiedName = "AMSClient_Status.AMS_Client_Start_TS",
            Unit          = "",
        };
        
        public static CanSignalType AMSClient_Status__AMS_Client_FN_Buttons = new CanSignalType(new List<string>{
            "AMS", 
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
            Name          = "AMS_Client_FN_Buttons",
            QualifiedName = "AMSClient_Status.AMS_Client_FN_Buttons",
            Unit          = "",
        };
        
        public static CanSignalType AMSClient_Status__AMS_Client_Front_Node_Status = new CanSignalType(new List<string>{
            "AMS", 
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
            Name          = "AMS_Client_Front_Node_Status",
            QualifiedName = "AMSClient_Status.AMS_Client_Front_Node_Status",
            Unit          = "",
        };
        
        public static CanSignalType AMSClient_Status__AMS_Client_Enable_Communication = new CanSignalType(new List<string>{
            "AMS", 
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
            Name          = "AMS_Client_Enable_Communication",
            QualifiedName = "AMSClient_Status.AMS_Client_Enable_Communication",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Counters__AMS_RestartCounter = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 32,
            Comment       = "",
            Name          = "AMS_RestartCounter",
            QualifiedName = "AMS_Counters.AMS_RestartCounter",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Counters__AMS_PrechargeCounter = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "AMS_PrechargeCounter",
            QualifiedName = "AMS_Counters.AMS_PrechargeCounter",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Counters__AMS_TSCounter = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "AMS_TSCounter",
            QualifiedName = "AMS_Counters.AMS_TSCounter",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Status__AMS_Watchdog = new CanSignalType(new List<string>{
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
            Name          = "AMS_Watchdog",
            QualifiedName = "AMS_Status.AMS_Watchdog",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Status__AMS_Precharge_Time = new CanSignalType(new List<string>{
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
            Name          = "AMS_Precharge_Time",
            QualifiedName = "AMS_Status.AMS_Precharge_Time",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Status__AMS_Accumulator_Errors = new CanSignalType(new List<string>{
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
            Name          = "AMS_Accumulator_Errors",
            QualifiedName = "AMS_Status.AMS_Accumulator_Errors",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Status__AMS_Accumulator_SoC = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Accumulator_SoC",
            QualifiedName = "AMS_Status.AMS_Accumulator_SoC",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Status__AMS_Status = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_Status",
            QualifiedName = "AMS_Status.AMS_Status",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinTemperatures__AMS_AvgTemp = new CanSignalType(new List<string>{
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
            Name          = "AMS_AvgTemp",
            QualifiedName = "AMS_MaxMinTemperatures.AMS_AvgTemp",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinTemperatures__AMS_MinTemp = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MinTemp",
            QualifiedName = "AMS_MaxMinTemperatures.AMS_MinTemp",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinTemperatures__AMS_MinTemp_Pos_Stack = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MinTemp_Pos_Stack",
            QualifiedName = "AMS_MaxMinTemperatures.AMS_MinTemp_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinTemperatures__AMS_MaxTemp = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MaxTemp",
            QualifiedName = "AMS_MaxMinTemperatures.AMS_MaxTemp",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinTemperatures__AMS_MaxTemp_Pos_Stack = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MaxTemp_Pos_Stack",
            QualifiedName = "AMS_MaxMinTemperatures.AMS_MaxTemp_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinVoltages__AMS_AvgVoltage = new CanSignalType(new List<string>{
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
            Name          = "AMS_AvgVoltage",
            QualifiedName = "AMS_MaxMinVoltages.AMS_AvgVoltage",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinVoltages__AMS_MinVoltage = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MinVoltage",
            QualifiedName = "AMS_MaxMinVoltages.AMS_MinVoltage",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinVoltages__AMS_MinVoltage_Pos_Stack = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MinVoltage_Pos_Stack",
            QualifiedName = "AMS_MaxMinVoltages.AMS_MinVoltage_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinVoltages__AMS_MaxVoltage = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MaxVoltage",
            QualifiedName = "AMS_MaxMinVoltages.AMS_MaxVoltage",
            Unit          = "",
        };
        
        public static CanSignalType AMS_MaxMinVoltages__AMS_MaxVoltage_Pos_Stack = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "AMS_MaxVoltage_Pos_Stack",
            QualifiedName = "AMS_MaxMinVoltages.AMS_MaxVoltage_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Voltages__AMS_Voltage3 = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Name          = "AMS_Voltage3",
            QualifiedName = "AMS_Cell_Voltages.AMS_Voltage3",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Voltages__AMS_Voltage2 = new CanSignalType(new List<string>{
            "AMS_Client", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 65.535,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.001,
            StartBit      = 32,
            Comment       = "",
            Name          = "AMS_Voltage2",
            QualifiedName = "AMS_Cell_Voltages.AMS_Voltage2",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Voltages__AMS_Voltage1 = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Name          = "AMS_Voltage1",
            QualifiedName = "AMS_Cell_Voltages.AMS_Voltage1",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Voltages__AMS_UV_OV_Flags = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Comment       = "LSB",
            Name          = "AMS_UV_OV_Flags",
            QualifiedName = "AMS_Cell_Voltages.AMS_UV_OV_Flags",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Voltages__AMS_Voltage_Pos_Stack = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Comment       = "4MSB",
            Name          = "AMS_Voltage_Pos_Stack",
            QualifiedName = "AMS_Cell_Voltages.AMS_Voltage_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Temperatures__AMS_Temp3 = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Name          = "AMS_Temp3",
            QualifiedName = "AMS_Cell_Temperatures.AMS_Temp3",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Temperatures__AMS_Temp2 = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Name          = "AMS_Temp2",
            QualifiedName = "AMS_Cell_Temperatures.AMS_Temp2",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Temperatures__AMS_Temp1 = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Name          = "AMS_Temp1",
            QualifiedName = "AMS_Cell_Temperatures.AMS_Temp1",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Temperatures__AMS_UT_OT_Flags = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Comment       = "LSB",
            Name          = "AMS_UT_OT_Flags",
            QualifiedName = "AMS_Cell_Temperatures.AMS_UT_OT_Flags",
            Unit          = "",
        };
        
        public static CanSignalType AMS_Cell_Temperatures__AMS_Temp_Pos_Stack = new CanSignalType(new List<string>{
            "AMS_Client", 
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
            Comment       = "4MSB",
            Name          = "AMS_Temp_Pos_Stack",
            QualifiedName = "AMS_Cell_Temperatures.AMS_Temp_Pos_Stack",
            Unit          = "",
        };
        
        public static CanSignalType RN_Sensor_Status__RN_Sensor_Status = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 32,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 0,
            Comment       = "",
            Name          = "RN_Sensor_Status",
            QualifiedName = "RN_Sensor_Status.RN_Sensor_Status",
            Unit          = "",
        };
        
        public static CanSignalType FN_Sensors__FN_Rotor_Object_temp_FL = new CanSignalType(new List<string>{
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
            Name          = "FN_Rotor_Object_temp_FL",
            QualifiedName = "FN_Sensors.FN_Rotor_Object_temp_FL",
            Unit          = "",
        };
        
        public static CanSignalType FN_Sensors__FN_Rotor_Object_temp_FR = new CanSignalType(new List<string>{
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
            Name          = "FN_Rotor_Object_temp_FR",
            QualifiedName = "FN_Sensors.FN_Rotor_Object_temp_FR",
            Unit          = "",
        };
        
        public static CanSignalType FN_Sensors__FN_Damper_FR = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Damper_FR",
            QualifiedName = "FN_Sensors.FN_Damper_FR",
            Unit          = "",
        };
        
        public static CanSignalType FN_Sensors__FN_Damper_FL = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Damper_FL",
            QualifiedName = "FN_Sensors.FN_Damper_FL",
            Unit          = "",
        };
        
        public static CanSignalType FN_Temperatures__FN_WaterR = new CanSignalType(new List<string>{
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
            Name          = "FN_WaterR",
            QualifiedName = "FN_Temperatures.FN_WaterR",
            Unit          = "",
        };
        
        public static CanSignalType FN_Temperatures__FN_WaterL = new CanSignalType(new List<string>{
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
            Name          = "FN_WaterL",
            QualifiedName = "FN_Temperatures.FN_WaterL",
            Unit          = "",
        };
        
        public static CanSignalType FN_Temperatures__FN_Gearbox_temp_FR = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Gearbox_temp_FR",
            QualifiedName = "FN_Temperatures.FN_Gearbox_temp_FR",
            Unit          = "",
        };
        
        public static CanSignalType FN_Temperatures__FN_Gearbox_temp_FL = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Gearbox_temp_FL",
            QualifiedName = "FN_Temperatures.FN_Gearbox_temp_FL",
            Unit          = "",
        };
        
        public static CanSignalType FN_Temperatures__FN_Brake_temp_FR = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Brake_temp_FR",
            QualifiedName = "FN_Temperatures.FN_Brake_temp_FR",
            Unit          = "",
        };
        
        public static CanSignalType FN_Temperatures__FN_Brake_temp_FL = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Brake_temp_FL",
            QualifiedName = "FN_Temperatures.FN_Brake_temp_FL",
            Unit          = "",
        };
        
        public static CanSignalType FN_Driver_Controls__FN_Throttle = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Throttle",
            QualifiedName = "FN_Driver_Controls.FN_Throttle",
            Unit          = "",
        };
        
        public static CanSignalType FN_Driver_Controls__FN_Steering_Angle = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Steering_Angle",
            QualifiedName = "FN_Driver_Controls.FN_Steering_Angle",
            Unit          = "",
        };
        
        public static CanSignalType FN_Driver_Controls__FN_Brake_System = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            QualifiedName = "FN_Driver_Controls.FN_Brake_System",
            Unit          = "",
        };
        
        public static CanSignalType FN_Driver_Controls__FN_Brake_Pedal = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            QualifiedName = "FN_Driver_Controls.FN_Brake_Pedal",
            Unit          = "",
        };
        
        public static CanSignalType FN_Driver_Controls__FN_APPS2 = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_APPS2",
            QualifiedName = "FN_Driver_Controls.FN_APPS2",
            Unit          = "",
        };
        
        public static CanSignalType FN_Driver_Controls__FN_APPS1 = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_APPS1",
            QualifiedName = "FN_Driver_Controls.FN_APPS1",
            Unit          = "",
        };
        
        public static CanSignalType RN_Sensors__RN_Rotor_Object_Temp_RR = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Rotor_Object_Temp_RR",
            QualifiedName = "RN_Sensors.RN_Rotor_Object_Temp_RR",
            Unit          = "",
        };
        
        public static CanSignalType RN_Sensors__RN_Rotor_Object_Temp_RL = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Rotor_Object_Temp_RL",
            QualifiedName = "RN_Sensors.RN_Rotor_Object_Temp_RL",
            Unit          = "",
        };
        
        public static CanSignalType RN_Sensors__RN_Damper_RR = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Damper_RR",
            QualifiedName = "RN_Sensors.RN_Damper_RR",
            Unit          = "",
        };
        
        public static CanSignalType RN_Sensors__RN_Damper_RL = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Damper_RL",
            QualifiedName = "RN_Sensors.RN_Damper_RL",
            Unit          = "",
        };
        
        public static CanSignalType RN_Errors_PE__RN_Error_PE_RR = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Error_PE_RR",
            QualifiedName = "RN_Errors_PE.RN_Error_PE_RR",
            Unit          = "",
        };
        
        public static CanSignalType RN_Errors_PE__RN_Error_PE_RL = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Error_PE_RL",
            QualifiedName = "RN_Errors_PE.RN_Error_PE_RL",
            Unit          = "",
        };
        
        public static CanSignalType RN_Errors_PE__RN_Error_PE_FR = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Error_PE_FR",
            QualifiedName = "RN_Errors_PE.RN_Error_PE_FR",
            Unit          = "",
        };
        
        public static CanSignalType RN_Errors_PE__RN_Error_PE_FL = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "RN_Error_PE_FL",
            QualifiedName = "RN_Errors_PE.RN_Error_PE_FL",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures__RN_Water_Motor_RR = new CanSignalType(new List<string>{
            "Front_Node", 
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
            QualifiedName = "RN_Temperatures.RN_Water_Motor_RR",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures__RN_Water_Motor_RL = new CanSignalType(new List<string>{
            "Front_Node", 
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
            QualifiedName = "RN_Temperatures.RN_Water_Motor_RL",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures__RN_Water_Motor_Radiator = new CanSignalType(new List<string>{
            "Front_Node", 
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
            QualifiedName = "RN_Temperatures.RN_Water_Motor_Radiator",
            Unit          = "",
        };
        
        public static CanSignalType RN_Temperatures__RN_Water_Motor_PE = new CanSignalType(new List<string>{
            "Front_Node", 
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
            QualifiedName = "RN_Temperatures.RN_Water_Motor_PE",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_DiffRear = new CanSignalType(new List<string>{
            "Rear_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 127.5,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 56,
            Comment       = "",
            Name          = "FN_DiffRear",
            QualifiedName = "FN_Status.FN_DiffRear",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_DiffFront = new CanSignalType(new List<string>{
            "Rear_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 127.5,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 48,
            Comment       = "",
            Name          = "FN_DiffFront",
            QualifiedName = "FN_Status.FN_DiffFront",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_Front_Torque_Scale = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 102,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 40,
            Comment       = "",
            Name          = "FN_Front_Torque_Scale",
            QualifiedName = "FN_Status.FN_Front_Torque_Scale",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_Speed_Limit = new CanSignalType(new List<string>{
            "Front_Node", 
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
            Name          = "FN_Speed_Limit",
            QualifiedName = "FN_Status.FN_Speed_Limit",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_Max_Torque = new CanSignalType(new List<string>{
            "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 8,
            MaxValue      = 102,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 0.5,
            StartBit      = 24,
            Comment       = "",
            Name          = "FN_Max_Torque",
            QualifiedName = "FN_Status.FN_Max_Torque",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_Watchdog_Status = new CanSignalType(new List<string>{
            "Front_Node", "Rear_Node", 
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
            Name          = "FN_Watchdog_Status",
            QualifiedName = "FN_Status.FN_Watchdog_Status",
            Unit          = "",
        };
        
        public static CanSignalType FN_Status__FN_Status = new CanSignalType(new List<string>{
            "Front_Node", "AMS", "Rear_Node", 
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
            Name          = "FN_Status",
            QualifiedName = "FN_Status.FN_Status",
            Unit          = "",
        };
        
        public static CanSignalType PE_FR_PDO_3_TX__PE_FR_Iq = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
        
        public static CanSignalType RN_Status__RN_AMS_Safestate = new CanSignalType(new List<string>{
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
            Name          = "RN_AMS_Safestate",
            QualifiedName = "RN_Status.RN_AMS_Safestate",
            Unit          = "",
        };
        
        public static CanSignalType RN_Status__RN_Status = new CanSignalType(new List<string>{
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
            StartBit      = 0,
            Comment       = "DRS,",
            Name          = "RN_Status",
            QualifiedName = "RN_Status.RN_Status",
            Unit          = "",
        };
        
        public static CanSignalType RN_Status__RN_Watchdog_Status = new CanSignalType(new List<string>{
            "AMS", "Front_Node", 
        })
        {
            Encoding      = SignalEncoding.Intel,
            Type          = SignalType.Unsigned,
            Length        = 16,
            MaxValue      = 0,
            MinValue      = 0,
            Offset        = 0,
            ScaleFactor   = 1,
            StartBit      = 16,
            Comment       = "",
            Name          = "RN_Watchdog_Status",
            QualifiedName = "RN_Status.RN_Watchdog_Status",
            Unit          = "",
        };
        
        public static CanSignalType PE_RL_PDO_3_TX__PE_RL_Iq = new CanSignalType(new List<string>{
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            "Rear_Node", 
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
            Type          = SignalType.Double,
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
            Type          = SignalType.Float,
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
        
    }

    
    public class TireTemp_FR4Message : CanMessage
    {
        public TireTemp_FR4Message()
        {
            MessageType = CanMessageTypes.TireTemp_FR4;
        }
        public static readonly CanSignalType TireTemp_FR16 = CanSignalTypes.TireTemp_FR4__TireTemp_FR16;
        public UInt16 GetTireTemp_FR16()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR16);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR16(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR16, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR15 = CanSignalTypes.TireTemp_FR4__TireTemp_FR15;
        public UInt16 GetTireTemp_FR15()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR15);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR15(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR15, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR14 = CanSignalTypes.TireTemp_FR4__TireTemp_FR14;
        public UInt16 GetTireTemp_FR14()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR14);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR14(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR14, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR13 = CanSignalTypes.TireTemp_FR4__TireTemp_FR13;
        public UInt16 GetTireTemp_FR13()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR13);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR13(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR13, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FR3Message : CanMessage
    {
        public TireTemp_FR3Message()
        {
            MessageType = CanMessageTypes.TireTemp_FR3;
        }
        public static readonly CanSignalType TireTemp_FR12 = CanSignalTypes.TireTemp_FR3__TireTemp_FR12;
        public UInt16 GetTireTemp_FR12()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR12);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR12(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR12, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR11 = CanSignalTypes.TireTemp_FR3__TireTemp_FR11;
        public UInt16 GetTireTemp_FR11()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR11);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR11(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR11, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR10 = CanSignalTypes.TireTemp_FR3__TireTemp_FR10;
        public UInt16 GetTireTemp_FR10()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR10);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR10(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR10, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR9 = CanSignalTypes.TireTemp_FR3__TireTemp_FR9;
        public UInt16 GetTireTemp_FR9()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR9);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR9(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR9, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FR2Message : CanMessage
    {
        public TireTemp_FR2Message()
        {
            MessageType = CanMessageTypes.TireTemp_FR2;
        }
        public static readonly CanSignalType TireTemp_FR8 = CanSignalTypes.TireTemp_FR2__TireTemp_FR8;
        public UInt16 GetTireTemp_FR8()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR8);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR8(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR8, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR7 = CanSignalTypes.TireTemp_FR2__TireTemp_FR7;
        public UInt16 GetTireTemp_FR7()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR7);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR7(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR7, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR6 = CanSignalTypes.TireTemp_FR2__TireTemp_FR6;
        public UInt16 GetTireTemp_FR6()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR6);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR6(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR6, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR5 = CanSignalTypes.TireTemp_FR2__TireTemp_FR5;
        public UInt16 GetTireTemp_FR5()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR5);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR5(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR5, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FR1Message : CanMessage
    {
        public TireTemp_FR1Message()
        {
            MessageType = CanMessageTypes.TireTemp_FR1;
        }
        public static readonly CanSignalType TireTemp_FR4 = CanSignalTypes.TireTemp_FR1__TireTemp_FR4;
        public UInt16 GetTireTemp_FR4()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR4);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR4(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR4, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR3 = CanSignalTypes.TireTemp_FR1__TireTemp_FR3;
        public UInt16 GetTireTemp_FR3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR3);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR3, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR2 = CanSignalTypes.TireTemp_FR1__TireTemp_FR2;
        public UInt16 GetTireTemp_FR2()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR2);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR2(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR2, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FR1 = CanSignalTypes.TireTemp_FR1__TireTemp_FR1;
        public UInt16 GetTireTemp_FR1()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FR1);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FR1(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FR1, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FL4Message : CanMessage
    {
        public TireTemp_FL4Message()
        {
            MessageType = CanMessageTypes.TireTemp_FL4;
        }
        public static readonly CanSignalType TireTemp_FL16 = CanSignalTypes.TireTemp_FL4__TireTemp_FL16;
        public UInt16 GetTireTemp_FL16()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL16);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL16(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL16, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL15 = CanSignalTypes.TireTemp_FL4__TireTemp_FL15;
        public UInt16 GetTireTemp_FL15()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL15);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL15(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL15, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL14 = CanSignalTypes.TireTemp_FL4__TireTemp_FL14;
        public UInt16 GetTireTemp_FL14()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL14);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL14(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL14, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL13 = CanSignalTypes.TireTemp_FL4__TireTemp_FL13;
        public UInt16 GetTireTemp_FL13()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL13);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL13(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL13, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FL3Message : CanMessage
    {
        public TireTemp_FL3Message()
        {
            MessageType = CanMessageTypes.TireTemp_FL3;
        }
        public static readonly CanSignalType TireTemp_FL12 = CanSignalTypes.TireTemp_FL3__TireTemp_FL12;
        public UInt16 GetTireTemp_FL12()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL12);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL12(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL12, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL11 = CanSignalTypes.TireTemp_FL3__TireTemp_FL11;
        public UInt16 GetTireTemp_FL11()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL11);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL11(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL11, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL10 = CanSignalTypes.TireTemp_FL3__TireTemp_FL10;
        public UInt16 GetTireTemp_FL10()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL10);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL10(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL10, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL9 = CanSignalTypes.TireTemp_FL3__TireTemp_FL9;
        public UInt16 GetTireTemp_FL9()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL9);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL9(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL9, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FL2Message : CanMessage
    {
        public TireTemp_FL2Message()
        {
            MessageType = CanMessageTypes.TireTemp_FL2;
        }
        public static readonly CanSignalType TireTemp_FL5 = CanSignalTypes.TireTemp_FL2__TireTemp_FL5;
        public UInt16 GetTireTemp_FL5()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL5);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL5(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL5, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL6 = CanSignalTypes.TireTemp_FL2__TireTemp_FL6;
        public UInt16 GetTireTemp_FL6()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL6);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL6(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL6, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL7 = CanSignalTypes.TireTemp_FL2__TireTemp_FL7;
        public UInt16 GetTireTemp_FL7()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL7);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL7(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL7, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL8 = CanSignalTypes.TireTemp_FL2__TireTemp_FL8;
        public UInt16 GetTireTemp_FL8()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL8);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL8(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL8, (UInt64)value);
        }
    }
    
    
    public class TireTemp_FL1Message : CanMessage
    {
        public TireTemp_FL1Message()
        {
            MessageType = CanMessageTypes.TireTemp_FL1;
        }
        public static readonly CanSignalType TireTemp_FL4 = CanSignalTypes.TireTemp_FL1__TireTemp_FL4;
        public UInt16 GetTireTemp_FL4()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL4);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL4(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL4, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL3 = CanSignalTypes.TireTemp_FL1__TireTemp_FL3;
        public UInt16 GetTireTemp_FL3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL3);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL3, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL2 = CanSignalTypes.TireTemp_FL1__TireTemp_FL2;
        public UInt16 GetTireTemp_FL2()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL2);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL2(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL2, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_FL1 = CanSignalTypes.TireTemp_FL1__TireTemp_FL1;
        public UInt16 GetTireTemp_FL1()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_FL1);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_FL1(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_FL1, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RR4Message : CanMessage
    {
        public TireTemp_RR4Message()
        {
            MessageType = CanMessageTypes.TireTemp_RR4;
        }
        public static readonly CanSignalType TireTemp_RR16 = CanSignalTypes.TireTemp_RR4__TireTemp_RR16;
        public UInt16 GetTireTemp_RR16()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR16);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR16(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR16, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR15 = CanSignalTypes.TireTemp_RR4__TireTemp_RR15;
        public UInt16 GetTireTemp_RR15()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR15);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR15(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR15, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR14 = CanSignalTypes.TireTemp_RR4__TireTemp_RR14;
        public UInt16 GetTireTemp_RR14()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR14);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR14(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR14, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR13 = CanSignalTypes.TireTemp_RR4__TireTemp_RR13;
        public UInt16 GetTireTemp_RR13()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR13);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR13(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR13, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RR3Message : CanMessage
    {
        public TireTemp_RR3Message()
        {
            MessageType = CanMessageTypes.TireTemp_RR3;
        }
        public static readonly CanSignalType TireTemp_RR12 = CanSignalTypes.TireTemp_RR3__TireTemp_RR12;
        public UInt16 GetTireTemp_RR12()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR12);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR12(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR12, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR11 = CanSignalTypes.TireTemp_RR3__TireTemp_RR11;
        public UInt16 GetTireTemp_RR11()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR11);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR11(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR11, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR10 = CanSignalTypes.TireTemp_RR3__TireTemp_RR10;
        public UInt16 GetTireTemp_RR10()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR10);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR10(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR10, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR9 = CanSignalTypes.TireTemp_RR3__TireTemp_RR9;
        public UInt16 GetTireTemp_RR9()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR9);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR9(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR9, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RR2Message : CanMessage
    {
        public TireTemp_RR2Message()
        {
            MessageType = CanMessageTypes.TireTemp_RR2;
        }
        public static readonly CanSignalType TireTemp_RR8 = CanSignalTypes.TireTemp_RR2__TireTemp_RR8;
        public UInt16 GetTireTemp_RR8()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR8);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR8(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR8, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR7 = CanSignalTypes.TireTemp_RR2__TireTemp_RR7;
        public UInt16 GetTireTemp_RR7()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR7);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR7(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR7, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR6 = CanSignalTypes.TireTemp_RR2__TireTemp_RR6;
        public UInt16 GetTireTemp_RR6()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR6);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR6(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR6, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR5 = CanSignalTypes.TireTemp_RR2__TireTemp_RR5;
        public UInt16 GetTireTemp_RR5()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR5);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR5(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR5, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RR1Message : CanMessage
    {
        public TireTemp_RR1Message()
        {
            MessageType = CanMessageTypes.TireTemp_RR1;
        }
        public static readonly CanSignalType TireTemp_RR4 = CanSignalTypes.TireTemp_RR1__TireTemp_RR4;
        public UInt16 GetTireTemp_RR4()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR4);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR4(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR4, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR3 = CanSignalTypes.TireTemp_RR1__TireTemp_RR3;
        public UInt16 GetTireTemp_RR3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR3);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR3, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR2 = CanSignalTypes.TireTemp_RR1__TireTemp_RR2;
        public UInt16 GetTireTemp_RR2()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR2);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR2(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR2, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RR1 = CanSignalTypes.TireTemp_RR1__TireTemp_RR1;
        public UInt16 GetTireTemp_RR1()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RR1);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RR1(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RR1, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RL4Message : CanMessage
    {
        public TireTemp_RL4Message()
        {
            MessageType = CanMessageTypes.TireTemp_RL4;
        }
        public static readonly CanSignalType TireTemp_RL16 = CanSignalTypes.TireTemp_RL4__TireTemp_RL16;
        public UInt16 GetTireTemp_RL16()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL16);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL16(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL16, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL15 = CanSignalTypes.TireTemp_RL4__TireTemp_RL15;
        public UInt16 GetTireTemp_RL15()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL15);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL15(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL15, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL14 = CanSignalTypes.TireTemp_RL4__TireTemp_RL14;
        public UInt16 GetTireTemp_RL14()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL14);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL14(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL14, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL13 = CanSignalTypes.TireTemp_RL4__TireTemp_RL13;
        public UInt16 GetTireTemp_RL13()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL13);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL13(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL13, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RL3Message : CanMessage
    {
        public TireTemp_RL3Message()
        {
            MessageType = CanMessageTypes.TireTemp_RL3;
        }
        public static readonly CanSignalType TireTemp_RL12 = CanSignalTypes.TireTemp_RL3__TireTemp_RL12;
        public UInt16 GetTireTemp_RL12()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL12);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL12(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL12, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL11 = CanSignalTypes.TireTemp_RL3__TireTemp_RL11;
        public UInt16 GetTireTemp_RL11()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL11);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL11(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL11, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL10 = CanSignalTypes.TireTemp_RL3__TireTemp_RL10;
        public UInt16 GetTireTemp_RL10()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL10);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL10(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL10, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL9 = CanSignalTypes.TireTemp_RL3__TireTemp_RL9;
        public UInt16 GetTireTemp_RL9()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL9);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL9(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL9, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RL2Message : CanMessage
    {
        public TireTemp_RL2Message()
        {
            MessageType = CanMessageTypes.TireTemp_RL2;
        }
        public static readonly CanSignalType TireTemp_RL8 = CanSignalTypes.TireTemp_RL2__TireTemp_RL8;
        public UInt16 GetTireTemp_RL8()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL8);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL8(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL8, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL7 = CanSignalTypes.TireTemp_RL2__TireTemp_RL7;
        public UInt16 GetTireTemp_RL7()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL7);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL7(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL7, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL6 = CanSignalTypes.TireTemp_RL2__TireTemp_RL6;
        public UInt16 GetTireTemp_RL6()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL6);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL6(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL6, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL5 = CanSignalTypes.TireTemp_RL2__TireTemp_RL5;
        public UInt16 GetTireTemp_RL5()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL5);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL5(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL5, (UInt64)value);
        }
    }
    
    
    public class TireTemp_RL1Message : CanMessage
    {
        public TireTemp_RL1Message()
        {
            MessageType = CanMessageTypes.TireTemp_RL1;
        }
        public static readonly CanSignalType TireTemp_RL4 = CanSignalTypes.TireTemp_RL1__TireTemp_RL4;
        public UInt16 GetTireTemp_RL4()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL4);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL4(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL4, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL3 = CanSignalTypes.TireTemp_RL1__TireTemp_RL3;
        public UInt16 GetTireTemp_RL3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL3);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL3, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL2 = CanSignalTypes.TireTemp_RL1__TireTemp_RL2;
        public UInt16 GetTireTemp_RL2()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL2);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL2(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL2, (UInt64)value);
        }
        public static readonly CanSignalType TireTemp_RL1 = CanSignalTypes.TireTemp_RL1__TireTemp_RL1;
        public UInt16 GetTireTemp_RL1()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(TireTemp_RL1);
            // Apply inverse transform to restore actual value
            tempValue  += 100;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetTireTemp_RL1(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 100;
            // Cats to integer and prepare for sending
            this.InsertBits(TireTemp_RL1, (UInt64)value);
        }
    }
    
    
    public class RN_Temperatures2Message : CanMessage
    {
        public RN_Temperatures2Message()
        {
            MessageType = CanMessageTypes.RN_Temperatures2;
        }
        public static readonly CanSignalType RN_Gearbox_Temp_RR = CanSignalTypes.RN_Temperatures2__RN_Gearbox_Temp_RR;
        public sbyte GetRN_Gearbox_Temp_RR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Gearbox_Temp_RR);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetRN_Gearbox_Temp_RR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Gearbox_Temp_RR, (UInt64)value);
        }
        public static readonly CanSignalType RN_Gearbox_Temp_RL = CanSignalTypes.RN_Temperatures2__RN_Gearbox_Temp_RL;
        public sbyte GetRN_Gearbox_Temp_RL()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Gearbox_Temp_RL);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetRN_Gearbox_Temp_RL(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Gearbox_Temp_RL, (UInt64)value);
        }
        public static readonly CanSignalType RN_Ambient_Outside = CanSignalTypes.RN_Temperatures2__RN_Ambient_Outside;
        public sbyte GetRN_Ambient_Outside()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Ambient_Outside);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetRN_Ambient_Outside(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Ambient_Outside, (UInt64)value);
        }
        public static readonly CanSignalType RN_Ambient_Inside = CanSignalTypes.RN_Temperatures2__RN_Ambient_Inside;
        public sbyte GetRN_Ambient_Inside()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Ambient_Inside);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetRN_Ambient_Inside(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Ambient_Inside, (UInt64)value);
        }
    }
    
    
    public class FN_GPS_PosMessage : CanMessage
    {
        public FN_GPS_PosMessage()
        {
            MessageType = CanMessageTypes.FN_GPS_Pos;
        }
        public static readonly CanSignalType FN_GPS_Flags = CanSignalTypes.FN_GPS_Pos__FN_GPS_Flags;
        public sbyte GetFN_GPS_Flags()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_GPS_Flags);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_GPS_Flags(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_GPS_Flags, (UInt64)value);
        }
        public static readonly CanSignalType FN_GPS_yPos = CanSignalTypes.FN_GPS_Pos__FN_GPS_yPos;
        public Int16 GetFN_GPS_yPos()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_GPS_yPos);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_GPS_yPos(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_GPS_yPos, (UInt64)value);
        }
        public static readonly CanSignalType FN_GPS_xPos = CanSignalTypes.FN_GPS_Pos__FN_GPS_xPos;
        public Int16 GetFN_GPS_xPos()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_GPS_xPos);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_GPS_xPos(Int16 value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_GPS_xPos, (UInt64)value);
        }
    }
    
    
    public class FN_TVMessage : CanMessage
    {
        public FN_TVMessage()
        {
            MessageType = CanMessageTypes.FN_TV;
        }
        public static readonly CanSignalType FN_TV_Knob = CanSignalTypes.FN_TV__FN_TV_Knob;
        public sbyte GetFN_TV_Knob()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_TV_Knob);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 10;
            return tempValue;
        }
        
        public void SetFN_TV_Knob(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 10;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_TV_Knob, (UInt64)value);
        }
        public static readonly CanSignalType FN_TC_Knob = CanSignalTypes.FN_TV__FN_TC_Knob;
        public sbyte GetFN_TC_Knob()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_TC_Knob);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetFN_TC_Knob(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_TC_Knob, (UInt64)value);
        }
        public static readonly CanSignalType FN_Regen_Neutral = CanSignalTypes.FN_TV__FN_Regen_Neutral;
        public sbyte GetFN_Regen_Neutral()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Regen_Neutral);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetFN_Regen_Neutral(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Regen_Neutral, (UInt64)value);
        }
        public static readonly CanSignalType FN_Regen_Knob = CanSignalTypes.FN_TV__FN_Regen_Knob;
        public sbyte GetFN_Regen_Knob()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Regen_Knob);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetFN_Regen_Knob(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Regen_Knob, (UInt64)value);
        }
        public static readonly CanSignalType FN_Regen_Div = CanSignalTypes.FN_TV__FN_Regen_Div;
        public sbyte GetFN_Regen_Div()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Regen_Div);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetFN_Regen_Div(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Regen_Div, (UInt64)value);
        }
    }
    
    
    public class FN_GyroMessage : CanMessage
    {
        public FN_GyroMessage()
        {
            MessageType = CanMessageTypes.FN_Gyro;
        }
        public static readonly CanSignalType FN_GyroZ = CanSignalTypes.FN_Gyro__FN_GyroZ;
        public Int16 GetFN_GyroZ()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_GyroZ);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_GyroZ(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_GyroZ, (UInt64)value);
        }
        public static readonly CanSignalType FN_GyroY = CanSignalTypes.FN_Gyro__FN_GyroY;
        public Int16 GetFN_GyroY()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_GyroY);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_GyroY(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_GyroY, (UInt64)value);
        }
        public static readonly CanSignalType FN_GyroX = CanSignalTypes.FN_Gyro__FN_GyroX;
        public Int16 GetFN_GyroX()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_GyroX);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_GyroX(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_GyroX, (UInt64)value);
        }
    }
    
    
    public class FN_AccelerometerMessage : CanMessage
    {
        public FN_AccelerometerMessage()
        {
            MessageType = CanMessageTypes.FN_Accelerometer;
        }
        public static readonly CanSignalType FN_AccZ = CanSignalTypes.FN_Accelerometer__FN_AccZ;
        public Int16 GetFN_AccZ()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_AccZ);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_AccZ(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_AccZ, (UInt64)value);
        }
        public static readonly CanSignalType FN_AccY = CanSignalTypes.FN_Accelerometer__FN_AccY;
        public Int16 GetFN_AccY()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_AccY);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_AccY(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_AccY, (UInt64)value);
        }
        public static readonly CanSignalType FN_AccX = CanSignalTypes.FN_Accelerometer__FN_AccX;
        public Int16 GetFN_AccX()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(FN_AccX);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_AccX(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_AccX, (UInt64)value);
        }
    }
    
    
    public class PE_RR_NMTMessage : CanMessage
    {
        public PE_RR_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_RR_NMT;
        }
        public static readonly CanSignalType PE_RR_NMT = CanSignalTypes.PE_RR_NMT__PE_RR_NMT;
        public sbyte GetPE_RR_NMT()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_RR_NMT);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RR_NMT(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RR_NMT, (UInt64)value);
        }
    }
    
    
    public class PE_RL_NMTMessage : CanMessage
    {
        public PE_RL_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_RL_NMT;
        }
        public static readonly CanSignalType PE_RL_NMT = CanSignalTypes.PE_RL_NMT__PE_RL_NMT;
        public sbyte GetPE_RL_NMT()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_RL_NMT);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_RL_NMT(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_RL_NMT, (UInt64)value);
        }
    }
    
    
    public class PE_FR_NMTMessage : CanMessage
    {
        public PE_FR_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_FR_NMT;
        }
        public static readonly CanSignalType PE_FR_NMT = CanSignalTypes.PE_FR_NMT__PE_FR_NMT;
        public sbyte GetPE_FR_NMT()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_FR_NMT);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FR_NMT(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FR_NMT, (UInt64)value);
        }
    }
    
    
    public class PE_FL_NMTMessage : CanMessage
    {
        public PE_FL_NMTMessage()
        {
            MessageType = CanMessageTypes.PE_FL_NMT;
        }
        public static readonly CanSignalType PE_FL_NMT = CanSignalTypes.PE_FL_NMT__PE_FL_NMT;
        public sbyte GetPE_FL_NMT()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(PE_FL_NMT);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetPE_FL_NMT(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(PE_FL_NMT, (UInt64)value);
        }
    }
    
    
    public class FN_Sensor_StatusMessage : CanMessage
    {
        public FN_Sensor_StatusMessage()
        {
            MessageType = CanMessageTypes.FN_Sensor_Status;
        }
        public static readonly CanSignalType FN_Sensor_Status = CanSignalTypes.FN_Sensor_Status__FN_Sensor_Status;
        public UInt32 GetFN_Sensor_Status()
        {
            // Get bits from raw data storage and cast
            UInt32 tempValue = (UInt32)ExtractBits(FN_Sensor_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_Sensor_Status(UInt32 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Sensor_Status, (UInt64)value);
        }
    }
    
    
    public class AMS_Stack_ErrorsMessage : CanMessage
    {
        public AMS_Stack_ErrorsMessage()
        {
            MessageType = CanMessageTypes.AMS_Stack_Errors;
        }
        public static readonly CanSignalType AMS_Errors_Stack6 = CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack6;
        public sbyte GetAMS_Errors_Stack6()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Errors_Stack6);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Errors_Stack6(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Errors_Stack6, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Errors_Stack5 = CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack5;
        public sbyte GetAMS_Errors_Stack5()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Errors_Stack5);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Errors_Stack5(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Errors_Stack5, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Errors_Stack4 = CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack4;
        public sbyte GetAMS_Errors_Stack4()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Errors_Stack4);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Errors_Stack4(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Errors_Stack4, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Errors_Stack3 = CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack3;
        public sbyte GetAMS_Errors_Stack3()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Errors_Stack3);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Errors_Stack3(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Errors_Stack3, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Errors_Stack2 = CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack2;
        public sbyte GetAMS_Errors_Stack2()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Errors_Stack2);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Errors_Stack2(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Errors_Stack2, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Errors_Stack1 = CanSignalTypes.AMS_Stack_Errors__AMS_Errors_Stack1;
        public sbyte GetAMS_Errors_Stack1()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Errors_Stack1);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Errors_Stack1(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Errors_Stack1, (UInt64)value);
        }
    }
    
    
    public class IVT_Msg_Result_WhMessage : CanMessage
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
    
    
    public class IVT_Msg_Result_WMessage : CanMessage
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
    
    
    public class IVT_Msg_Result_U3Message : CanMessage
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
            tempValue  *= 1000;
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
    
    
    public class IVT_Msg_Result_U2Message : CanMessage
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
            tempValue  *= 1000;
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
    
    
    public class IVT_Msg_Result_U1Message : CanMessage
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
            tempValue  *= 1000;
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
    
    
    public class IVT_Msg_Result_TMessage : CanMessage
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
    
    
    public class IVT_Msg_Result_IMessage : CanMessage
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
    
    
    public class IVT_Msg_Result_AsMessage : CanMessage
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
    
    
    public class AMSClient_StatusMessage : CanMessage
    {
        public AMSClient_StatusMessage()
        {
            MessageType = CanMessageTypes.AMSClient_Status;
        }
        public static readonly CanSignalType AMS_Client_Trigger_AMS = CanSignalTypes.AMSClient_Status__AMS_Client_Trigger_AMS;
        public sbyte GetAMS_Client_Trigger_AMS()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Client_Trigger_AMS);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Client_Trigger_AMS(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Client_Trigger_AMS, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Client_Start_TS = CanSignalTypes.AMSClient_Status__AMS_Client_Start_TS;
        public sbyte GetAMS_Client_Start_TS()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Client_Start_TS);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Client_Start_TS(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Client_Start_TS, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Client_FN_Buttons = CanSignalTypes.AMSClient_Status__AMS_Client_FN_Buttons;
        public sbyte GetAMS_Client_FN_Buttons()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Client_FN_Buttons);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Client_FN_Buttons(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Client_FN_Buttons, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Client_Front_Node_Status = CanSignalTypes.AMSClient_Status__AMS_Client_Front_Node_Status;
        public sbyte GetAMS_Client_Front_Node_Status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Client_Front_Node_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Client_Front_Node_Status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Client_Front_Node_Status, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Client_Enable_Communication = CanSignalTypes.AMSClient_Status__AMS_Client_Enable_Communication;
        public sbyte GetAMS_Client_Enable_Communication()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Client_Enable_Communication);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Client_Enable_Communication(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Client_Enable_Communication, (UInt64)value);
        }
    }
    
    
    public class AMS_CountersMessage : CanMessage
    {
        public AMS_CountersMessage()
        {
            MessageType = CanMessageTypes.AMS_Counters;
        }
        public static readonly CanSignalType AMS_RestartCounter = CanSignalTypes.AMS_Counters__AMS_RestartCounter;
        public UInt16 GetAMS_RestartCounter()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_RestartCounter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_RestartCounter(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_RestartCounter, (UInt64)value);
        }
        public static readonly CanSignalType AMS_PrechargeCounter = CanSignalTypes.AMS_Counters__AMS_PrechargeCounter;
        public UInt16 GetAMS_PrechargeCounter()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_PrechargeCounter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_PrechargeCounter(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_PrechargeCounter, (UInt64)value);
        }
        public static readonly CanSignalType AMS_TSCounter = CanSignalTypes.AMS_Counters__AMS_TSCounter;
        public UInt16 GetAMS_TSCounter()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_TSCounter);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_TSCounter(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_TSCounter, (UInt64)value);
        }
    }
    
    
    public class AMS_StatusMessage : CanMessage
    {
        public AMS_StatusMessage()
        {
            MessageType = CanMessageTypes.AMS_Status;
        }
        public static readonly CanSignalType AMS_Watchdog = CanSignalTypes.AMS_Status__AMS_Watchdog;
        public sbyte GetAMS_Watchdog()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Watchdog);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Watchdog(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Watchdog, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Precharge_Time = CanSignalTypes.AMS_Status__AMS_Precharge_Time;
        public sbyte GetAMS_Precharge_Time()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Precharge_Time);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Precharge_Time(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Precharge_Time, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Accumulator_Errors = CanSignalTypes.AMS_Status__AMS_Accumulator_Errors;
        public sbyte GetAMS_Accumulator_Errors()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Accumulator_Errors);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Accumulator_Errors(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Accumulator_Errors, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Accumulator_SoC = CanSignalTypes.AMS_Status__AMS_Accumulator_SoC;
        public sbyte GetAMS_Accumulator_SoC()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Accumulator_SoC);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Accumulator_SoC(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Accumulator_SoC, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Status = CanSignalTypes.AMS_Status__AMS_Status;
        public sbyte GetAMS_Status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Status, (UInt64)value);
        }
    }
    
    
    public class AMS_MaxMinTemperaturesMessage : CanMessage
    {
        public AMS_MaxMinTemperaturesMessage()
        {
            MessageType = CanMessageTypes.AMS_MaxMinTemperatures;
        }
        public static readonly CanSignalType AMS_AvgTemp = CanSignalTypes.AMS_MaxMinTemperatures__AMS_AvgTemp;
        public byte GetAMS_AvgTemp()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(AMS_AvgTemp);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_AvgTemp(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_AvgTemp, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MinTemp = CanSignalTypes.AMS_MaxMinTemperatures__AMS_MinTemp;
        public UInt16 GetAMS_MinTemp()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_MinTemp);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAMS_MinTemp(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MinTemp, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MinTemp_Pos_Stack = CanSignalTypes.AMS_MaxMinTemperatures__AMS_MinTemp_Pos_Stack;
        public sbyte GetAMS_MinTemp_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_MinTemp_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_MinTemp_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MinTemp_Pos_Stack, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MaxTemp = CanSignalTypes.AMS_MaxMinTemperatures__AMS_MaxTemp;
        public UInt16 GetAMS_MaxTemp()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_MaxTemp);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAMS_MaxTemp(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MaxTemp, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MaxTemp_Pos_Stack = CanSignalTypes.AMS_MaxMinTemperatures__AMS_MaxTemp_Pos_Stack;
        public sbyte GetAMS_MaxTemp_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_MaxTemp_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_MaxTemp_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MaxTemp_Pos_Stack, (UInt64)value);
        }
    }
    
    
    public class AMS_MaxMinVoltagesMessage : CanMessage
    {
        public AMS_MaxMinVoltagesMessage()
        {
            MessageType = CanMessageTypes.AMS_MaxMinVoltages;
        }
        public static readonly CanSignalType AMS_AvgVoltage = CanSignalTypes.AMS_MaxMinVoltages__AMS_AvgVoltage;
        public byte GetAMS_AvgVoltage()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(AMS_AvgVoltage);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_AvgVoltage(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_AvgVoltage, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MinVoltage = CanSignalTypes.AMS_MaxMinVoltages__AMS_MinVoltage;
        public UInt16 GetAMS_MinVoltage()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_MinVoltage);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAMS_MinVoltage(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MinVoltage, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MinVoltage_Pos_Stack = CanSignalTypes.AMS_MaxMinVoltages__AMS_MinVoltage_Pos_Stack;
        public sbyte GetAMS_MinVoltage_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_MinVoltage_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_MinVoltage_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MinVoltage_Pos_Stack, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MaxVoltage = CanSignalTypes.AMS_MaxMinVoltages__AMS_MaxVoltage;
        public UInt16 GetAMS_MaxVoltage()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_MaxVoltage);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAMS_MaxVoltage(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MaxVoltage, (UInt64)value);
        }
        public static readonly CanSignalType AMS_MaxVoltage_Pos_Stack = CanSignalTypes.AMS_MaxMinVoltages__AMS_MaxVoltage_Pos_Stack;
        public sbyte GetAMS_MaxVoltage_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_MaxVoltage_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_MaxVoltage_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_MaxVoltage_Pos_Stack, (UInt64)value);
        }
    }
    
    
    public class AMS_Cell_VoltagesMessage : CanMessage
    {
        public AMS_Cell_VoltagesMessage()
        {
            MessageType = CanMessageTypes.AMS_Cell_Voltages;
        }
        public static readonly CanSignalType AMS_Voltage3 = CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage3;
        public UInt16 GetAMS_Voltage3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_Voltage3);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAMS_Voltage3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Voltage3, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Voltage2 = CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage2;
        public UInt16 GetAMS_Voltage2()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_Voltage2);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAMS_Voltage2(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Voltage2, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Voltage1 = CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage1;
        public UInt16 GetAMS_Voltage1()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_Voltage1);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 1000;
            return tempValue;
        }
        
        public void SetAMS_Voltage1(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 1000;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Voltage1, (UInt64)value);
        }
        public static readonly CanSignalType AMS_UV_OV_Flags = CanSignalTypes.AMS_Cell_Voltages__AMS_UV_OV_Flags;
        public sbyte GetAMS_UV_OV_Flags()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_UV_OV_Flags);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_UV_OV_Flags(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_UV_OV_Flags, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Voltage_Pos_Stack = CanSignalTypes.AMS_Cell_Voltages__AMS_Voltage_Pos_Stack;
        public sbyte GetAMS_Voltage_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Voltage_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Voltage_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Voltage_Pos_Stack, (UInt64)value);
        }
    }
    
    
    public class AMS_Cell_TemperaturesMessage : CanMessage
    {
        public AMS_Cell_TemperaturesMessage()
        {
            MessageType = CanMessageTypes.AMS_Cell_Temperatures;
        }
        public static readonly CanSignalType AMS_Temp3 = CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp3;
        public UInt16 GetAMS_Temp3()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_Temp3);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAMS_Temp3(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Temp3, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Temp2 = CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp2;
        public UInt16 GetAMS_Temp2()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_Temp2);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAMS_Temp2(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Temp2, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Temp1 = CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp1;
        public UInt16 GetAMS_Temp1()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(AMS_Temp1);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetAMS_Temp1(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Temp1, (UInt64)value);
        }
        public static readonly CanSignalType AMS_UT_OT_Flags = CanSignalTypes.AMS_Cell_Temperatures__AMS_UT_OT_Flags;
        public sbyte GetAMS_UT_OT_Flags()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_UT_OT_Flags);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_UT_OT_Flags(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_UT_OT_Flags, (UInt64)value);
        }
        public static readonly CanSignalType AMS_Temp_Pos_Stack = CanSignalTypes.AMS_Cell_Temperatures__AMS_Temp_Pos_Stack;
        public sbyte GetAMS_Temp_Pos_Stack()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(AMS_Temp_Pos_Stack);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetAMS_Temp_Pos_Stack(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(AMS_Temp_Pos_Stack, (UInt64)value);
        }
    }
    
    
    public class RN_Sensor_StatusMessage : CanMessage
    {
        public RN_Sensor_StatusMessage()
        {
            MessageType = CanMessageTypes.RN_Sensor_Status;
        }
        public static readonly CanSignalType RN_Sensor_Status = CanSignalTypes.RN_Sensor_Status__RN_Sensor_Status;
        public UInt32 GetRN_Sensor_Status()
        {
            // Get bits from raw data storage and cast
            UInt32 tempValue = (UInt32)ExtractBits(RN_Sensor_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Sensor_Status(UInt32 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Sensor_Status, (UInt64)value);
        }
    }
    
    
    public class FN_SensorsMessage : CanMessage
    {
        public FN_SensorsMessage()
        {
            MessageType = CanMessageTypes.FN_Sensors;
        }
        public static readonly CanSignalType FN_Rotor_Object_temp_FL = CanSignalTypes.FN_Sensors__FN_Rotor_Object_temp_FL;
        public sbyte GetFN_Rotor_Object_temp_FL()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Rotor_Object_temp_FL);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Rotor_Object_temp_FL(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Rotor_Object_temp_FL, (UInt64)value);
        }
        public static readonly CanSignalType FN_Rotor_Object_temp_FR = CanSignalTypes.FN_Sensors__FN_Rotor_Object_temp_FR;
        public sbyte GetFN_Rotor_Object_temp_FR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Rotor_Object_temp_FR);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Rotor_Object_temp_FR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Rotor_Object_temp_FR, (UInt64)value);
        }
        public static readonly CanSignalType FN_Damper_FR = CanSignalTypes.FN_Sensors__FN_Damper_FR;
        public UInt16 GetFN_Damper_FR()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(FN_Damper_FR);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetFN_Damper_FR(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Damper_FR, (UInt64)value);
        }
        public static readonly CanSignalType FN_Damper_FL = CanSignalTypes.FN_Sensors__FN_Damper_FL;
        public UInt16 GetFN_Damper_FL()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(FN_Damper_FL);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetFN_Damper_FL(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Damper_FL, (UInt64)value);
        }
    }
    
    
    public class FN_TemperaturesMessage : CanMessage
    {
        public FN_TemperaturesMessage()
        {
            MessageType = CanMessageTypes.FN_Temperatures;
        }
        public static readonly CanSignalType FN_WaterR = CanSignalTypes.FN_Temperatures__FN_WaterR;
        public sbyte GetFN_WaterR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_WaterR);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_WaterR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_WaterR, (UInt64)value);
        }
        public static readonly CanSignalType FN_WaterL = CanSignalTypes.FN_Temperatures__FN_WaterL;
        public sbyte GetFN_WaterL()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_WaterL);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_WaterL(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_WaterL, (UInt64)value);
        }
        public static readonly CanSignalType FN_Gearbox_temp_FR = CanSignalTypes.FN_Temperatures__FN_Gearbox_temp_FR;
        public sbyte GetFN_Gearbox_temp_FR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Gearbox_temp_FR);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Gearbox_temp_FR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Gearbox_temp_FR, (UInt64)value);
        }
        public static readonly CanSignalType FN_Gearbox_temp_FL = CanSignalTypes.FN_Temperatures__FN_Gearbox_temp_FL;
        public sbyte GetFN_Gearbox_temp_FL()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Gearbox_temp_FL);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Gearbox_temp_FL(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Gearbox_temp_FL, (UInt64)value);
        }
        public static readonly CanSignalType FN_Brake_temp_FR = CanSignalTypes.FN_Temperatures__FN_Brake_temp_FR;
        public sbyte GetFN_Brake_temp_FR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Brake_temp_FR);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 4;
            return tempValue;
        }
        
        public void SetFN_Brake_temp_FR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 4;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Brake_temp_FR, (UInt64)value);
        }
        public static readonly CanSignalType FN_Brake_temp_FL = CanSignalTypes.FN_Temperatures__FN_Brake_temp_FL;
        public sbyte GetFN_Brake_temp_FL()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Brake_temp_FL);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 4;
            return tempValue;
        }
        
        public void SetFN_Brake_temp_FL(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 4;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Brake_temp_FL, (UInt64)value);
        }
    }
    
    
    public class FN_Driver_ControlsMessage : CanMessage
    {
        public FN_Driver_ControlsMessage()
        {
            MessageType = CanMessageTypes.FN_Driver_Controls;
        }
        public static readonly CanSignalType FN_Throttle = CanSignalTypes.FN_Driver_Controls__FN_Throttle;
        public sbyte GetFN_Throttle()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Throttle);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Throttle(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Throttle, (UInt64)value);
        }
        public static readonly CanSignalType FN_Steering_Angle = CanSignalTypes.FN_Driver_Controls__FN_Steering_Angle;
        public byte GetFN_Steering_Angle()
        {
            // Get bits from raw data storage and cast
            byte tempValue = (byte)ExtractBits(FN_Steering_Angle);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 2;
            return tempValue;
        }
        
        public void SetFN_Steering_Angle(byte value)
        {
            // Scale and offset value according to signal secification
            value *= 2;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Steering_Angle, (UInt64)value);
        }
        public static readonly CanSignalType FN_Brake_System = CanSignalTypes.FN_Driver_Controls__FN_Brake_System;
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
        public static readonly CanSignalType FN_Brake_Pedal = CanSignalTypes.FN_Driver_Controls__FN_Brake_Pedal;
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
        public static readonly CanSignalType FN_APPS2 = CanSignalTypes.FN_Driver_Controls__FN_APPS2;
        public sbyte GetFN_APPS2()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_APPS2);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_APPS2(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_APPS2, (UInt64)value);
        }
        public static readonly CanSignalType FN_APPS1 = CanSignalTypes.FN_Driver_Controls__FN_APPS1;
        public sbyte GetFN_APPS1()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_APPS1);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_APPS1(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_APPS1, (UInt64)value);
        }
    }
    
    
    public class RN_SensorsMessage : CanMessage
    {
        public RN_SensorsMessage()
        {
            MessageType = CanMessageTypes.RN_Sensors;
        }
        public static readonly CanSignalType RN_Rotor_Object_Temp_RR = CanSignalTypes.RN_Sensors__RN_Rotor_Object_Temp_RR;
        public sbyte GetRN_Rotor_Object_Temp_RR()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Rotor_Object_Temp_RR);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetRN_Rotor_Object_Temp_RR(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Rotor_Object_Temp_RR, (UInt64)value);
        }
        public static readonly CanSignalType RN_Rotor_Object_Temp_RL = CanSignalTypes.RN_Sensors__RN_Rotor_Object_Temp_RL;
        public sbyte GetRN_Rotor_Object_Temp_RL()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Rotor_Object_Temp_RL);
            // Apply inverse transform to restore actual value
            tempValue  += -5;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetRN_Rotor_Object_Temp_RL(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += -5;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Rotor_Object_Temp_RL, (UInt64)value);
        }
        public static readonly CanSignalType RN_Damper_RR = CanSignalTypes.RN_Sensors__RN_Damper_RR;
        public UInt16 GetRN_Damper_RR()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Damper_RR);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetRN_Damper_RR(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Damper_RR, (UInt64)value);
        }
        public static readonly CanSignalType RN_Damper_RL = CanSignalTypes.RN_Sensors__RN_Damper_RL;
        public UInt16 GetRN_Damper_RL()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Damper_RL);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 100;
            return tempValue;
        }
        
        public void SetRN_Damper_RL(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value /= 100;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Damper_RL, (UInt64)value);
        }
    }
    
    
    public class RN_Errors_PEMessage : CanMessage
    {
        public RN_Errors_PEMessage()
        {
            MessageType = CanMessageTypes.RN_Errors_PE;
        }
        public static readonly CanSignalType RN_Error_PE_RR = CanSignalTypes.RN_Errors_PE__RN_Error_PE_RR;
        public Int16 GetRN_Error_PE_RR()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_Error_PE_RR);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Error_PE_RR(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Error_PE_RR, (UInt64)value);
        }
        public static readonly CanSignalType RN_Error_PE_RL = CanSignalTypes.RN_Errors_PE__RN_Error_PE_RL;
        public Int16 GetRN_Error_PE_RL()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_Error_PE_RL);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Error_PE_RL(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Error_PE_RL, (UInt64)value);
        }
        public static readonly CanSignalType RN_Error_PE_FR = CanSignalTypes.RN_Errors_PE__RN_Error_PE_FR;
        public Int16 GetRN_Error_PE_FR()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_Error_PE_FR);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Error_PE_FR(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Error_PE_FR, (UInt64)value);
        }
        public static readonly CanSignalType RN_Error_PE_FL = CanSignalTypes.RN_Errors_PE__RN_Error_PE_FL;
        public Int16 GetRN_Error_PE_FL()
        {
            // Get bits from raw data storage and cast
            Int16 tempValue = (Int16)ExtractBits(RN_Error_PE_FL);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Error_PE_FL(Int16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Error_PE_FL, (UInt64)value);
        }
    }
    
    
    public class RN_TemperaturesMessage : CanMessage
    {
        public RN_TemperaturesMessage()
        {
            MessageType = CanMessageTypes.RN_Temperatures;
        }
        public static readonly CanSignalType RN_Water_Motor_RR = CanSignalTypes.RN_Temperatures__RN_Water_Motor_RR;
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
        public static readonly CanSignalType RN_Water_Motor_RL = CanSignalTypes.RN_Temperatures__RN_Water_Motor_RL;
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
        public static readonly CanSignalType RN_Water_Motor_Radiator = CanSignalTypes.RN_Temperatures__RN_Water_Motor_Radiator;
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
        public static readonly CanSignalType RN_Water_Motor_PE = CanSignalTypes.RN_Temperatures__RN_Water_Motor_PE;
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
    
    
    public class FN_StatusMessage : CanMessage
    {
        public FN_StatusMessage()
        {
            MessageType = CanMessageTypes.FN_Status;
        }
        public static readonly CanSignalType FN_DiffRear = CanSignalTypes.FN_Status__FN_DiffRear;
        public sbyte GetFN_DiffRear()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_DiffRear);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_DiffRear(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_DiffRear, (UInt64)value);
        }
        public static readonly CanSignalType FN_DiffFront = CanSignalTypes.FN_Status__FN_DiffFront;
        public sbyte GetFN_DiffFront()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_DiffFront);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_DiffFront(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_DiffFront, (UInt64)value);
        }
        public static readonly CanSignalType FN_Front_Torque_Scale = CanSignalTypes.FN_Status__FN_Front_Torque_Scale;
        public sbyte GetFN_Front_Torque_Scale()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Front_Torque_Scale);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Front_Torque_Scale(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Front_Torque_Scale, (UInt64)value);
        }
        public static readonly CanSignalType FN_Speed_Limit = CanSignalTypes.FN_Status__FN_Speed_Limit;
        public sbyte GetFN_Speed_Limit()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Speed_Limit);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 100;
            return tempValue;
        }
        
        public void SetFN_Speed_Limit(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 100;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Speed_Limit, (UInt64)value);
        }
        public static readonly CanSignalType FN_Max_Torque = CanSignalTypes.FN_Status__FN_Max_Torque;
        public sbyte GetFN_Max_Torque()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Max_Torque);
            // Apply inverse transform to restore actual value
            tempValue  += 0;
            tempValue  *= 2;
            return tempValue;
        }
        
        public void SetFN_Max_Torque(sbyte value)
        {
            // Scale and offset value according to signal secification
            value /= 2;
            value += 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Max_Torque, (UInt64)value);
        }
        public static readonly CanSignalType FN_Watchdog_Status = CanSignalTypes.FN_Status__FN_Watchdog_Status;
        public sbyte GetFN_Watchdog_Status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(FN_Watchdog_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_Watchdog_Status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Watchdog_Status, (UInt64)value);
        }
        public static readonly CanSignalType FN_Status = CanSignalTypes.FN_Status__FN_Status;
        public UInt16 GetFN_Status()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(FN_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetFN_Status(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(FN_Status, (UInt64)value);
        }
    }
    
    
    public class PE_FR_PDO_3_TXMessage : CanMessage
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
    
    
    public class PE_FR_PDO_2_TXMessage : CanMessage
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
    
    
    public class PE_FR_PDO_1_TXMessage : CanMessage
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
    
    
    public class PE_FL_PDO_3_TXMessage : CanMessage
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
    
    
    public class PE_FL_PDO_2_TXMessage : CanMessage
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
    
    
    public class PE_FL_PDO_1_TXMessage : CanMessage
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
    
    
    public class PE_RR_PDO_3_TXMessage : CanMessage
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
    
    
    public class PE_RR_PDO_2_TXMessage : CanMessage
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
    
    
    public class PE_RR_PDO_1_TXMessage : CanMessage
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
    
    
    public class RN_PE_FR_PDO_3_RXMessage : CanMessage
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
    
    
    public class RN_PE_FR_PDO_2_RXMessage : CanMessage
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
    
    
    public class RN_PE_FR_PDO_1_RXMessage : CanMessage
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
    
    
    public class RN_PE_FL_PDO_3_RXMessage : CanMessage
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
    
    
    public class RN_PE_FL_PDO_2_RXMessage : CanMessage
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
    
    
    public class RN_PE_FL_PDO_1_RXMessage : CanMessage
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
    
    
    public class RN_PE_RR_PDO_3_RXMessage : CanMessage
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
    
    
    public class RN_PE_RR_PDO_2_RXMessage : CanMessage
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
    
    
    public class RN_PE_RR_PDO_1_RXMessage : CanMessage
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
    
    
    public class RN_StatusMessage : CanMessage
    {
        public RN_StatusMessage()
        {
            MessageType = CanMessageTypes.RN_Status;
        }
        public static readonly CanSignalType RN_AMS_Safestate = CanSignalTypes.RN_Status__RN_AMS_Safestate;
        public sbyte GetRN_AMS_Safestate()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_AMS_Safestate);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_AMS_Safestate(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_AMS_Safestate, (UInt64)value);
        }
        public static readonly CanSignalType RN_Status = CanSignalTypes.RN_Status__RN_Status;
        public sbyte GetRN_Status()
        {
            // Get bits from raw data storage and cast
            sbyte tempValue = (sbyte)ExtractBits(RN_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Status(sbyte value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Status, (UInt64)value);
        }
        public static readonly CanSignalType RN_Watchdog_Status = CanSignalTypes.RN_Status__RN_Watchdog_Status;
        public UInt16 GetRN_Watchdog_Status()
        {
            // Get bits from raw data storage and cast
            UInt16 tempValue = (UInt16)ExtractBits(RN_Watchdog_Status);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_Watchdog_Status(UInt16 value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_Watchdog_Status, (UInt64)value);
        }
    }
    
    
    public class PE_RL_PDO_3_TXMessage : CanMessage
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
    
    
    public class PE_RL_PDO_2_TXMessage : CanMessage
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
    
    
    public class PE_RL_PDO_1_TXMessage : CanMessage
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
    
    
    public class RN_PE_RL_PDO_3_RXMessage : CanMessage
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
    
    
    public class RN_PE_RL_PDO_2_RXMessage : CanMessage
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
    
    
    public class RN_PE_RL_PDO_1_RXMessage : CanMessage
    {
        public RN_PE_RL_PDO_1_RXMessage()
        {
            MessageType = CanMessageTypes.RN_PE_RL_PDO_1_RX;
        }
        public static readonly CanSignalType RN_PE_RL_Error_Reset = CanSignalTypes.RN_PE_RL_PDO_1_RX__RN_PE_RL_Error_Reset;
        public double GetRN_PE_RL_Error_Reset()
        {
            // Get bits from raw data storage and cast
            double tempValue = (double)ExtractBits(RN_PE_RL_Error_Reset);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Error_Reset(double value)
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
        public float GetRN_PE_RL_Enable_Drive()
        {
            // Get bits from raw data storage and cast
            float tempValue = (float)ExtractBits(RN_PE_RL_Enable_Drive);
            // Apply inverse transform to restore actual value
            tempValue  -= 0;
            tempValue  /= 1;
            return tempValue;
        }
        
        public void SetRN_PE_RL_Enable_Drive(float value)
        {
            // Scale and offset value according to signal secification
            value *= 1;
            value -= 0;
            // Cats to integer and prepare for sending
            this.InsertBits(RN_PE_RL_Enable_Drive, (UInt64)value);
        }
    }
    

}
