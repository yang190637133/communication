
/*
 * ************************************************************************
 * 
 * $Id: DaHuaSDKStruct.cs 7238 2012-12-17 00:02:20Z liu_hai $
 * 
 *                            SDK
 *                      ������SDK(C#��)
 * 
 * Copyright(c)1992-2012, ZheJiang Dahua Technology Stock Co.Ltd.
 *                      All Rights Reserved
 * �� �� ��:0.01
 * �ļ�����:DaHuaSDKStruct.cs
 * ����˵��:ԭʼ��װ[�����е�SDK(C++��)����һ�η�װ,������ԭC++�ӿڶ�Ӧ]
 * ��    ��:����
 * ��������:2012��5��26��
 * �޸���־:    ����          �汾��        ����        �������
 *              2012��5��26��  0.01         ����        �½�����
 * 
 * ************************************************************************
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net;


namespace DHNetSDK
{

    #region << �ṹ���� >>

    /// <summary>
    /// �����豸��Ϣ
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_DEVICEINFO
    {
        /// <summary>
        /// ���к�[����48]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] sSerialNumber;

        /// <summary>
        /// DVR�����������
        /// </summary>
        public byte byAlarmInPortNum;

        /// <summary>
        /// DVR�����������
        /// </summary>
        public byte byAlarmOutPortNum;

        /// <summary>
        /// DVRӲ�̸���
        /// </summary>
        public byte byDiskNum;

        /// <summary>
        /// DVR����
        /// </summary>
        public byte byDVRType;

        /// <summary>
        /// DVRͨ������
        /// </summary>
        public byte byChanNum;

    }

    /// <summary>
    /// ����ʱ��
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_TIME
    {
        /// <summary>
        /// ��
        /// </summary>
        public int dwYear;
        /// <summary>
        /// ��
        /// </summary>
        public int dwMonth;
        /// <summary>
        /// ��
        /// </summary>
        public int dwDay;
        /// <summary>
        /// ʱ
        /// </summary>
        public int dwHour;
        /// <summary>
        /// ��
        /// </summary>
        public int dwMinute;
        /// <summary>
        /// ��
        /// </summary>
        public int dwSecond;

        /// <summary>
        /// �����ڰ���ʽת��
        /// </summary>
        /// <param name="FormatStyle">���ڸ�ʽ�ַ���:yyyyΪ���ֵ��ʽ[�̶���λ]��mmΪ�µ�ֵ��ʽ[�̶���λ]��ddΪ�յ�ֵ��ʽ[�̶���λ]��dΪ�յ�ֵ��ʽ[���޶�λ��]��mΪ�µĸ�ʽ[���޶�λ��]��yyΪ��ĸ�ʽ[�̶���λ]��yΪ��ĸ�ʽ[���޶�λ��]��hhΪʱ��ֵ��ʽ[�̶���λ]��hΪʱ��ֵ��ʽ[���޶�λ��]��MMΪ�ֵ�ֵ��ʽ[�̶���λ]��MΪ�ֵ�ֵ��ʽ[���޶�λ��]��ssΪ���ֵ��ʽ[�̶���λ]��sΪ���ֵ��ʽ[���޶�λ��]��</param>
        /// <returns></returns>
        public string ToString(string FormatStyle)
        {
            string returnValue = FormatStyle;
            //��ĸ�ʽ����
            string strY = "";
            if (returnValue.IndexOf("yyyy") != -1)
            {
                strY = "0000".Remove(4 - dwYear.ToString().Length) + dwYear.ToString();
                returnValue = returnValue.Replace("yyyy", strY);
            }
            else if (returnValue.IndexOf("yy") != -1)
            {
                if (dwYear.ToString().Length > 2)
                {
                    strY = dwYear.ToString().Substring(dwYear.ToString().Length - 2);
                    returnValue = returnValue.Replace("yy", strY);
                }
                else
                {
                    strY = "00".Remove(2 - dwYear.ToString().Length) + dwYear.ToString();
                    returnValue = returnValue.Replace("yy", strY);
                }
            }
            else if (returnValue.IndexOf("y") != -1)
            {
                strY = dwYear.ToString();
                returnValue = returnValue.Replace("y", strY);
            }
            //�µĸ�ʽ����
            string strM = "";
            if (returnValue.IndexOf("mm") != -1)
            {
                strM = "00".Remove(2 - dwMonth.ToString().Length) + dwMonth.ToString();
                returnValue = returnValue.Replace("mm", strM);
            }
            else if (returnValue.IndexOf("m") != -1)
            {
                strM = dwMonth.ToString();
                returnValue = returnValue.Replace("m", strM);
            }
            //�յĸ�ʽ����
            string strD = "";
            if (returnValue.IndexOf("dd") != -1)
            {
                strD = "00".Remove(2 - dwDay.ToString().Length) + dwDay.ToString();
                returnValue = returnValue.Replace("dd", strD);
            }
            else if (returnValue.IndexOf("d") != -1)
            {
                strD = dwDay.ToString();
                returnValue = returnValue.Replace("d", strD);
            }
            //ʱ�ĸ�ʽ����
            string strH = "";
            if (returnValue.IndexOf("hh") != -1)
            {
                strH = "00".Remove(2 - dwHour.ToString().Length) + dwHour.ToString();
                returnValue = returnValue.Replace("hh", strH);
            }
            else if (returnValue.IndexOf("h") != -1)
            {
                strH = dwHour.ToString();
                returnValue = returnValue.Replace("h", strH);
            }
            //�ֵĸ�ʽ����
            string strMM = "";
            if (returnValue.IndexOf("MM") != -1)
            {
                strMM = "00".Remove(2 - dwMinute.ToString().Length) + dwMinute.ToString();
                returnValue = returnValue.Replace("MM", strMM);
            }
            else if (returnValue.IndexOf("M") != -1)
            {
                strMM = dwMinute.ToString();
                returnValue = returnValue.Replace("M", strMM);
            }
            //��ĸ�ʽ����
            string strS = "";
            if (returnValue.IndexOf("ss") != -1)
            {
                strS = "00".Remove(2 - dwSecond.ToString().Length) + dwSecond.ToString();
                returnValue = returnValue.Replace("ss", strS);
            }
            else if (returnValue.IndexOf("s") != -1)
            {
                strS = dwSecond.ToString();
                returnValue = returnValue.Replace("s", strS);
            }
            return returnValue;
        }

        /// <summary>
        /// תΪ��׼����ϵͳʱ���ʽ
        /// </summary>
        /// <returns></returns>
        public DateTime ToDateTime()
        {
            try
            {
                return new DateTime(dwYear, dwMonth, dwDay, dwHour, dwMinute, dwSecond);
            }
            catch
            {
                return DateTime.Now;
            }
        }

    }

    /// <summary>
    /// ¼���ļ���Ϣ
    /// </summary>
    public struct NET_RECORDFILE_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
        public uint ch;
        /// <summary>
        /// �ļ���
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] filename;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 128)]
        public byte[] filename;
        //public string filename;
        /// <summary>
        /// �ļ�����
        /// </summary>
        public uint size;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public NET_TIME starttime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public NET_TIME endtime;
        /// <summary>
        /// ���̺�
        /// </summary>
        public uint driveno;
        /// <summary>
        /// ��ʼ�غ�
        /// </summary>
        public uint startcluster;
        /// <summary>
        /// ¼���ļ�����  0����ͨ¼��1������¼
        /// </summary>
        public int nRecordFileType;
    }

    /// <summary>
    /// ��������
    /// </summary>
    public struct OPERATION_INFO
    {
        /// <summary>
        /// �������
        /// </summary>
        public string errCode;
        /// <summary>
        /// ��������
        /// </summary>
        public string errMessage;
        /// <summary>
        /// ���Զ����ʽ���ش��������ַ���
        /// </summary>
        /// <param name="FormatStyle">���������ַ�����ʽ��errcode����������;errmsg�����������</param>
        /// <returns></returns>
        public string ToString(string FormatStyle)
        {
            string returnValue = FormatStyle;
            if (returnValue.Length == 0)
            {
                returnValue = "errcode:errmsg!";
            }
            returnValue = returnValue.ToUpper();
            returnValue = returnValue.Replace("ERRCODE", errCode).Replace("ERRMSG", errMessage);
            return returnValue;

        }
    }

    /// <summary>
    /// �豸״̬��Ϣ
    /// </summary>
    public struct NET_CLIENT_STATE
    {
        /// <summary>
        /// ͨ����
        /// </summary>
        public int channelcount;

        /// <summary>
        /// ����������
        /// </summary>
        public int alarminputcount;

        /// <summary>
        /// �ⲿ����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] alarm;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] alarm;

        /// <summary>
        /// ��̬���
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] motiondection;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] motiondection;

        /// <summary>
        /// ��Ƶ��ʧ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] videolost;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] videolost;
    }

    /// <summary>
    /// �豸ͨ��״̬��Ϣ
    /// </summary>
    public struct NET_DEV_CHANNELSTATE
    {
        /// <summary>
        /// ͨ���Ƿ���¼��,0-��¼��,1-¼��
        /// </summary>
        public byte byRecordStatic;
        /// <summary>
        /// ���ӵ��ź�״̬,0-����,1-�źŶ�ʧ
        /// </summary>
        public byte bySignalStatic;
        /// <summary>
        /// ͨ��Ӳ��״̬,0-����,1-�쳣,����DSP����
        /// </summary>
        public byte byHardwareStatic;
        /// <summary>
        /// ��ʱ��Ч
        /// </summary>
        public char reserve;
        /// <summary>
        /// ʵ������,��ʱ��Ч
        /// </summary>
        public UInt32 dwBitRate;
        /// <summary>
        /// �ͻ������ӵĸ���, ��ʱ��Ч
        /// </summary>
        public UInt32 dwLinkNum;
        /// <summary>
        /// �ͻ��˵�IP��ַ,��ʱ��Ч
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public UInt32[] dwClientIP;
    }

    /// <summary>
    /// �豸Ӳ��״̬��Ϣ
    /// </summary>
    public struct NET_DEV_DISKSTATE
    {
        /// <summary>
        /// Ӳ�̵�����
        /// </summary>
        public UInt32 dwVolume;
        /// <summary>
        /// Ӳ�̵�ʣ��ռ�
        /// </summary>
        public UInt32 dwFreeSpace;
        /// <summary>
        /// Ӳ�̵�״̬,����,�,��������
        /// </summary>
        public UInt32 dwStatus;
    }

    /// <summary>
    /// �豸����״̬��Ϣ
    /// </summary>
    public struct NET_DEV_WORKSTATE
    {
        /// <summary>
        /// �豸״̬0x00 ����,0x01 CPUռ�ù���, 0x02 Ӳ������
        /// </summary>
        public UInt32 dwDeviceStatic;
        /// <summary>
        /// �豸��ʱ��֧��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_DEV_DISKSTATE[] stHardDiskStatic;
        /// <summary>
        /// ͨ����״̬
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_DEV_CHANNELSTATE[] stChanStatic;
        /// <summary>
        /// �����˿ڵ�״̬0-�ޱ���,1-�б���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byAlarmInStatic;
        /// <summary>
        /// ��������˿ڵ�״̬0-�����,1-�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byAlarmOutStatic;
        /// <summary>
        /// ������ʾ״̬0-����,1-������
        /// </summary>
        public UInt32 dwLocalDisplay;
    }

    /// <summary>
    /// ����Э����Ϣ(232��485
    /// </summary>
    public struct PROTOCOL_INFO
    {
        /// <summary>
        /// Э����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 12)]
        //public char[] protocolname;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 12)]
        public byte[] protocolname;
        /// <summary>
        /// ������
        /// </summary>
        public uint baudbase;
        /// <summary>
        /// ����λ
        /// </summary>
        public char databits;
        /// <summary>
        /// ֹͣλ
        /// </summary>
        public char stopbits;
        /// <summary>
        /// У��λ
        /// </summary>
        public char parity;
        /// <summary>
        /// �ݲ�֧��
        /// </summary>
        public char reserve;
    }

    /// <summary>
    /// ����IO����(��������ͱ�������ʹ��)
    /// </summary>
    public struct ALARM_CONTROL
    {
        /// <summary>
        /// �˿����
        /// </summary>
        public ushort index;
        /// <summary>
        /// �˿�״̬
        /// </summary>
        public ushort state;
    }

    
    public struct OPR_RIGHT
    {
        public UInt32 dwID;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] name;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] name;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] memo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] memo;
    }

    /// <summary>
    /// �û���Ϣ
    /// </summary>
    public struct USER_INFO
    {
        public UInt32 dwID;
        public UInt32 dwGroupID;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 8)]
        //public char[] name;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 8)]
        public byte[] name;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 8)]
        //public char[] passWord;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] passWord;
        public UInt32 dwRightNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public UInt32[] rights;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] memo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] memo;
        /// <summary>
        /// ���û��Ƿ�������:1.����;0:������;
        /// </summary>
        public UInt32 dwReusable;
        public USER_INFO(string st)
        {
            dwID = new UInt32();
            dwGroupID = new UInt32();
            dwRightNum = new UInt32();
            dwReusable = new UInt32();
            name = new byte[8];
            passWord = new byte[8];
            rights = new UInt32[100];
            memo = new byte[32];
        }
    }

    /// <summary>
    /// �û���ṹ
    /// </summary>
    public struct USER_GROUP_INFO
    {
        public UInt32 dwID;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 8)]
        //public char[] name;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 8)]
        public byte[] name;
        public UInt32 dwRightNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public UInt32[] rights;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] memo;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] memo;
        public USER_GROUP_INFO(string strP)
        {
            dwID = new UInt32();
            name = new byte[8];
            dwRightNum = new UInt32();
            rights = new UInt32[100];
            memo = new byte[32];
        }
    }


    /// <summary>
    /// �û���Ϣ���ýṹ
    /// </summary>
    public struct USER_MANAGE_INFO
    {
        public UInt32 dwRightNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public OPR_RIGHT[] rightList;
        public UInt32 dwGroupNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public USER_GROUP_INFO[] groupList;
        public UInt32 dwUserNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
        public USER_INFO[] userList;
        /// <summary>
        /// ������Ϣ:1.֧���û�����;0.��֧���û�����;
        /// </summary>
        public UInt32 dwSpecial;
    }

    /// <summary>
    /// ��־�ṹ
    /// </summary>
    public struct DH_LOG_ITEM
    {
        /// <summary>
        /// ����
        /// </summary>
        public NET_TIME time;
        /// <summary>
        /// ����
        /// </summary>
        public UInt16 type;
        /// <summary>
        /// ����
        /// </summary>
        public byte reserved;
        /// <summary>
        /// ����
        /// </summary>
        public byte data;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] context;
    }


    /// <summary>
    /// ��ѯӲ����Ϣ�ķ������ݽṹ
    /// </summary>
    public struct DH_HARDDISK_STATE
    {
        /// <summary>
        /// Ӳ�̸���
        /// </summary>
        public UInt32 dwDiskNum;
        /// <summary>
        /// ��Ӳ����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_DEV_DISKSTATE[] stDisks;
    }

    /// <summary>
    /// ��Ƶ���ݵĸ�ʽ�ṹ
    /// </summary>
    public struct DH_AUDIO_FORMAT
    {
        /// <summary>
        /// �������ͣ�0-PCM
        /// </summary>
        public byte byFormatTag;
        /// <summary>
        /// ������
        /// </summary>
        public UInt16 nChannels;
        /// <summary>
        /// �������
        /// </summary>
        public UInt16 wBitsPerSample;
        /// <summary>
        /// ������
        /// </summary>
        public UInt32 nSamplesPerSec;
    }

    /// <summary>
    /// �汾��Ϣ
    /// ����ʱ���������֯�ǣ�yyyymmdd
    /// </summary>
    public struct DH_VERSION_INFO
    {
        /// <summary>
        /// �汾��:��16λ��ʾ���汾�ţ���16λ��ʾ�ΰ汾��
        /// </summary>
        public UInt32 dwSoftwareVersion;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public UInt32 dwSoftwareBuildDate;
        /// <summary>
        /// DSP�汾��
        /// </summary>
        public UInt32 dwDspSoftwareVersion;
        /// <summary>
        /// DSP�汾����ʱ��
        /// </summary>
        public UInt32 dwDspSoftwareBuildDate;
        /// <summary>
        /// ���汾
        /// </summary>
        public UInt32 dwPanelVersion;
        /// <summary>
        /// ��������������
        /// </summary>
        public UInt32 dwPanelSoftwareBuildDate;
        /// <summary>
        /// Ӳ���汾
        /// </summary>
        public UInt32 dwHardwareVersion;
        /// <summary>
        /// Ӳ����������
        /// </summary>
        public UInt32 dwHardwareDate;
        /// <summary>
        /// Web�汾
        /// </summary>
        public UInt32 dwWebVersion;
        /// <summary>
        /// Web��������
        /// </summary>
        public UInt32 dwWebBuildDate;
    }



    /// <summary>
    /// DSP��������
    /// </summary>
    public struct DH_DSP_ENCODECAP
    {
        /// <summary>
        /// ��Ƶ��ʽ���룬��λ��ʾ�豸�ܹ�֧�ֵ���Ƶ��ʽ
        /// </summary>
        public UInt32 dwVideoStandardMask;
        /// <summary>
        /// �ֱ������룬��λ��ʾ�豸�ܹ�֧�ֵķֱ�������
        /// </summary>
        public UInt32 dwImageSizeMask;
        /// <summary>
        /// ����ģʽ���룬��λ��ʾ�豸�ܹ�֧�ֵı���ģʽ����
        /// </summary>
        public UInt32 dwEncodeModeMask;
        /// <summary>
        /// ��λ��ʾ�豸֧�ֵĶ�ý�幦�� ��һλ��ʾ֧��������,�ڶ�λ��ʾ֧�ָ�����1,����λ��ʾ֧�ָ�����2,����λ��ʾ֧��jpgץͼ
        /// </summary>
        public UInt32 dwStreamCap;
        /// <summary>
        /// ��ʾ������Ϊ���ֱ���ʱ��֧�ֵĸ������ֱ�������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public UInt32[] dwImageSizeMask_Assi;
        /// <summary>
        /// DSP ֧�ֵ���߱�������
        /// </summary>
        public UInt32 dwMaxEncodePower;
        /// <summary>
        /// ÿ�� DSP ֧�����������Ƶͨ���� 
        /// </summary>
        public UInt16 wMaxSupportChannel;
        /// <summary>
        /// DSP ÿͨ���������������Ƿ�ͬ�� 0-��ͬ��, 1-ͬ��
        /// </summary>
        public UInt16 wChannelMaxSetSync;
    }

    /// <summary>
    /// �豸��Ϣ����
    /// </summary>
    public struct DHDEV_SYSTEM_ATTR_CFG
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 dwSize;
        /*�������豸��ֻ������*/
        /// <summary>
        /// �汾
        /// </summary>
        public DH_VERSION_INFO stVersion;
        /// <summary>
        /// DSP��������
        /// </summary>
        public DH_DSP_ENCODECAP stDspEncodeCap;
        /// <summary>
        /// ���к�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] szDevSerialNo;
        /// <summary>
        /// ���к�ת���ַ���
        /// </summary>
        /// <returns></returns>
        public string DevSerialNo()
        {
            string result = "";
            foreach (byte bt in szDevSerialNo)
            {
                result += bt.ToString("D");
            }
            return result;
        }
        /// <summary>
        /// �豸���ͣ���ö��NET_DEVICE_TYPE
        /// </summary>
        public byte byDevType;
        /// <summary>
        /// ��ʾ��׼�����豸��������
        /// </summary>
        /// <returns></returns>
        public string DevType()
        {
            string result = "";
            switch(int.Parse(byDevType.ToString()))
            {
                case (int)NET_DEVICE_TYPE.NET_DVR_DDNS:
                    result = "DDNS������";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MEPG4_SH2:
                    result = "MPEG4�Ӻ�¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MEPG4_ST2:
                    result = "MPEG4��ͨ¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG1_2:
                    result = "MPEG1��·¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG1_8:
                    result = "MPEG4��·¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG4_16:
                    result = "MPEG4ʮ��¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG4_8:
                    result = "MPEG4��·¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG4_GBE:
                    result = "MPEG4��ͨ������ǿ��¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG4_NVSII:
                    result = "MPEG4������Ƶ������II��";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_MPEG4_SX2:
                    result = "MPEG4����ʮ��·¼���";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_NONREALTIME:
                    result = "��ʵʱ";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_NONREALTIME_MACE:
                    result = "��ʵʱMACE";
                    break;
                case (int)NET_DEVICE_TYPE.NET_DVR_STD_NEW:
                    result = "�±�׼����Э��";
                    break;
                case (int)NET_DEVICE_TYPE.NET_NVS_MPEG1:
                    result = "������Ƶ������";
                    break;
                case (int)NET_DEVICE_TYPE.NET_PRODUCT_NONE:
                    result = "��";
                    break;
            }
            return result;
        }
        /// <summary>
        /// �豸��ϸ�ͺţ��ַ�����ʽ������Ϊ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szDevType;
        /// <summary>
        /// ��Ƶ������
        /// </summary>
        public byte byVideoCaptureNum;
        /// <summary>
        /// ��Ƶ������
        /// </summary>
        public byte byAudioCaptureNum;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byTalkInChanNum;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byTalkOutChanNum;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byDecodeChanNum;
        /// <summary>
        /// �����������
        /// </summary>
        public byte byAlarmInNum;
        /// <summary>
        /// �����������
        /// </summary>
        public byte byAlarmOutNum;
        /// <summary>
        /// �������
        /// </summary>
        public byte byNetIONum;
        /// <summary>
        /// USB������
        /// </summary>
        public byte byUsbIONum;
        /// <summary>
        /// IDE����
        /// </summary>
        public byte byIdeIONum;
        /// <summary>
        /// ��������
        /// </summary>
        public byte byComIONum;
        /// <summary>
        /// ��������
        /// </summary>
        public byte byLPTIONum;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byVgaIONum;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byIdeControlNum;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byIdeControlType;
        /// <summary>
        /// NSP����չ����
        /// </summary>
        public byte byCapability;
        /// <summary>
        /// ��Ƶ�����������
        /// </summary>
        public byte byMatrixOutNum;
        /*�������豸�Ŀ�д����*/
        /// <summary>
        /// Ӳ��������ʽ�����ǡ�ֹͣ��
        /// </summary>
        public byte byOverWrite;
        /// <summary>
        /// ¼��������
        /// </summary>
        public byte byRecordLen;
        /// <summary>
        /// NSP
        /// </summary>
        public byte byStartChanNo;
        /// <summary>
        /// �豸��ţ�����ң��
        /// </summary>
        public UInt16 wDevNo;
        /// <summary>
        /// ��Ƶ��ʽ
        /// </summary>
        public byte byVideoStandard;
        /// <summary>
        /// ���ڸ�ʽ
        /// </summary>
        public byte byDateFormat;
        /// <summary>
        /// ���ڷָ��(0-"."�� 1-"-"�� 2-"/")
        /// </summary>
        public byte byDateSprtr;
        /// <summary>
        /// ʱ���ʽ (0-24Сʱ��1��12Сʱ)
        /// </summary>
        public byte byTimeFmt;
        /// <summary>
        /// ������
        /// </summary>
        public byte byReserved;
    }

    /// <summary>
    /// ʱ��νṹ  
    /// </summary>
    public struct DH_TSECT
    {
        public bool bEnable;
        public int iBeginHour;
        public int iBeginMin;
        public int iBeginSec;
        public int iEndHour;
        public int iEndMin;
        public int iEndSec;
    }

    /// <summary>
    /// ʱ��νṹ[����6]
    /// </summary>
    public struct DH_REC_TSECT
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public DH_TSECT[] sTSECT;
    }
    
    /// <summary>
    /// ����:���߾ఴ����8192�ı��� 
    /// </summary>
    public struct DH_RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    /// <summary>
    /// OSD���Խṹ 
    /// </summary>
    public struct DH_ENCODE_WIDGET
    {
        /// <summary>
        /// �����ǰ��RGB����͸����  
        /// </summary>
        public UInt32 rgbaFrontground;
        /// <summary>
        /// ����ĺ�RGB����͸���� 
        /// </summary>
        public UInt32 rgbaBackground;
        /// <summary>
        /// λ��  
        /// </summary>
        public DH_RECT rcRect;
        /// <summary>
        /// �����ʾ
        /// </summary>
        public byte bShow;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
    }

    /// <summary>
    /// ͨ������Ƶ���� 
    /// </summary>
    public struct DH_VIDEOENC_OPT
    {
        //��Ƶ����
        /// <summary>
        /// ��Ƶʹ��:1���򿪣�0���ر� 
        /// </summary>
        public byte byVideoEnable;
        /// <summary>
        /// ��������,���ճ�������
        /// </summary>
        public byte byBitRateControl;
        /// <summary>
        /// ֡��
        /// </summary>
        public byte byFramesPerSec;
        /// <summary>
        /// ����ģʽ,���ճ������� 
        /// </summary>
        public byte byEncodeMode;
        /// <summary>
        /// �ֱ��ʲ�,���ճ������� 
        /// </summary>
        public byte byImageSize;
        /// <summary>
        /// ����1-6 
        /// </summary>
        public byte byImageQlty;
        /// <summary>
        /// ����������, ��Χ��50~4*1024 (k)
        /// </summary>
        public UInt16 wLimitStream;

        //��Ƶ����
        /// <summary>
        /// ��Ƶʹ��:1���򿪣�0���ر�
        /// </summary>
        public byte byAudioEnable;
        /// <summary>
        /// �������ͣ���PCM
        /// </summary>
        public byte wFormatTag;
        /// <summary>
        /// ������
        /// </summary>
        public UInt16 nChannels;
        /// <summary>
        /// �������	
        /// </summary>
        public UInt16 wBitsPerSample;
        /// <summary>
        /// ������
        /// </summary>
        public UInt32 nSamplesPerSec;
        /// <summary>
        /// ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] reserved;
    }

    /// <summary>
    /// ������ɫ����
    /// </summary>
    public struct DH_COLOR_CFG
    {
        public DH_TSECT stSect;
        /// <summary>
        /// ����	0-100
        /// </summary>
        public byte byBrightness;
        /// <summary>
        /// �Աȶ�	0-100
        /// </summary>
        public byte byContrast;
        /// <summary>
        /// ���Ͷ�	0-100
        /// </summary>
        public byte bySaturation;
        /// <summary>
        /// ɫ��	0-100
        /// </summary>
        public byte byHue;
        /// <summary>
        /// ����ʹ��	  
        /// </summary>
        public byte byGainEn;
        /// <summary>
        /// ����	0-100
        /// </summary>
        public byte byGain;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
    }



    /// <summary>
    /// ͼ��ͨ�����Խṹ��
    /// </summary>
    public struct DHDEV_CHANNEL_CFG
    {
        public UInt32 dwSize;
        /// <summary>
        /// 
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szChannelName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szChannelName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public DH_VIDEOENC_OPT[] stMainVideoEncOpt;
        /// <summary>
        ///  ͨ��ָ��������	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public DH_VIDEOENC_OPT[] stAssiVideoEncOpt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public DH_COLOR_CFG[] stColorCfg;
        public DH_ENCODE_WIDGET stTimeOSD;
        public DH_ENCODE_WIDGET stChannelOSD;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public DH_ENCODE_WIDGET[] stBlindCover;

        /// <summary>
        ///  �����ڸǿ���,0x00��ʹ���ڸǣ�0x01���ڸ�,�豸����Ԥ����0x10���ڸ�¼�񣨼�����Ԥ������0x11���ڸ�
        ///  </summary>
        public byte byBlindEnable;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
    }

    /// <summary>
    /// Ԥ��ͼ�����
    /// </summary>
    public struct DHDEV_PREVIEW_CFG
    {
        public UInt32 dwSize;
        public DH_VIDEOENC_OPT stPreView;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public DH_COLOR_CFG[] stColorCfg;
    }

    /// <summary>
    /// �����Խ���Ƶ����
    /// </summary>
    public struct DHDEV_TALK_CFG
    {
        #region << ��Ƶ������� >>
        /// <summary>
        /// �������ͣ���PCM
        /// </summary>
        public byte byInFormatTag;
        /// <summary>
        /// ������
        /// </summary>
        public byte byInChannels;
        /// <summary>
        /// �������	
        /// </summary>
        public UInt16 wInBitsPerSample;
        /// <summary>
        /// ������
        /// </summary>
        public UInt32 dwInSamplesPerSec;

        #endregion

        #region << ��Ƶ������� >>
        /// <summary>
        /// �������ͣ���PCM
        /// </summary>
        public byte byOutFormatTag;
        /// <summary>
        /// ������
        /// </summary>
        public byte byOutChannels;
        /// <summary>
        /// �������
        /// </summary>
        public UInt16 wOutBitsPerSample;
        /// <summary>
        /// ������
        /// </summary>
        public UInt32 dwOutSamplesPerSec;
        #endregion

    }

    /// <summary>
    /// ��ʱ¼��
    /// </summary>
    public struct DHDEV_RECORD_CFG
    {
        
        public UInt32 dwSize;
        /// <summary>
        /// ʱ��νṹ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stSect;
        /// <summary>
        /// Ԥ¼ʱ��,��λ��s,0��ʾ��Ԥ¼ 
        /// </summary>
        public byte byPreRecordLen;
        /// <summary>
        /// ¼�����࿪��
        /// </summary>
        public byte byRedundancyEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
    }

    /// <summary>
    /// ��������
    /// </summary>
    public struct DH_PTZ_LINK
    {
        public int iType;
        public int iValue;
    }

    /// <summary>
    /// ��Ϣ��������
    /// ��Ϣ����ʽ,����ͬʱ���ִ���ʽ,����
    /// 0x00000001 - ����:�ϴ����������
    /// 0x00000002 - ¼��:����
    /// 0x00000004 - ��̨����
    /// 0x00000008 - �����ʼ�
    /// 0x00000010 - �豸���ر�����Ѳ
    /// 0x00000020 - �豸��ʾʹ��
    /// 0x00000040 - �豸�������ʹ��
    /// 0x00000080 - Ftp�ϴ�ʹ��
    /// 0x00000100 - ����
    /// 0x00000200 - ������ʾ
    /// 0x00000400 - ץͼʹ��
    /// </summary>
    public struct DH_MSG_HANDLE
    {
        /// <summary>
        /// ��ǰ������֧�ֵĴ���ʽ����λ�����ʾ
        /// </summary>
        public UInt32 dwActionMask;
        /// <summary>
        /// ������������λ�����ʾ�����嶯������Ҫ�Ĳ����ڸ��Ե�����������
        /// </summary>
        public UInt32 dwActionFlag;
        /// <summary>
        /// �������������ͨ��,Ϊ 1 ��ʾ���������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRelAlarmOut;
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public UInt32 dwDuration;
        /// <summary>
        /// ����¼��	, ����������¼��ͨ��,Ϊ1��ʾ������ͨ��	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byRecordChannel;
        /// <summary>
        /// ¼�����ʱ�� 
        /// </summary>
        public UInt32 dwRecLatch;
        /// <summary>
        /// ץͼͨ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] bySnap;
        /// <summary>
        /// ��Ѳͨ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] byTour;
        /// <summary>
        /// ��̨����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_PTZ_LINK[] struPtzLink;
    }

    /// <summary>
    /// �ⲿ����
    /// </summary>
    public struct DH_ALARMIN_CFG
    {
        /// <summary>
        /// ����������,0������,1������  	
        /// </summary>
        public byte byAlarmType;
        /// <summary>
        /// ����ʹ��
        /// </summary>
        public byte byAlarmEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stSect;
        /// <summary>
        /// ����ʽ
        /// </summary>
        public DH_MSG_HANDLE struHandle;
    }

    /// <summary>
    /// �������[����16]
    /// </summary>
    public struct DH_DETECT
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst =32)]
        public byte[] Detected;
    }

    /// <summary>
    /// ��̬���
    /// </summary>
    public struct DH_MOTION_DETECT_CFG
    {
        /// <summary>
        /// ��̬��ⱨ��ʹ��
        /// </summary>
        public byte byMotionEn;

        public byte byReserved;
        /// <summary>
        /// ������
        /// </summary>
        public UInt16 wSenseLevel;
        /// <summary>
        /// ��̬������������
        /// </summary>
        public UInt16 wMotionRow;
        /// <summary>
        /// ��̬������������
        /// </summary>
        public UInt16 wMotionCol;
        /// <summary>
        /// ������򣬹�32*32������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public DH_DETECT[] byDetected;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stSect;
        /// <summary>
        /// ����ʽ
        /// </summary>
        public DH_MSG_HANDLE struHandle;
    }

    /// <summary>
    /// ��Ƶ��ʧ����
    /// </summary>
    public struct DH_VIDEO_LOST_CFG
    {
        /// <summary>
        /// ��Ƶ��ʧ����ʹ��
        /// </summary>
        public byte byAlarmEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stSect;
        /// <summary>
        /// ����ʽ
        /// </summary>
        public DH_MSG_HANDLE struHandle;
    }

    /// <summary>
    /// ͼ���ڵ�����
    /// </summary>
    public struct DH_BLIND_CFG
    {
        /// <summary>
        /// ʹ��
        /// </summary>
        public byte byBlindEnable;
        /// <summary>
        /// ������1-6 
        /// </summary>
        public byte byBlindLevel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stSect;
        /// <summary>
        /// ����ʽ
        /// </summary>
        public DH_MSG_HANDLE struHandle;
    }

    /// <summary>
    /// Ӳ����Ϣ(�ڲ�����)
    /// </summary>
    public struct DH_DISK_ALARM_CFG
    {
        /// <summary>
        /// ��Ӳ��ʱ����
        /// </summary>
        public byte byNoDiskEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved_1;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stNDSect;
        /// <summary>
        /// ����ʽ 
        /// </summary>
        public DH_MSG_HANDLE struNDHandle;
        /// <summary>
        /// Ӳ�̵�����ʱ����
        /// </summary>
        public byte byLowCapEn;
        /// <summary>
        /// ������ֵ 0-99
        /// </summary>
        public byte byLowerLimit;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved_2;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stLCSect;
        /// <summary>
        /// ����ʽ  
        /// </summary>
        public DH_MSG_HANDLE struLCHandle;
        /// <summary>
        /// Ӳ�̹��ϱ���
        /// </summary>
        public byte byDiskErrEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved_3;
        /// <summary>
        /// NSP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public DH_REC_TSECT[] stEDSect;
        /// <summary>
        /// ����ʽ 
        /// </summary>
        public DH_MSG_HANDLE struEDHandle;
    }

    public struct DH_NETBROKEN_ALARM_CFG
    {
        public byte byEnable;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
        public DH_MSG_HANDLE struHandle;
    }

    /// <summary>
    /// ��������
    /// </summary>
    public struct DHDEV_ALARM_SCHEDULE
    {
        public UInt32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_ALARMIN_CFG[] struLocalAlmIn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_ALARMIN_CFG[] struNetAlmIn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_MOTION_DETECT_CFG[] struMotion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_VIDEO_LOST_CFG[] struVideoLost;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_BLIND_CFG[] struBlind;
        public DH_DISK_ALARM_CFG struDiskAlarm;
        public DH_NETBROKEN_ALARM_CFG struNetBrokenAlarm;
    }


    // ����������չ�ṹ��
    public struct DH_MSG_HANDLE_EX
    {
	    /* ��Ϣ����ʽ������ͬʱ���ִ���ʽ������
	     * 0x00000001 - �����ϴ�
	     * 0x00000002 - ����¼��
	     * 0x00000004 - ��̨����
	     * 0x00000008 - �����ʼ�
	     * 0x00000010 - ������Ѳ
	     * 0x00000020 - ������ʾ
	     * 0x00000040 - �������
	     * 0x00000080 - Ftp�ϴ�
	     * 0x00000100 - ����
	     * 0x00000200 - ������ʾ
	     * 0x00000400 - ץͼ
	    */

        /// <summary>
        /// ��ǰ������֧�ֵĴ���ʽ����λ�����ʾ
        /// </summary>
	    public UInt32				dwActionMask;

        /// <summary>
        /// ������������λ�����ʾ�����嶯������Ҫ�Ĳ����ڸ��Ե�����������
        /// </summary>
	    public UInt32				dwActionFlag;
    	
        /// <summary>
        /// �������������ͨ�������������������Ϊ1��ʾ���������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]				byRelAlarmOut;
        /// <summary>
        /// ��������ʱ��
        /// </summary>
	    public UInt32				dwDuration;

        /// <summary>
        /// ����¼��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]				byRecordChannel; /* ����������¼��ͨ����Ϊ1��ʾ������ͨ�� */
        /// <summary>
        /// ¼�����ʱ��
        /// </summary>
	    public UInt32				dwRecLatch;

        /// <summary>
        /// ץͼͨ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]				bySnap;
        /// <summary>
        /// ��Ѳͨ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]				byTour;

        /// <summary>
        /// ��̨����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public DH_PTZ_LINK[]			struPtzLink;
        /// <summary>
        /// ������ʼ��ʱʱ�䣬sΪ��λ����Χ��0~15��Ĭ��ֵ��0
        /// </summary>
	    public UInt32				dwEventLatch;
        /// <summary>
        /// �����������������ͨ�������������������Ϊ1��ʾ���������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]			byRelWIAlarmOut;
	    public byte				bMessageToNet;
        /// <summary>
        /// ���ű���ʹ��
        /// </summary>
	    public byte                bMMSEn;
        /// <summary>
        /// ���ŷ���ץͼ����
        /// </summary>
	    public byte                bySnapshotTimes;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte				bMatrixEn;
        /// <summary>
        /// ��������
        /// </summary>
	    public UInt32				dwMatrix;
	    /// <summary>
	    /// ��־ʹ�ܣ�Ŀǰֻ����WTN��̬�����ʹ��
	    /// </summary>
	    public byte				bLog;
        /// <summary>
        /// ץͼ֡�����ÿ������֡ץһ��ͼƬ��һ��ʱ����ץ�ĵ���������ץͼ֡���йء�0��ʾ����֡������ץ�ġ�
        /// </summary>
	    public byte				bSnapshotPeriod;
        /// <summary>
        /// ��Ѳͨ�� 32-63·
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]				byTour2;
        /// <summary>
        /// 0��ͼƬ������1��¼�񸽼�
        /// </summary>
	    public byte                byEmailType;
        /// <summary>
        /// ����¼��ʱ����󳤶ȣ���λMB
        /// </summary>
	    public byte                byEmailMaxLength;
        /// <summary>
        /// ������¼��ʱ���ʱ�䳤�ȣ���λ��
        /// </summary>
	    public byte                byEmailMaxTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 475)]
	    public byte[]				byReserved;   
    }



    /// <summary>
    /// �ⲿ������չ
    /// </summary>
    public struct DH_ALARMIN_CFG_EX
    {
        /// <summary>
        /// ���������ͣ�0�����գ�1������
        /// </summary>
	    public byte				byAlarmType;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte				byAlarmEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[]				byReserved;				
        /// <summary>
        /// NSP
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7*6)]
	    public DH_TSECT[]			stSect;
        /// <summary>
        /// ����ʽ
        /// </summary>
	    public DH_MSG_HANDLE_EX	struHandle;
    }

    /// <summary>
    /// ��̫������
    /// </summary>
    public struct DH_ETHERNET
    {
        /// <summary>
        /// DVR IP ��ַ  
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sDevIPAddr;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 16)]
        public byte[] sDevIPAddr;
        /// <summary>
        /// DVR IP ��ַ����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sDevIPMask;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] sDevIPMask;
        /// <summary>
        ///  ���ص�ַ   
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sGatewayIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] sGatewayIP;
        /// <summary>
        /// NSP
        /// 10M/100M  ����Ӧ,���� 
        /// 1-10MBase - T
        /// 2-10MBase-T ȫ˫�� 
        /// 3-100MBase - TX
        /// 4-100M ȫ˫��
        /// 5-10M/100M  ����Ӧ 
        /// </summary>
        public UInt32 dwNetInterface;
        /// <summary>
        /// MAC��ַ��ֻ��   
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 40)]
        //public char[] byMACAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] byMACAddr;
    }

    /// <summary>
    /// Զ����������
    /// </summary>
    public struct DH_REMOTE_HOST
    {
        /// <summary>
        /// ����ʹ��
        /// </summary>
        public byte byEnable;
        public byte byReserved;
        /// <summary>
        /// Զ�������˿�
        /// </summary>
        public UInt16 wHostPort;
        /// <summary>
        /// Զ������ IP ��ַ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sHostIPAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] sHostIPAddr;
        /// <summary>
        /// Զ������ �û���
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 64)]
        //public char[] sHostUser;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] sHostUser;
        /// <summary>
        /// Զ������ ����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] sHostPassword;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] sHostPassword;
    }

    /// <summary>
    /// �ʼ�����
    /// </summary>
    public struct DH_MAIL_CFG
    {
        /// <summary>
        /// �ʼ�������IP��ַ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sMailIPAddr;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        public byte[] sMailIPAddr;

        /// <summary>
        /// �ʼ��������˿�
        /// </summary>
        public UInt16 wMailPort;
        /// <summary>
        /// ����
        /// </summary>
        public UInt16 wReserved;
        /// <summary>
        /// ���͵�ַ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] sSenderAddr;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        public byte[] sSenderAddr;
        /// <summary>
        /// �û��� 
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sUserName;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 16)]
        public byte[] sUserName;
        ///// <summary>
        ///// �û������ַ���
        ///// </summary>
        ///// <returns></returns>
        //public string UserName()
        //{
        //    string result = "";
        //    foreach (char chr in sUserName)
        //    {
        //        if (chr != '\0')
        //        {
        //            result += chr.ToString();
        //        }
        //    }
        //    return result;
        //}
        /// <summary>
        /// �û�����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sUserPsw;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] sUserPsw;

        ///// <summary>
        ///// �û�������ַ���
        ///// </summary>
        ///// <returns></returns>
        //public string UserPsw()
        //{
        //    string result = "";
        //    foreach (char chr in sUserPsw)
        //    {
        //        if (chr != '\0')
        //        {
        //            result += chr.ToString();
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// Ŀ�ĵ�ַ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] sDestAddr;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 128)]
        public byte[] sDestAddr;
        /// <summary>
        /// ���͵�ַ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] sCcAddr;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 128)]
        public byte[] sCcAddr;
        /// <summary>
        /// ���͵�ַ���ַ���
        /// </summary>
        /// <returns></returns>
        public string CcAddr()
        {
            string result = "";
            foreach (char chr in sCcAddr)
            {
                if (chr != '\0')
                {
                    result += chr.ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// ������ַ
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] sBccAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] sBccAddr;
        /// <summary>
        /// ������ַ���ַ���
        /// </summary>
        /// <returns></returns>
        public string BccAddr()
        {
            string result = "";
            foreach (char chr in sBccAddr)
            {
                if (chr != '\0')
                {
                    result += chr.ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// ����
        /// </summary>        
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 64)]
        //public char[] sSubject;        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] sSubject;       
        /// <summary>
        /// ������ַ���
        /// </summary>
        /// <returns></returns>
        public string Subject()
        {
            string result = "";
            foreach (byte chr in sSubject)
            {
                if (chr != '\0')
                {
                    result += (char)chr;
                }
            }
            return result;
        }
    }

    /// <summary>
    /// �������ýṹ��
    /// </summary>
    public struct DHDEV_NET_CFG
    {
        public UInt32 dwSize;
        /// <summary>
        /// �豸������
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sDevName;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 16)]
        public byte[] sDevName;
        /// <summary>
        /// �豸���������ַ������
        /// </summary>
        /// <returns>���������ַ���</returns>
        public string DevName()
        {
            string result = "";
            foreach (char chr in sDevName)
            {
                if (chr != '\0')
                {
                    result += chr.ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// TCP���������(һ��ָ��Ƶ����������) 
        /// </summary>
        public UInt16 wTcpMaxConnectNum;
        /// <summary>
        /// TCP֡���˿�
        /// </summary>
        public UInt16 wTcpPort;
        /// <summary>
        /// UDP�����˿�
        /// </summary>
        public UInt16 wUdpPort;
        /// <summary>
        /// HTTP�˿ں� 
        /// </summary>
        public UInt16 wHttpPort;
        /// <summary>
        /// HTTPS�˿ں� 
        /// </summary>
        public UInt16 wHttpsPort;
        /// <summary>
        /// SSL�˿ں�
        /// </summary>
        public UInt16 wSslPort;
        /// <summary>
        /// ��̫����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public DH_ETHERNET[] stEtherNet;
        /// <summary>
        /// ����������
        /// </summary>
        public DH_REMOTE_HOST struAlarmHost;
        /// <summary>
        /// ��־������ 
        /// </summary>
        public DH_REMOTE_HOST struLogHost;
        /// <summary>
        /// SMTP������
        /// </summary>
        public DH_REMOTE_HOST struSmtpHost;
        /// <summary>
        /// �ಥ��
        /// </summary>
        public DH_REMOTE_HOST struMultiCast;
        /// <summary>
        /// NFS������
        /// </summary>
        public DH_REMOTE_HOST struNfs;
        /// <summary>
        /// PPPoE������
        /// </summary>
        public DH_REMOTE_HOST struPppoe;
        /// <summary>
        /// PPPoEע�᷵�ص�IP
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] sPppoeIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] sPppoeIP;
        /// <summary>
        /// DDNS������
        /// </summary>
        public DH_REMOTE_HOST struDdns;
        /// <summary>
        /// DDNS������
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 64)]
        //public char[] sDdnsHostName;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 64)]
        public byte[] sDdnsHostName;
        /// <summary>
        /// DNS������
        /// </summary>
        public DH_REMOTE_HOST struDns;
        /// <summary>
        /// �ʼ�����
        /// </summary>
        public DH_MAIL_CFG struMail;
    }

    /// <summary>
    /// ���ڻ�������
    /// </summary>
    public struct DH_COMM_PROP
    {
        /// <summary>
        /// ����λ 0:5;1:6;2:7;3-8;
        /// </summary>
        public byte byDataBit;
        /// <summary>
        /// ֹͣλ 0:1λ;1:1.5λ; 2:2λ;
        /// </summary>
        public byte byStopBit;
        /// <summary>
        /// У��λ 0:��У��;1:��У��; 2:żУ��;
        /// </summary>
        public byte byParity;
        /// <summary>
        /// ������ 0:300;1:600;2:1200;3:2400;4:4800;5:9600;6:19200;7:38400;8:57600;9:115200;
        /// </summary>
        public byte byBaudRate;
    }

    /// <summary>
    /// 485����������
    /// </summary>
    public struct DH_485_CFG
    {
        public DH_COMM_PROP struComm;
        /// <summary>
        /// Э������ ����Э����±꣬��̬�仯
        /// </summary>
        public UInt16 wProtocol;
        /// <summary>
        /// ��������ַ:0 - 255
        /// </summary>
        public UInt16 wDecoderAddress;
    }

    /// <summary>
    /// 232��������
    /// </summary>
    public struct DH_RS232_CFG
    {
        public DH_COMM_PROP struComm;
        public byte byFunction;			// ���ڹ��ܣ���Ӧ��������ȡ���Ĺ������б� 

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
    }


    /// <summary>
    /// Э����
    /// </summary>
    public struct DH_PROANDFUN_NAME
    {
        /// <summary>
        /// Э����[����16]
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] ProName;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 16)]
        public byte[] ProName;
    }


    /// <summary>
    /// �������ýṹ��
    /// </summary>
    public struct DHDEV_COMM_CFG
    {
        /// <summary>
        /// ������Э��
        /// </summary>
        public UInt32 dwSize;
        /// <summary>
        /// Э�����
        /// </summary>
        public UInt32 dwDecProListNum;
        /// <summary>
        /// Э�����б�100
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public DH_PROANDFUN_NAME[] DecProName;
        /// <summary>
        /// ����������ǰ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_485_CFG[] stDecoder;
        /// <summary>
        /// 232���ܸ���
        /// </summary>
        public UInt32 dw232FuncNameNum;
        /// <summary>
        /// �������б�10*16
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 10)]
        public DH_PROANDFUN_NAME[] s232FuncName;
        /// <summary>
        /// ��232���ڵ�ǰ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public DH_RS232_CFG[] st232;
    }

    /// <summary>
    /// �Զ�ά������
    /// </summary>
    public struct DHDEV_AUTOMT_CFG
    {
        /// <summary>
        /// �Զ�����
        /// </summary>
        public UInt32 dwSize;
        /// <summary>
        ///  �Զ����������趨 0:�Ӳ�;1:ÿ��;2:ÿ������;3:ÿ����һ;......
        /// </summary>
        public byte byAutoRebootDay;
        /// <summary>
        /// �Զ�����ʱ���趨 0:0:00;1:1:00;........23:23:00;
        /// </summary>
        public byte byAutoRebootTime;
        /// <summary>
        /// �Զ�ɾ���ļ� 0:�Ӳ�;1:24H;2:48H;3:72H;4:96H:5:һ��;6:һ��
        /// </summary>
        public byte byAutoDeleteFilesTime;
        /// <summary>
        /// ����λ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
        public byte[] reserved;
    }

    /// <summary>
    /// �������Ʋ�������
    /// </summary>
    public struct DH_VIDEOGROUP_CFG
    {
        /// <summary>
        /// ��Ƶ��� 0:��Ч;1:�豸ͨ������ʾ��Ӧͨ��;�豸ͨ����+1����all;
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] byVideoOut;
        /// <summary>
        /// ��Ѳ�������λ��, 5-300 
        /// </summary>
        public int iInterval;
        /// <summary>
        /// �Ƿ���Ѳ 
        /// </summary>
        public byte byEnableTour;
        /// <summary>
        /// ��������ͨ�� 0:��Ч;1:����ͨ������ʾ��Ӧͨ��;����ͨ����+1����1-4;����ͨ����+2����5-8...;�ο����ؽ���
        /// </summary>
        public byte byAlarmChannel;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
    }

    /// <summary>
    /// ����������Ʋ�������
    /// </summary>
    public struct DHDEV_VIDEO_MATRIX_CFG
    {
        public UInt32 dwSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public DH_VIDEOGROUP_CFG[] struVideoGroup;
    }

    /// <summary>
    /// ddns����
    /// </summary>
    public struct DH_DDNS_SERVER_CFG
    {
        /// <summary>
        /// ddns������id��
        /// </summary>
        public UInt32 dwId;
        /// <summary>
        /// ʹ�ܣ�ͬһʱ��ֻ����һ��ddns����������ʹ��״̬
        /// </summary>
        public bool bEnable;
        /// <summary>
        /// ���������ͣ�ϣ��..
        /// </summary>	
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szServerType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szServerType;
        /// <summary>
        /// ������ip
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] szServerIp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szServerIp;
        /// <summary>
        /// �������˿�
        /// </summary>
        public UInt32 dwServerPort;
        /// <summary>
        /// dvr������jecke.3322.org
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 256)]
        //public char[] szDomainName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szDomainName;
        /// <summary>
        /// �û���
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szUserName;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] szUserName;
        /// <summary>
        /// ����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szUserPsw;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] szUserPsw;
        /// <summary>
        /// ��������������"dahua ddns"
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szAlias;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] szAlias;
    }
    /// <summary>
    /// ��ddns����
    /// </summary>
    public struct DHDEV_MULTI_DDNS_CFG
    {
        public UInt32 dwSize;
        public UInt32 dwDdnsServerNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public DH_DDNS_SERVER_CFG[] struDdnsServer;
    }

    /// <summary>
    /// ץͼ��������
    /// </summary>
    public struct DHDEV_SNAP_CFG
    {
        public UInt32 dwSize;
        /// <summary>
        /// ��ʱץͼ���أ�����ץͼ�����ڸ������������������֣�
        /// </summary>
        public byte bTimingEnable;
        public byte bReserved;
        /// <summary>
        /// ��ʱץͼʱ��������λΪ��,Ŀǰ�豸֧������ץͼʱ����Ϊ30����
        /// </summary>
        public ushort PicTimeInterval;
        /// <summary>
        /// ץͼ�������ã���֧�����еķֱ��ʡ����ʡ�֡�����ã�֡���������Ǹ�������ʾһ��ץͼ�Ĵ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public DH_VIDEOENC_OPT[] struSnapEnc;
    }

    /// <summary>
    /// web·������
    /// </summary>
    public struct DHDEV_URL_CFG
    {
        public UInt32 dwSize;
        /// <summary>
        /// �Ƿ�ץͼ
        /// </summary>
        public bool bSnapEnable;
        /// <summary>
        /// ץͼ����
        /// </summary>
        public int iSnapInterval;
        /// <summary>
        /// HTTP����IP
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] szHostIp;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 16)]
        public byte[] szHostIp;
        public UInt16 wHostPort;
        /// <summary>
        /// ״̬��Ϣ���ͼ��
        /// </summary>
        public int iMsgInterval;
        /// <summary>
        /// ״̬��Ϣ�ϴ�URL
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] szUrlState;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szUrlState;
        /// <summary>
        /// ͼƬ�ϴ�URL
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] szUrlImage;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 128)]
        public byte[] szUrlImage;
        /// <summary>
        /// ������web���
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 48)]
        //public char[] szDevId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] szDevId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
    }


    /// <summary>
    /// 
    /// </summary>
    public struct struPeriod
    {
        /// <summary>
        /// ��ʱ����ڵġ�ʹ�ܡ���Ч���ɺ���
        /// </summary>
        public DH_TSECT struSect;
        /// <summary>
        /// �ϴ���̬���¼��
        /// </summary>
        public bool bMdEn;
        /// <summary>
        /// �ϴ��ⲿ����¼��
        /// </summary>
        public bool bAlarmEn;
        /// <summary>
        /// �ϴ���ͨ��ʱ¼��
        /// </summary>	
        public bool bTimerEn;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public UInt32[] dwRev;
    }
    /// <summary>
    /// FTP�ϴ�����
    /// </summary>
    public struct DH_FTP_UPLOAD_CFG
    {

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public struPeriod[] Period;
    }

    /// <summary>
    /// FTP�ϴ�����
    /// </summary>
    public struct DHDEV_FTP_PROTO_CFG
    {
        public UInt32 dwSize;

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool bEnable;
        /// <summary>
        /// ����IP
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] szHostIp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szHostIp;
        /// <summary>
        /// �����˿�
        /// </summary>
        public UInt32 wHostPort;
        /// <summary>
        /// FTPĿ¼·��
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 240)]
        //public char[] szDirName;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 240)]
        public byte[] szDirName;
        /// <summary>
        /// �û���
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 64)]
        //public char[] szUserName;
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 64)]
        public byte[] szUserName;
        /// <summary>
        /// ����
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 64)]
        //public char[] szPassword;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 64)]
        public byte[] szPassword;
        /// <summary>
        /// �ļ�����
        /// </summary>
        public int iFileLen;
        /// <summary>
        /// �����ļ�ʱ����
        /// </summary>
        public int iInterval;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
        public DH_FTP_UPLOAD_CFG[] struUploadCfg;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 130)]
        public byte[] reserved;
    }

    /// <summary>
    /// ƽ̨�������� �� U��ͨƽ̨
    /// </summary>
    public struct DH_INTERVIDEO_UCOM_CHN_CFG
    {
        public bool bChnEn;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szChnId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szChnId;
    }

    /// <summary>
    /// ƽ̨�������� �� U��ͨƽ̨
    /// </summary>
    public struct DHDEV_INTERVIDEO_UCOM_CFG
    {
        public UInt32 dwSize;
        /// <summary>
        /// ���빦��ʹ����� 0:ʹ��
        /// </summary>
        public bool bFuncEnable;
        /// <summary>
        /// ����ʹ�����
        /// </summary>
        public bool bAliveEnable;
        /// <summary>
        /// �������ڣ���λ�룬0-3600
        /// </summary>
        public UInt32 dwAlivePeriod;
        /// <summary>
        /// CMS��IP
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] szServerIp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szServerIp;
        /// <summary>
        /// CMS��Port
        /// </summary>
        public UInt16 wServerPort;
        /// <summary>
        /// ע������
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 16)]
        //public char[] szRegPwd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szRegPwd;
        /// <summary>
        /// �豸id
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szDeviceId;
        [MarshalAs(UnmanagedType.ByValArray,  SizeConst = 32)]
        public byte[] szDeviceId;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szUserName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szUserName;
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 32)]
        //public char[] szPassWord;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPassWord;
        /// <summary>
        /// ͨ��id,en
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_INTERVIDEO_UCOM_CHN_CFG[] struChnInfo;
    }


    // IP��Ϣ��չ
    public struct DHDEV_IPIFILTER_INFO_EX
    {
        /// <summary>
        /// IP����
        /// </summary>
	    public UInt32 dwIPNum;
        /// <summary>
        /// IP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512*16)]
	    public byte[] SZIP;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] byReserve; 
    } ;

    // IP�������ýṹ����չ
    public struct DHDEV_IPIFILTER_CFG_EX
    {
	    public UInt32 dwSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public UInt32 dwEnable;
        /// <summary>
        /// ��ǰ�������ͣ�0�������� 1�����������豸ֻ��ʹһ��������Ч�������ǰ����������Ǻ�������
        /// </summary>
	    public UInt32 dwType;
        /// <summary>
        /// ������
        /// </summary>
	    public DHDEV_IPIFILTER_INFO_EX BannedIP;
        /// <summary>
        /// ������
        /// </summary>
	    public DHDEV_IPIFILTER_INFO_EX TrustIP;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] byReserve;
    }


    // MAC��IP������Ϣ
    public struct MACIP_INFO
    {
        /// <summary>
        /// ʹ��ʱ���ó�ʼ��Ϊ���ṹ���С
        /// </summary>
	    public UInt32	dwSize;
        /// <summary>
        /// MAC
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	    public byte[]	szMac;
        /// <summary>
        /// IP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]	szIp;
    }

    // MAC,IP�������ýṹ��
    public struct DHDEV_MACIPFILTER_CFG
    {
        /// <summary>
        /// ʹ��ʱ���ó�ʼ��Ϊ���ṹ���С
        /// </summary>
	    public UInt32   dwSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public UInt32   dwEnable;
        /// <summary>
        /// ��ǰ�������ͣ�0�������� 1�����������豸ֻ��ʹһ��������Ч�������ǰ����������Ǻ�������
        /// </summary>
	    public UInt32   dwType;
        /// <summary>
        /// ������MAC,IP����(MAC,IPһһ��Ӧ)
        /// </summary>
	    public UInt32   dwBannedMacIpNum;
        /// <summary>
        /// ������Mac,IP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	    public MACIP_INFO[]  stuBannedMacIp;
        /// <summary>
        /// ������MAC,IP����(MAC,IPһһ��Ӧ)
        /// </summary>
	    public UInt32   dwTrustMacIpNum;
        /// <summary>
        /// ������Mac,IP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	    public MACIP_INFO[]  stuTrustMacIp;
    } 

    /// <summary>
    /// ������Կ��Ϣ36���ֽ�
    /// </summary>
    public struct ENCRYPT_KEY_INFO
    {
        /// <summary>
        /// �Ƿ����0:������, 1:����
        /// </summary>
	    public byte         byEncryptEnable;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[]       byReserved;
        /// <summary>
        /// union
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]       byKey; 
        //public ENCRYPT_TYPE_UNION  stuEncryptTypeUinon;
    }


    /// <summary>
    /// �����㷨����
    /// </summary>
    public struct ALGO_PARAM_INFO
    {
        /// <summary>
        /// ��Կ���ȣ���ǰΪAES�㷨����ʱ����ʾ��Կλ��(Ŀǰ֧��128��192��256λ����, 
        /// ��: wEncryptLenthΪ128������Կ��ϢENCRYPT_KEY_INFO���byAesKey[0]~[15])
        /// ΪDES�㷨����ʱ����Կ���ȹ̶�Ϊ64λ
        /// Ϊ3DES�㷨����ʱ����ʾ��Կ�ĸ���(2��3����Կ)
        /// </summary>
	    public UInt16   wEncryptLenth; 
        /// <summary>
        /// ����ģʽ,�ο�ö������ EM_ENCRYPT_ALOG_WORKMODE 
        /// </summary>
	    public byte     byAlgoWorkMode; 
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13)]
	    public byte[]   reserved; 
    }

    /// <summary>
    /// ��������������Ϣ 
    /// </summary>
    public struct DHEDV_STREAM_ENCRYPT
    {
        /// <summary>
        /// �����㷨���ͣ�00: AES��01:DES��02: 3DES
        /// </summary>
        public byte    byEncrptAlgoType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]   byReserved1;
        /// <summary>
        /// �����㷨����
        /// </summary>
        public ALGO_PARAM_INFO     stuEncrptAlgoparam;
        /// <summary>
        /// ��ͨ������Կ��Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public ENCRYPT_KEY_INFO[]    stuEncryptKeys; 
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1388)]
        public byte[]       reserved2;
    }

    #endregion

    #region <<����ļ��ģ������--��ؽṹ��>>

    /// <summary>
    /// ���򶥵���Ϣ
    /// </summary>
    public struct CFG_POLYGON
    {
        public Int32 nX; //0~8191
        public Int32 nY;
    }

    /// <summary>
    /// Size
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct CFG_SIZE
    {
        /// <summary>
        /// ������(C++������union��ʾ��)
        /// </summary>
        [FieldOffset(0)]
        public float nWidth;
        [FieldOffset(0)]
        public float nArea;
        /// <summary>
        /// ��
        /// </summary>
        [FieldOffset(4)]
        public float nHeight;

    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    public struct CFG_REGION
    {
        public Int32 nPointNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYGON[] stuPolygon;
    }

    /// <summary>
    /// У׼����Ϣ
    /// </summary>
    public struct CFG_CALIBRATEBOX_INFO
    {
        /// <summary>
        /// У׼�����ĵ�����(��������һ����[0,8191]����)
        /// </summary>
        public CFG_POLYGON stuCenterPoint;
        /// <summary>
        /// ��Ի�׼У׼��ı���(����1��ʾ��׼���С��0.5��ʾ��׼���С��һ��)
        /// </summary>
        public float fRatio;
    }

    /// <summary>
    /// �ߴ������
    /// </summary>
    public struct CFG_SIZEFILTER_INFO
    {
        /// <summary>
        /// У׼�����
        /// </summary>
        public Int32 nCalibrateBoxNum;
        /// <summary>
        /// У׼��(Զ�˽��˱궨ģʽ����Ч)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEBOX_INFO[] stuCalibrateBoxs;
        /// <summary>
        /// ������ʽ�����Ƿ���Ч
        /// </summary>
        public byte bMeasureModeEnable;
        /// <summary>
        /// ������ʽ,0-���أ�����ҪԶ�ˡ����˱궨, 1-ʵ�ʳ��ȣ���λ����, 2-Զ�˽��˱궨�������
        /// </summary>
        public byte bMeasureMode;
        /// <summary>
        /// �������Ͳ����Ƿ���Ч
        /// </summary>
        public byte bFilterTypeEnable;
        // ByArea,ByRatio�������ݣ�ʹ�ö�����ByArea��ByRatioѡ����� 2012/03/06
        /// <summary>
        /// ��������:0:"ByLength",1:"ByArea", 2"ByWidthHeight"
        /// </summary>
        public byte bFilterType;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved;
        /// <summary>
        /// ������С�ߴ�����Ƿ���Ч
        /// </summary>
        public byte bFilterMinSizeEnable;
        /// <summary>
        /// �������ߴ�����Ƿ���Ч
        /// </summary>
        public byte bFilterMaxSizeEnable;
        /// <summary>
        /// ������С�ߴ� "ByLength"ģʽ�±�ʾ��ߵĳߴ磬"ByArea"ģʽ�¿��ʾ���������Ч(Զ�˽��˱궨ģʽ�±�ʾ��׼��Ŀ�߳ߴ�)��
        /// </summary>
        public CFG_SIZE stuFilterMinSize;
        /// <summary>
        /// �������ߴ� "ByLength"ģʽ�±�ʾ��ߵĳߴ磬"ByArea"ģʽ�¿��ʾ���������Ч(Զ�˽��˱궨ģʽ�±�ʾ��׼��Ŀ�߳ߴ�)��
        /// </summary>
        public CFG_SIZE stuFilterMaxSize;

        public byte abByArea;
        public byte abMinArea;
        public byte abMaxArea;
        public byte abMinAreaSize;
        public byte abMaxAreaSize;
        /// <summary>
        /// �Ƿ�������� ͨ������ComplexSizeFilter�ж��Ƿ����
        /// </summary>
        public byte bByArea;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved1;
        /// <summary>
        /// ��С���
        /// </summary>
        public Int32 nMinArea;
        /// <summary>
        /// ������
        /// </summary>
        public Int32 nMaxArea;
        /// <summary>
        /// ��С������ο�ߴ� "������ʽ"Ϊ"����"ʱ����ʾ��С������ο�Ŀ�߳ߴ磻"������ʽ"Ϊ"Զ�˽��˱궨ģʽ"ʱ����ʾ��׼�����С��߳ߴ磻
        /// </summary>
        public CFG_SIZE stuMinAreaSize;
        /// <summary>
        /// ���������ο�ߴ�, ͬ��
        /// </summary>
        public CFG_SIZE stuMaxAreaSize;

        public byte abByRatio;
        public byte abMinRatio;
        public byte abMaxRatio;
        public byte abMinRatioSize;
        public byte abMaxRatioSize;
        /// <summary>
        /// �Ƿ񰴿�߱ȹ��� ͨ������ComplexSizeFilter�ж��Ƿ����
        /// </summary>
        public byte bByRatio;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved2;
        /// <summary>
        /// ��С��߱�
        /// </summary>
        public double dMinRatio;
        /// <summary>
        /// ����߱�
        /// </summary>
        public double dMaxRatio;
        /// <summary>
        /// ��С��߱Ⱦ��ο�ߴ磬��С��߱ȶ�Ӧ���ο�Ŀ�߳ߴ硣
        /// </summary>
        public CFG_SIZE stuMinRatioSize;
        /// <summary>
        /// ����߱Ⱦ��ο�ߴ磬ͬ��
        /// </summary>
        public CFG_SIZE stuMaxRatioSize;
        /// <summary>
        /// ���У׼�����
        /// </summary>
        public Int32 nAreaCalibrateBoxNum;
        /// <summary>
        /// ���У׼��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEBOX_INFO[] stuAreaCalibrateBoxs;
        /// <summary>
        /// ���У׼�����
        /// </summary>
        public Int32 nRatioCalibrateBoxs;
        /// <summary>
        ///  ���У׼�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEBOX_INFO[] stuRatioCalibrateBoxs;
        /// <summary>
        /// �������ʹ�ܲ����Ƿ���Ч
        /// </summary>
        public byte abBySize;
        /// <summary>
        /// �������ʹ��
        /// </summary>
        public byte bBySize;
    };

    // ���������ض��Ĺ�����
    public struct CFG_OBJECT_SIZEFILTER_INFO
    {
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szObjectType;
        /// <summary>
        /// ��Ӧ�ĳߴ������
        /// </summary>
        public CFG_SIZEFILTER_INFO stSizeFilter;
    };

    /// <summary>
    /// ��ͬ���������������ļ��ģ������
    /// </summary>
    public struct CFG_MODULE_INFO
    {
        // ��Ϣ
        /// <summary>
        /// Ĭ����������,���"֧�ֵļ�����������б�"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szObjectType;
        /// <summary>
        /// �Ƿ��ʶ������ץͼ
        /// </summary>
        public byte bSnapShot;
        /// <summary>
        /// ������,ȡֵ1-10��ֵԽС������Խ��
        /// </summary>
        public byte bSensitivity;
        /// <summary>
        /// ������ʽ�����Ƿ���Ч
        /// </summary>
        public byte bMeasureModeEnable;
        /// <summary>
        /// ������ʽ,0-���أ�����ҪԶ�ˡ����˱궨, 1-ʵ�ʳ��ȣ���λ����, 2-Զ�˽��˱궨�������
        /// </summary>
        public byte bMeasureMode;
        /// <summary>
        /// ������򶥵���
        /// </summary>
        public Int32 nDetectRegionPoint;
        /// <summary>
        /// �������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// �������򶥵���
        /// </summary>
        public Int32 nTrackRegionPoint;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYGON[] stuTrackRegion;
        /// <summary>
        /// �������Ͳ����Ƿ���Ч
        /// </summary>
        public byte bFilterTypeEnable;
        // ByArea,ByRatio�������ݣ�ʹ�ö�����ByArea��ByRatioѡ����� 2012/03/06
        /// <summary>
        /// ��������:0:"ByLength",1:"ByArea", 2:"ByWidthHeight", 3:"ByRatio": ���տ�߱ȣ���ȳ��Ը߶ȵĽ��С��ĳ��ֵ���ߴ���ĳ��ֵ�����⽫�����˵���
        /// </summary>
        public byte nFilterType;
        /// <summary>
        /// ����ı������Ͳ����Ƿ���Ч
        /// </summary>
        public byte bBackgroudEnable;
        /// <summary>
        /// ����ı�������, 0-��ͨ����, 1-�߹�����
        /// </summary>
        public byte bBackgroud;
        /// <summary>
        /// �������ʹ�ܲ����Ƿ���Ч
        /// </summary>
        public byte abBySize;
        /// <summary>
        /// �������ʹ��
        /// </summary>
        public byte bBySize;
        /// <summary>
        /// ������С�ߴ�����Ƿ���Ч
        /// </summary>
        public byte bFilterMinSizeEnable;
        /// <summary>
        /// �������ߴ�����Ƿ���Ч
        /// </summary>
        public byte bFilterMaxSizeEnable;
        /// <summary>
        /// ������С�ߴ� "ByLength"ģʽ�±�ʾ��ߵĳߴ磬"ByArea"ģʽ�¿��ʾ���������Ч��
        /// </summary>
        public CFG_SIZE stuFilterMinSize;
        /// <summary>
        /// �������ߴ� "ByLength"ģʽ�±�ʾ��ߵĳߴ磬"ByArea"ģʽ�¿��ʾ���������Ч��
        /// </summary>
        public CFG_SIZE stuFilterMaxSize;
        /// <summary>
        /// �ų�������
        /// </summary>
        public Int32 nExcludeRegionNum;
        /// <summary>
        /// �ų�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_REGION[] stuExcludeRegion;
        /// <summary>
        /// У׼�����
        /// </summary>
        public Int32 nCalibrateBoxNum;
        /// <summary>
        /// У׼��(Զ�˽��˱궨ģʽ����Ч)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEBOX_INFO[] stuCalibrateBoxs;
        /// <summary>
        /// ��⾫���Ƿ���Ч
        /// </summary>
        public byte bAccuracy;
        /// <summary>
        /// ��⾫��
        /// </summary>
        public byte byAccuracy;
        /// <summary>
        /// �㷨�ƶ������Ƿ���Ч
        /// </summary>
        public byte bMovingStep;
        /// <summary>
        /// �㷨�ƶ�����
        /// </summary>
        public byte byMovingStep;
        /// <summary>
        /// �㷨���������Ƿ���Ч
        /// </summary>
        public byte bScalingFactor;
        /// <summary>
        /// �㷨��������
        /// </summary>
        public byte byScalingFactor;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] bReserved2;
        /// <summary>
        /// ©������ƽ������Ƿ���Ч
        /// </summary>
        public byte abDetectBalance;
        /// <summary>
        /// ©������ƽ��	0-����ģʽ(Ĭ��)1-©�����2-������
        /// </summary>
        public Int32 nDetectBalance;

        public byte abByRatio;
        public byte abMinRatio;
        public byte abMaxRatio;
        public byte abMinAreaSize;
        public byte abMaxAreaSize;
        /// <summary>
        /// �Ƿ񰴿�߱ȹ��� ͨ������ComplexSizeFilter�ж��Ƿ���� ���Ժ�nFilterType����
        /// </summary>
        public byte bByRatio;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved1;
        /// <summary>
        /// ��С��߱�
        /// </summary>
        public double dMinRatio;
        /// <summary>
        /// ����߱�
        /// </summary>
        public double dMaxRatio;
        /// <summary>
        /// ��С������ο�ߴ� "������ʽ"Ϊ"����"ʱ����ʾ��С������ο�Ŀ�߳ߴ磻"������ʽ"Ϊ"Զ�˽��˱궨ģʽ"ʱ����ʾ��׼�����С��߳ߴ磻
        /// </summary>
        public CFG_SIZE stuMinAreaSize;
        /// <summary>
        /// ���������ο�ߴ�, ͬ��
        /// </summary>
        public CFG_SIZE stuMaxAreaSize;

        public byte abByArea;
        public byte abMinArea;
        public byte abMaxArea;
        public byte abMinRatioSize;
        public byte abMaxRatioSize;
        /// <summary>
        /// �Ƿ�������� ͨ������ComplexSizeFilter�ж��Ƿ����  ���Ժ�nFilterType����
        /// </summary>
        public byte bByArea;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved3;
        /// <summary>
        /// ��С���
        /// </summary>
        public Int32 nMinArea;
        /// <summary>
        /// ������
        /// </summary>
        public Int32 nMaxArea;
        /// <summary>
        /// ��С��߱Ⱦ��ο�ߴ磬��С��߱ȶ�Ӧ���ο�Ŀ�߳ߴ硣
        /// </summary>
        public CFG_SIZE stuMinRatioSize;
        /// <summary>
        /// ����߱Ⱦ��ο�ߴ磬ͬ��
        /// </summary>
        public CFG_SIZE stuMaxRatioSize;
        /// <summary>
        /// ���У׼�����
        /// </summary>
        public Int32 nAreaCalibrateBoxNum;
        /// <summary>
        /// ���У׼��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEBOX_INFO[] stuAreaCalibrateBoxs;
        /// <summary>
        /// ����У׼�����
        /// </summary>
        public int nRatioCalibrateBoxs;
        /// <summary>
        /// ����У׼�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEBOX_INFO[] stuRatioCalibrateBoxs;
        /// <summary>
        /// �Ƿ���ȥ�Ŷ�ģ��
        /// </summary>
        public byte bAntiDisturbance;
        /// <summary>
        /// �Ƿ������
        /// </summary>
        public byte bBacklight;
        /// <summary>
        /// �Ƿ�����Ӱ
        /// </summary>
        public byte bShadow;
        /// <summary>
        /// ��̨Ԥ�õ㣬0~255��0��ʾ�̶�����������Ԥ�õ㡣����0��ʾ�ڴ�Ԥ�õ�ʱģ����Ч
        /// </summary>
        public int nPtzPresetId;
        /// <summary>
        /// �����ض��Ĺ���������
        /// </summary>
        public int nObjectFilterNum;
        /// <summary>
        /// �����ض��Ĺ�������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public CFG_OBJECT_SIZEFILTER_INFO[] stObjectFilter;
    }

    public struct CFG_ANALYSEMODULES_INFO
    {
        /// <summary>
        /// ���ģ����
        /// </summary>
        public Int32 nMoudlesNum;
        /// <summary>
        /// ÿ����Ƶ����ͨ����Ӧ�ĸ�����������ļ��ģ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public CFG_MODULE_INFO[] stuModuleInfo;

    }


    #endregion

    #region <<��Ƶ����ȫ������--��ؽṹ��>>

    /// <summary>
    /// ���ߵĶ˵���Ϣ
    /// </summary>
    public struct CFG_POLYLINE
    {
        /// <summary>
        /// 0~8191
        /// </summary>
        public Int32 nX;
        public Int32 nY;
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    public struct CFG_LANE
    {
        /// <summary>
        /// �������
        /// </summary>
        public Int32 nLaneId;
        /// <summary>
        /// ��������(�������ķ���),0-�� 1-���� 2-�� 3-���� 4-�� 5-���� 6-�� 7-����
        /// </summary>
        public Int32 nDirection;
        /// <summary>
        /// �󳵵��ߣ������ߵķ����ʾ���������س���������ߵĳ�Ϊ�󳵵���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYLINE[] stuLeftLine;
        /// <summary>
        /// �󳵵��߶�����
        /// </summary>
        public Int32 nLeftLineNum;
        /// <summary>
        /// �ҳ����ߣ������ߵķ����ʾ���������س��������ұߵĳ�Ϊ�ҳ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYLINE[] stuRightLine;
        /// <summary>
        /// �ҳ����߶�����
        /// </summary>
        public Int32 nRightLineNum;
        /// <summary>
        /// �󳵵������ԣ�1-��ʾ��ʵ�ߣ�2- �����ߣ�3- ����
        /// </summary>
        public Int32 nLeftLineType;
        /// <summary>
        /// �ҳ��������ԣ�1-��ʾ��ʵ�ߣ�2- �����ߣ�3- ����
        /// </summary>
        public Int32 nRightLineType;
        /// <summary>
        /// ������ʻ����ʹ�� c++�е�������BOOL
        /// </summary>
        public Int32 bDriveDirectionEnable;
        /// <summary>
        /// ������ʻ������ 
        /// </summary>
        public Int32 nDriveDirectionNum;
        /// <summary>
        /// ������ʻ����"Straight" ֱ�У�"TurnLeft" ��ת��"TurnRight" ��ת,"U-Turn":��ͷ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 32)]
        public byte[] szDriveDirection;
        /// <summary>
        /// ������Ӧֹͣ�߶�����
        /// </summary>
        public Int32 nStopLineNum;
        /// <summary>
        /// ������Ӧֹͣ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYLINE[] stuStopLine;
        /// <summary>
        /// ������Ӧ�ĺ��̵�����
        /// </summary>
        public Int32 nTrafficLightNumber;
    };

    // ��ͨ������
    public struct CFG_LIGHTATTRIBUTE
    {
        /// <summary>
        /// ��ǰ��ͨ���Ƿ���Ч���복��ͨ���޹صĽ�ͨ��Ҫ������Ч
        /// c++������ΪBOOL
        /// </summary>
        public Int32 bEnable;
        public int nTypeNum;
        /// <summary>
        /// ��ǰ��ͨ���������ݣ�����:��-Red,��-Yellow,��-Green,����ʱ-Countdown������ĳ��ͨ�ƿ�����ʾ�����������ɫ��ĳ��ͨ��ֻ��ʾ����ʱ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 32)]
        public byte[] szLightType;
        public int nDirectionNum;
        /// <summary>
        /// ��ͨ��ָʾ���г�����,"Straight": ֱ�У�"TurnLeft":��ת��"TurnRight":��ת��"U-Turn": ��ͷ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 32)]
        public byte[] szDirection;
        /// <summary>
        /// �Ƶ���ʱ��
        /// </summary>
        public int nYellowTime;
    }

    /// <summary>
    /// ������Ϣ
    /// </summary>
    public struct CFG_RECT
    {
        public int nLeft;
        public int nTop;
        public int nRight;
        public int nBottom;
    }

    /// <summary>
    /// ��ͨ����������Ϣ  
    /// </summary>
    public struct CFG_LIGHTGROUPS
    {
        /// <summary>
        /// ������
        /// </summary>
        public int nLightGroupId;
        /// <summary>
        /// ��������
        /// </summary>
        public CFG_RECT stuLightLocation;
        /// <summary>
        /// ����ķ���,1- ����ˮƽ��,2- ���鴹ֱ��
        /// </summary>
        public int nDirection;
        /// <summary>
        /// �Ƿ�Ϊ��Ӻ��̵��ź�,����Ӻ��̵�ʱ��������ź�Ϊ�ж����ݡ�����ź�ÿ������ʱ֪ͨ
        /// c++�е�����ΪBOOL
        /// </summary>
        public Int32 bExternalDetection;
        /// <summary>
        /// �Ƿ�֧������Ӧ����ҡ�ڼ��,�ڷ紵���������𶯵ĳ����£�λ�û����һ���ĸ���ƫ�������㷨���м�⣬�����Ӽ��ʱ��
        /// c++�е�����ΪBOOL
        /// </summary>
        public Int32 bSwingDetection;
        /// <summary>
        /// �����н�ͨ�Ƶ�����
        /// </summary>
        public int nLightNum;
        /// <summary>
        /// �����и���ͨ�Ƶ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public CFG_LIGHTATTRIBUTE[] stuLightAtrributes;

    }

    public struct CFG_STAFF
    {
        /// <summary>
        /// ��ʼ�����
        /// </summary>
        public CFG_POLYLINE stuStartLocation;
        /// <summary>
        /// ��ֹ�����
        /// </summary>
        public CFG_POLYLINE stuEndLocation;
        /// <summary>
        /// ʵ�ʳ���,��λ��
        /// </summary>
        public float nLenth;
        /// <summary>
        /// �������
        /// </summary>
        public EM_STAFF_TYPE emType;
    }

    /// <summary>
    /// �궨����,��ͨ����ʹ��
    /// </summary>
    public struct CFG_CALIBRATEAREA_INFO
    {
        /// <summary>
        /// ˮƽ�������߶�����
        /// </summary>
        public int nLinePoint;
        /// <summary>
        /// ˮƽ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYGON[] stuLine;
        /// <summary>
        /// ʵ�ʳ���
        /// </summary>
        public float fLenth;
        /// <summary>
        /// ����
        /// </summary>
        public CFG_REGION stuArea;
        /// <summary>
        /// ��ֱ�����
        /// </summary>
        public int nStaffNum;
        /// <summary>
        /// ��ֱ��� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_STAFF[] stuStaffs;
        /// <summary>
        /// ��������
        /// </summary>
        public EM_CALIBRATEAREA_TYPE emType;
    }

    /// <summary>
    /// ������ⳡ��
    /// </summary>
    public struct CFG_FACERECOGNITION_SCENCE_INFO
    {
        /// <summary>
        /// ����ͷ��ظ߶� ��λ����
        /// </summary>
        public double dbCameraHeight;
        /// <summary>
        /// ����ͷ��������������ĵ�ˮƽ���� ��λ����
        /// </summary>
        public double dbCameraDistance;
        /// <summary>
        /// ������Ҫ���򶥵���
        /// </summary>
        public int nMainDirection;
        /// <summary>
        /// ������Ҫ���򣬵�һ��������ʼ�㣬�ڶ���������ֹ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_POLYGON[] stuMainDirection;
        /// <summary>
        /// ��λ�ȣ�-45~45��������ʾ���������ϱߣ�������ʾ���������±ߣ�0��ʾ������ֱ����������������ͷ��
        /// </summary>
        public byte byFaceAngleDown;
        /// <summary>
        /// ��λ�ȣ�-45~45��������ʾ���������ϱߣ�������ʾ���������±ߣ�0��ʾ������ֱ����������������ͷ��
        /// </summary>
        public byte byFaceAngleUp;
        /// <summary>
        /// ��λ�ȣ�-45~45��������ʾ���������ϱߣ�������ʾ���������±ߣ�0��ʾ������ֱ����������������ͷ��
        /// </summary>
        public byte byFaceAngleLeft;
        /// <summary>
        /// ��λ�ȣ�-45~45��������ʾ���������ϱߣ�������ʾ���������±ߣ�0��ʾ������ֱ����������������ͷ��
        /// </summary>
        public byte byFaceAngleRight;
    }
    #endregion

    #region <<���ܽ�ͨ���������ã�������ģ�顢��ͨ���� ����>>

    /// <summary>
    /// ��Ƶ����ȫ������
    /// </summary>
    //[StructLayout(LayoutKind.Sequential, public byte[]Set=public byte[]Set.Unicode)]
    //[StructLayout(LayoutKind.Sequential, public byte[]Set = public byte[]Set.Ansi)]
    public struct CFG_ANALYSEGLOBAL_INFO
    {
        /// <summary>
        /// ��Ϣ
        /// Ӧ�ó���,���"֧�ֵĳ����б�" public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szSceneType;

        /// <summary>
        /// ��ͨ������Ϣ
        /// ����ͷ��ظ߶�	��λ����
        /// </summary>
        public double CameraHeight;
        /// <summary>
        /// ����ͷ��������������ĵ�ˮƽ����	��λ����
        /// </summary>
        public double CameraDistance;
        /// <summary>
        /// ��������
        /// </summary>
        public CFG_POLYGON stuNearDetectPoint;
        /// <summary>
        /// Զ������
        /// </summary>
        public CFG_POLYGON stuFarDectectPoint;
        /// <summary>
        /// NearDetectPoint,ת����ʵ�ʳ�����ʱ,������ͷ��ֱ�ߵ�ˮƽ����
        /// </summary>
        int nNearDistance;
        /// <summary>
        /// FarDectectPoint,ת����ʵ�ʳ�����ʱ,������ͷ��ֱ�ߵ�ˮƽ����
        /// </summary>
        int nFarDistance;
        /// <summary>
        /// ��ͨ������������,"Gate",��������,"Junction" ·������public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szSubType;
        /// <summary>
        /// ������
        /// </summary>
        public int nLaneNum;
        /// <summary>
        /// ������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public CFG_LANE[] stuLanes;
        /// <summary>
        /// �����ַ���ʾ����
        /// </summary>
        public int nPlateHintNum;
        /// <summary>
        /// �����ַ���ʾ���飬������ͼƬ�����ϲ��ʶ��ȷ��ʱ�����ݴ������е��ַ�����ƥ�䣬�����±�ԽС��ƥ�����ȼ�Խ��public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 32)]
        public byte[] szPlateHints;

        /// <summary>
        /// ������
        /// </summary>
        public int nLightGroupNum;
        /// <summary>
        /// ����������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public CFG_LIGHTGROUPS[] stLightGroups;

        // һ�㳡����Ϣ 
        /// <summary>
        /// �����
        /// </summary>
        public int nStaffNum;
        /// <summary>
        /// ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public CFG_STAFF[] stuStaffs;
        /// <summary>
        /// �궨������
        /// </summary>
        public int nCalibrateAreaNum;
        /// <summary>
        /// �궨����(�����ֶβ����ڣ�������������Ϊ�궨����)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public CFG_CALIBRATEAREA_INFO[] stuCalibrateArea;
        /// <summary>
        /// ����ʶ�𳡾��Ƿ���Ч
        /// C++������ΪBOOL
        /// </summary>
        public Int32 bFaceRecognition;
        /// <summary>
        /// ����ʶ�𳡾�
        /// </summary>
        public CFG_FACERECOGNITION_SCENCE_INFO stuFaceRecognitionScene;

        public byte abJitter;
        public byte abDejitter;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved;
        /// <summary>
        /// ����������� : ����������ʣ�ȡֵ0-100����Ӧ��ֹ����������̶ȣ�����Խ������ֵԽ��
        /// </summary>
        public Int32 nJitter;
        /// <summary>
        /// �Ƿ���ȥ����ģ�� Ŀǰ��ʵ��,C++��������BOOL
        /// </summary>
        public Int32 bDejitter;
    }

    public struct CFG_RULE_INFO
    {
        /// <summary>
        /// �¼����ͣ����dhnetsdk.h��"���ܷ����¼�����"
        /// </summary>
	    public UInt32 dwRuleType;
        /// <summary>
        /// ���¼����͹������ýṹ���С
        /// </summary>
	    public Int32 nRuleSize;
    	
    } 

    /// <summary>
    /// ÿ����Ƶ����ͨ����Ӧ�������¼����򣺻�����pRuleBuf������¼�������Ϣ��
    /// ÿ���¼�������Ϣ����ΪCFG_RULE_INFO+"�¼����Ͷ�Ӧ�Ĺ������ýṹ��"��
    /// </summary>
    public struct CFG_ANALYSERULES_INFO
    {
        /// <summary>
        /// �¼��������
        /// </summary>
        public Int32 nRuleCount;
        /// <summary>
        /// ÿ����Ƶ����ͨ����Ӧ����Ƶ�����¼��������û���
        /// C++�¸�ʽ��char*
        /// </summary>
        public IntPtr pRuleBuf;
        /// <summary>
        /// �����С
        /// </summary>
        public Int32 nRuleLen;

    }

    /// <summary>
    /// ��Ƶ����������
    /// </summary>
    public struct CFG_CAP_ANALYSE_INFO
    {
        /// <summary>
        /// ֧�ֵĳ�������
        /// </summary>
        public Int32 nSupportedSceneNum;
        /// <summary>
        /// ֧�ֵĳ����б�public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 32)]
        public byte[] szSceneName;
        /// <summary>
        /// ÿͨ��֧��������ģ����
        /// </summary>
        public Int32 nMaxMoudles;
        /// <summary>
        /// ֧�ֵļ���������͸���
        /// </summary>
        public Int32 nSupportedObjectTypeNum;
        /// <summary>
        /// ֧�ֵļ�����������б�public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
        public byte[] szObjectTypeName;
        /// <summary>
        /// ÿͨ��֧������������
        /// </summary>
        public Int32 nMaxRules;
        /// <summary>
        /// ֧�ֵ��¼����͹������
        /// </summary>
        public Int32 nSupportedRulesNum;
        /// <summary>
        /// ֧�ֵ��¼����͹����б��¼����ͣ����dhnetsdk.h��"���ܷ����¼�����"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public UInt32[] dwRulesType;
        /// <summary>
        /// ֧�ֵ�����߸���
        /// </summary>
        public Int32 nMaxStaffs;
        /// <summary>
        /// ������󶥵���
        /// </summary>
        public Int32 nMaxPointOfLine;
        /// <summary>
        /// ������󶥵���
        /// </summary>
        public Int32 nMaxPointOfRegion;
        /// <summary>
        /// ����ڲ�ѡ�����
        /// </summary>
        public Int32 nMaxInternalOptions;
        /// <summary>
        /// �Ƿ�֧�ָ��ӳߴ������	���ӳߴ������ʹ�ö�����������˺Ϳ�߱ȹ��˲�����      
        /// </summary>
        public byte bComplexSizeFilter;
        /// <summary>
        /// �Ƿ�֧���ض������������
        /// </summary>
        public byte bSpecifiedObjectFilter;
        /// <summary>
        /// ֧��ģ���е�����ų��������
        /// </summary>
        public Int32 nMaxExcludeRegionNum;
        /// <summary>
        /// ֧�ֵ�ģ���е����У׼�����
        /// </summary>
        public Int32 nMaxCalibrateBoxNum;
        /// <summary>
        /// ģ����������Ҫ���õ�У׼�����
        /// </summary>
        public Int32 nMinCalibrateBoxNum;
    }
    #endregion

    #region <<�¼�����EVENT_IVS_TRAFFICGATE(��ͨ�����¼�)��Ӧ�����ݿ�������Ϣ>>

    public struct NET_TIME_EX
    {
        /// <summary>
        /// ��
        /// </summary>
        public UInt32 dwYear;
        /// <summary>
        /// ��
        /// </summary>
        public UInt32 dwMonth;
        /// <summary>
        /// ��
        /// </summary>
        public UInt32 dwDay;
        /// <summary>
        /// ʱ
        /// </summary>
        public UInt32 dwHour;
        /// <summary>
        /// ��
        /// </summary>
        public UInt32 dwMinute;
        /// <summary>
        /// ��
        /// </summary>
        public UInt32 dwSecond;
        /// <summary>
        /// ����
        /// </summary>
        public UInt32 dwMillisecond;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public UInt32[] dwReserved;
    }

    /// <summary>
    /// ��ά�ռ��
    /// </summary>
    public struct DH_POINT
    {
        short nx;
        short ny;
    }


    /// <summary>
    /// �����ӦͼƬ�ļ���Ϣ
    /// </summary>
    public struct DH_PIC_INFO
    {
        /// <summary>
        /// �ļ��ڶ��������ݿ��е�ƫ��λ��, ��λ:�ֽ�
        /// </summary>
        public UInt32 dwOffSet;
        /// <summary>
        /// �ļ���С, ��λ:�ֽ�
        /// </summary>
        public UInt32 dwFileLenth;
        /// <summary>
        /// ͼƬ���, ��λ:����
        /// </summary>
        public UInt16 wWidth;
        /// <summary>
        /// ͼƬ�߶�, ��λ:����
        /// </summary>
        public UInt16 wHeight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] bReserved;
    };



    /// <summary>
    /// ��Ƶ����������Ϣ�ṹ��
    /// </summary>
    public struct DH_MSG_OBJECT
    {
        /// <summary>
        /// ����ID,ÿ��ID��ʾһ��Ψһ������
        /// </summary>
        public Int32 nObjectID;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szObjectType;
        /// <summary>
        /// ���Ŷ�(0~255)��ֵԽ���ʾ���Ŷ�Խ��
        /// </summary>
        public Int32 nConfidence;
        /// <summary>
        /// ���嶯��:1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
        /// </summary>
        public Int32 nAction;
        /// <summary>
        /// ��Χ��
        /// </summary>
        public DH_RECT BoundingBox;
        /// <summary>
        /// ��������
        /// </summary>
        public DH_POINT Center;
        /// <summary>
        /// ����ζ������
        /// </summary>
        public Int32 nPolygonNum;
        /// <summary>
        /// �Ͼ�ȷ�����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public DH_POINT[] Contour;
        /// <summary>
        /// ������Ҫ��ɫ�����ֽڱ�ʾ���ֱ�Ϊ�졢�̡�����͸����,����:RGBֵΪ(0,255,0),͸����Ϊ0ʱ, ��ֵΪ0x00ff0000.
        /// </summary>
        public UInt32 rgbaMainColor;
        /// <summary>
        /// ��������صĴ�0�������ı������糵�ƣ���װ��ŵȵ�public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szText;
        /// <summary>
        /// ��������𣬸��ݲ�ͬ���������ͣ�����ȡ���������ͣ�
        /// Vehicle Category:"Unknown"  δ֪,"Motor" ������,"Non-Motor":�ǻ�����,"Bus": ������,"Bicycle" ���г�,"Motorcycle":Ħ�г�
        /// Plate Category��"Unknown" δ֪,"Normal" ���ƺ���,"Yellow" ����,"DoubleYellow" ˫���β��,"Police" ����"Armed" �侯��,
        /// "Military" ���Ӻ���,"DoubleMilitary" ����˫��,"SAR" �۰���������,"Trainning" ����������
        /// "Personal" ���Ժ���,"Agri" ũ����,"Embassy" ʹ�ݺ���,"Moto" Ħ�г�����,"Tractor" ����������,"Other" ��������
        /// HumanFace Category:"Normal" ��ͨ����,"HideEye" �۲��ڵ�,"HideNose" �����ڵ�,"HideMouth" �첿�ڵ�
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szObjectSubType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved1;
        /// <summary>
        /// �Ƿ��������ӦͼƬ�ļ���Ϣ
        /// </summary>
        public byte bPicEnble;
        /// <summary>
        /// �����ӦͼƬ��Ϣ
        /// </summary>
        public DH_PIC_INFO stPicInfo;
        /// <summary>
        /// �Ƿ���ץ���ŵ�ʶ����
        /// </summary>
        public byte bShotFrame;
        /// <summary>
        /// ������ɫ(rgbaMainColor)�Ƿ����
        /// </summary>
        public byte bColor;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 222)]
        public byte[] byReserved;
    }

    /// <summary>
    /// �¼���Ӧ�ļ���Ϣ
    /// </summary>
    public struct DH_EVENT_FILE_INFO
    {
        /// <summary>
        /// ��ǰ�ļ������ļ����е��ļ�����
        /// </summary>
        public byte bCount;
        /// <summary>
        /// ��ǰ�ļ����ļ����е��ļ����
        /// </summary>
        public byte bIndex;
        /// <summary>
        /// �ļ���ǩ������˵����ö������EM_EVENT_FILETAG
        /// </summary>
        public byte bFileTag;
        /// <summary>
        /// �ļ����ͣ�0-��ͨ 1-�ϳ� 2-��ͼ
        /// </summary>
        public byte bFileType;
        /// <summary>
        /// �ļ�ʱ��
        /// </summary>
        public NET_TIME_EX stuFileTime;
        /// <summary>
        /// ͬһ��ץ���ļ���Ψһ��ʶ
        /// </summary>
        public int nGroupId;
    }

    /// <summary>
    /// ͼƬ�ֱ���
    /// </summary>
    public struct DH_RESOLUTION_INFO
    {
        /// <summary>
        /// ��
        /// C++��������unsigned short
        /// </summary>
        public UInt16 snWidth;
        /// <summary>
        /// ��
        /// C++��������unsigned short
        /// </summary>
        public UInt16 snHight;
    }

    /// <summary>
    /// ������������Ϣ
    /// </summary>
    public struct DH_SIG_CARWAY_INFO_EX
    {
        /// <summary>
        /// �ɳ���������ץ���ź�������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byRedundance;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
        public byte[] bReserved;
    }


    public struct DEV_EVENT_TRAFFICGATE_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
        public Int32 nChannelID;
        /// <summary>
        /// �¼�����public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
        public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
        public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
        public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
        public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
        public Int32 nLane;
        /// <summary>
        /// ����ʵ���ٶ�Km/h
        /// </summary>
        public Int32 nSpeed;
        /// <summary>
        /// �ٶ����� ��λ��km/h
        /// </summary>
        public Int32 nSpeedUpperLimit;
        /// <summary>
        /// �ٶ����� ��λ��km/h 
        /// </summary>
        public Int32 nSpeedLowerLimit;
        /// <summary>
        /// Υ����������,��һλ:����; 
        /// �ڶ�λ:ѹ����ʻ; ����λ:������ʻ; 
        /// ����λ��Ƿ����ʻ; ����λ:�����;����λ:����·��(�����¼�)
        /// ����λ: ѹ����; �ڰ�λ: �г�ռ��; �ھ�λ: ����ռ��;����Ĭ��Ϊ:��ͨ�����¼�
        /// </summary>
        public UInt32 dwBreakingRule;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ  
        /// </summary>
        public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �ֶ�ץ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szManualSnapNo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
        public int nSequence;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����; 
        /// </summary>
        public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
        /// <summary>
        /// �豸������ץ�ı�ʶ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szSnapFlag;
        /// <summary>
        /// ץ�ķ�ʽ��0-δ���� 1-ȫ�� 2-���� 4-ͬ��ץ�� 8-����ץ�� 16-����ͼ��
        /// </summary>
        public byte bySnapMode;
        /// <summary>
        /// ���ٰٷֱ�
        /// </summary>
        public byte byOverSpeedPercentage;
        /// <summary>
        /// Ƿ�ٰٷֱ�
        /// </summary>
        public byte byUnderSpeedingPercentage;
        /// <summary>
        /// ���������ʱ��,��λ����
        /// </summary>
        public byte byRedLightMargin;
        /// <summary>
        /// ��ʻ����0-����(���������豸�����Խ��Խ��)��1-����(���������豸�����Խ��ԽԶ)
        /// </summary>
        public byte byDriveDirection;
        /// <summary>
        /// ��·���public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szRoadwayNo;
        /// <summary>
        /// Υ�´���public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szViolationCode;
        /// <summary>
        /// Υ������public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szViolationDesc;
        /// <summary>
        /// ��ӦͼƬ�ķֱ���
        /// </summary>
        public DH_RESOLUTION_INFO stuResolution;
        /// <summary>
        /// ������С���ͣ�"Motor" Ħ�г��� "Light-duty" С�ͳ� "Medium" ���ͳ� "Oversize" ���ͳ� "Huge" ���� "Other" ��������
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szVehicleType;
        /// <summary>
        /// ��������, ��λ��
        /// </summary>
        public byte byVehicleLenth;
        /// <summary>
        /// �����ֽ�,������չ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved1;
        /// <summary>
        /// �޸��ٿ���ֵ	��λ��km/h 
        /// </summary>
        public Int32 nOverSpeedMargin;
        /// <summary>
        /// �޵��ٿ���ֵ	��λ��km/h 
        /// </summary>
        public Int32 nUnderSpeedMargin;
        /// <summary>
        /// "DrivingDirection" : ["Approach", "�Ϻ�", "����"],��ʻ����
        /// "Approach"-���У����������豸�����Խ��Խ����"Leave"-���У�
        /// ���������豸�����Խ��ԽԶ���ڶ��͵����������ֱ�������к�
        /// ���е������ص㣬UTF-8����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
        public byte[] szDrivingDirection;
        /// <summary>
        /// ���ػ�Զ���豸����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineName;
        /// <summary>
        /// ��������ص㡢��·����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineAddress;
        /// <summary>
        /// �������顢�豸������λ
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szMachineGroup;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �ɳ���������ץ���ź�������Ϣ
        /// </summary>
        public DH_SIG_CARWAY_INFO_EX stuSigInfo;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3964)]
        public byte[] bReserved;
    }

    // ��ӦCLIENT_StartSearchDevices�ӿ�
    public struct DEVICE_NET_INFO_EX
    {
        /// <summary>
        /// 4 for IPV4, 6 for IPV6
        /// </summary>
	    public Int32    iIPVersion;
        /// <summary>
        /// IP IPV4����"192.168.0.1" IPV6����"2008::1/64"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szIP;
        /// <summary>
        /// tcp�˿�
        /// </summary>
	    public Int32    nPort;
        /// <summary>
        /// �������� IPV6����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szSubmask;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szGateway;
        /// <summary>
        /// MAC��ַ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	    public byte[] szMac;
        /// <summary>
        /// �豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szDeviceType;
        /// <summary>
        /// Ŀ���豸����������,����ο�EM_IPC_TYPE��	
        /// </summary>
	    public byte byManuFactory;
        /// <summary>
        /// 1-���� 2-����
        /// </summary>
	    public byte byDefinition;
        /// <summary>
        /// ԭ����bool��һ���ֽ�
        /// Dhcpʹ��״̬, true-��, false-��
        /// </summary>
	    public byte bDhcpEn;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
	    public byte byReserved1;
        /// <summary>
        /// У������ ͨ���첽�����ص���ȡ(���޸��豸IPʱ���ô���Ϣ����У��)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
	    public byte[] verifyData;
        /// <summary>
        /// ���к�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	    public byte[] szSerialNo;
        /// <summary>
        /// �豸����汾��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szDevSoftVersion;
        /// <summary>
        /// �豸�ͺ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szDetailType;
        /// <summary>
        /// OEM�ͻ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szVendor;
        /// <summary>
        /// �豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDevName;
        /// <summary>
        /// ��½�豸�û��������޸��豸IPʱ��Ҫ��д��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szUserName;
        /// <summary>
        /// ��½�豸���루���޸��豸IPʱ��Ҫ��д��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szPassWord;
        /// <summary>
        /// HTTP����˿ں�
        /// </summary>
	    public short    nHttpPort;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 254)]
	    public byte[] cReserved;
    }

    #endregion

    #region �ṹ��--���ܷ����¼�����

    /// <summary>
    /// �¼�����EVENT_IVS_CROSSLINEDETECTION(�������¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_CROSSLINE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectLine;
        /// <summary>
        /// �������߶�����
        /// </summary>
	    public int nDetectLineNum;
        /// <summary>
        /// �����˶��켣
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] TrackLine;
        /// <summary>
        /// �����˶��켣������
        /// </summary>
	    public int nTrackLineNum;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public Byte bEventAction;
        /// <summary>
        /// ��ʾ���ַ���, 0-��������, 1-��������
        /// </summary>
	    public Byte bDirection;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public Byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON
        /// </summary>
	    public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 876)]
	    public Byte[] bReserved; 

    }

    /// <summary>
    /// ��������߶�����Ϣ
    /// </summary>
    public struct DH_POLY_POINTS
    {
        /// <summary>
        /// ������
        /// </summary>
	    public Int32 nPointNum;
        /// <summary>
        /// ������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] stuPoints; 
    }


    /// <summary>
    /// �¼�����EVENT_IVS_CROSSREGIONDETECTION(�������¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_CROSSREGION_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public int nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public int nDetectRegionNum;
        /// <summary>
        /// �����˶��켣
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] TrackLine;
        /// <summary>
        /// �����˶��켣������
        /// </summary>
	    public int nTrackLineNum;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// ��ʾ���ַ���, 0-����, 1-�뿪��2-���֣�3-�뿪
        /// </summary>
	    public byte bDirection;
        /// <summary>
        /// ��ʾ��⶯������,0-���� 1-��ʧ 2-�������� 3-��Խ����
        /// </summary>
	    public byte bActionType;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	    public byte[] bReserved1; 
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON
        /// </summary>
        public UInt32 dwSnapFlagMask;
 	   /// <summary>
 	   /// �����ֽ�,������չ.
 	   /// </summary>
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 804)]
	    public byte[] bReserved; 
        /// <summary>
        /// ��⵽���������
        /// </summary>
	    public int nObjectNum;
        /// <summary>
        /// ��⵽������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_MSG_OBJECT[] stuObjectIDs;
        /// <summary>
        /// �켣��(���⵽�����������Ӧ)
        /// </summary>
	    public int nTrackNum;
        /// <summary>
        /// �켣��Ϣ(���⵽�������Ӧ)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_POLY_POINTS[] stuTrackInfo;
    }

    /// <summary>
    /// �¼�����EVENT_IVS_PASTEDETECTION(�����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_PASTE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public int nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName; 
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ���������򶥵���public 
        /// </summary>
	    public int nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion; 
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON
        /// </summary>
        public UInt32 dwSnapFlagMask;
 	   /// <summary>
 	   /// �����ֽ�,������չ.
 	   /// </summary>
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_LEFTDETECTION(��Ʒ�����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_LEFT_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public int nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public int nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]  
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved;

    }

    /// <summary>
    /// �¼�����EVENT_IVS_PRESERVATION(��Ʒ��ȫ�¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_PRESERVATION_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public int nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public int nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON
        /// </summary>
        public UInt32 dwSnapFlagMask;
 	   /// <summary>
 	   /// �����ֽ�,������չ.
 	   /// </summary>
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_STAYDETECTION(ͣ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_STAY_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public int nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public int nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_WANDERDETECTION(�ǻ��¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_WANDER_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public int nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public int nEventID;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved; 
        /// <summary>
        /// ��⵽���������
        /// </summary>
	    public int nObjectNum;
        /// <summary>
        /// ��⵽������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_MSG_OBJECT[] stuObjectIDs;
        /// <summary>
        /// �켣��(���⵽�����������Ӧ)
        /// </summary>
	    public Int32 nTrackNum;
        /// <summary>
        /// �켣��Ϣ(���⵽�������Ӧ)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_POLY_POINTS[] stuTrackInfo;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	    public byte[] bReserved;
 
    }

    /// <summary>
    /// �¼�����EVENT_IVS_MOVEDETECTION(�ƶ��¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_MOVE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName; 
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON
        /// </summary>
        public UInt32 dwSnapFlagMask;
 	   /// <summary>
 	   /// �����ֽ�,������չ.
 	   /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_TAILDETECTION(β���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TAIL_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved; 

    } 


    /// <summary>
    /// �¼�����EVENT_IVS_RIOTERDETECTION(�����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_RIOTERL_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽���������
        /// </summary>
	    public Int32 nObjectNum;
        /// <summary>
        /// ��⵽�������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_MSG_OBJECT[] stuObjectIDs;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved; 
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_FIREDETECTION(���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_FIRE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
    	/// <summary>
    	/// ץͼ��־(��λ)�������NET_RESERVED_COMMON
    	/// </summary>
        public UInt32 dwSnapFlagMask;
 	   /// <summary>
 	   /// �����ֽ�,������չ
 	   /// </summary>
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 888)]
	    public byte[] bReserved;

    }

    /// <summary>
    /// �¼�����EVENT_IVS_SMOKEDETECTION(�������¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_SMOKE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName; 
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID 
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON
        /// </summary>
        public UInt32 dwSnapFlagMask;
 	   /// <summary>
 	   /// �����ֽ�,������չ.
 	   /// </summary>
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 972)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_FLOWSTAT(����ͳ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_FLOWSTAT_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ����ߴ�Խ���˵ĸ���
        /// </summary>
	    public Int32 nNumberLeft;
        /// <summary>
        /// ���ұߴ�Խ���˵ĸ���
        /// </summary>
	    public Int32 nNumberRight;
        /// <summary>
        /// ���õ�����
        /// </summary>
	    public Int32 nUpperLimit;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 972)]
	    public byte[] bReserved; 

    }


    
    /// <summary>
    /// �¼�����EVENT_IVS_NUMBERSTAT(����ͳ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_NUMBERSTAT_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName; 
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ����������ĸ���
        /// </summary>
	    public Int32 nNumber;
        /// <summary>
        /// ���õ�����
        /// </summary>
	    public Int32 nUpperLimit;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved1;
        /// <summary>
        /// ��ʾ����������߳���ڵ�������ĸ���
        /// </summary>
	    public Int32 nEnteredNumber;
        /// <summary>
        /// ��ʾ����������߳���ڵ�������ĸ���
        /// </summary>
	    public Int32 nExitedNumber;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 964)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFICCONTROL(��ͨ�����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFICCONTROL_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 972)]
	    public byte[] bReserved; 
    }

    
    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFICACCIDENT(��ͨ�¹��¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFICACCIDENT_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���) 
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽���������
        /// </summary>
	    public Int32 nObjectNum;
        /// <summary>
        /// ��⵽�������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_MSG_OBJECT[] stuObjectIDs;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 972)]
	    public byte[] bReserved; 

    }

    /// <summary>
    /// TrafficCar ��ͨ������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO
    {
        /// <summary>
        /// ���ƺ���
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szPlateNumber;
        /// <summary>
        /// ��������	�μ�VideoAnalyseRule�г������Ͷ���
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szPlateType;
        /// <summary>
        /// ������ɫ	"Blue","Yellow", "White","Black"
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szPlateColor;
        /// <summary>
        /// ������ɫ	"White", "Black", "Red", "Yellow", "Gray", "Blue","Green"
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szVehicleColor;
        /// <summary>
        /// �ٶ�	��λKm/H
        /// </summary>
	    public int nSpeed;
        /// <summary>
        /// ����������¼�	�μ��¼��б�Event List��ֻ������ͨ����¼���
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szEvent;
        /// <summary>
        /// Υ�´���	���TrafficGlobal.ViolationCode
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szViolationCode;
        /// <summary>
        /// Υ������
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szViolationDesc; 
        /// <summary>
        /// �ٶ�����
        /// </summary>
	    public Int32 nLowerSpeedLimit;
        /// <summary>
        /// �ٶ�����
        /// </summary>
	    public Int32 nUpperSpeedLimit;
        /// <summary>
        /// �޸��ٿ���ֵ	��λ��km/h 
        /// </summary>
	    public Int32 nOverSpeedMargin;
        /// <summary>
        /// �޵��ٿ���ֵ	��λ��km/h 
        /// </summary>
	    public Int32 nUnderSpeedMargin;
        /// <summary>
        /// ����	�μ��¼��б�Event List�п��ں�·���¼���
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ������С	��λ��0λ:"Light-duty",��1λ:"Medium",��2λ:"Oversize" 
        /// </summary>
	    public Int32 nVehicleSize;
        /// <summary>
        /// ��������	��λ��
        /// </summary>
	    public float fVehicleLength;
        /// <summary>
        /// ץ�ķ�ʽ	0-δ���࣬1-ȫ����2-������4-ͬ��ץ�ģ�8-����ץ�ģ�16-����ͼ��
        /// </summary>
	    public Int32 nSnapshotMode;
        /// <summary>
        /// ���ػ�Զ�̵�ͨ�����ƣ������ǵص���Ϣ	��Դ��ͨ����������ChannelTitle.Name 
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szChannelName;
        /// <summary>
        /// ���ػ�Զ���豸����	��Դ����ͨ����General.MachineName
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szMachineName;
        /// <summary>
        /// �����������豸������λ	Ĭ��Ϊ�գ��û����Խ���ͬ���豸��Ϊһ�飬���ڹ������ظ���
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szMachineGroup;
        /// <summary>
        /// ��·���	UTF-8����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szRoadwayNo;
        /// <summary>
        /// "DrivingDirection" : ["Approach", "�Ϻ�", "����"],��ʻ����
        /// "Approach"-���У����������豸�����Խ��Խ����"Leave"-���У�
        /// ���������豸�����Խ��ԽԶ���ڶ��͵����������ֱ�������к�
        /// ���е������ص㣬UTF-8����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
	    public byte[] szDrivingDirection;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[] bReserved; 
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFICJUNCTION(��ͨ·���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFICJUNCTION_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������ 
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// Υ����������,��һλ:�����
        /// �ڶ�λ:�����涨������ʻ;
        /// ����λ:����; ����λ��Υ�µ�ͷ;
        /// ����λ:��ͨ����; ����λ:��ͨ�쳣����
        /// ����λ:ѹ����ʻ; ����Ĭ��Ϊ:��ͨ·���¼�
        /// </summary>
	    public UInt32 dwBreakingRule;
        /// <summary>
        /// ��ƿ�ʼUTCʱ��
        /// </summary>
	    public NET_TIME_EX RedLightUTC;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʵ���ٶ�Km/h                 
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
	    public byte[] byReserved;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 476)]
        public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar; 

    }

    /// <summary>
    /// ץ����Ϣ
    /// </summary>
    public struct DH_SIG_CARWAY_INFO
    {
        /// <summary>
        /// ��ǰ�����ٶȣ�km/h
        /// </summary>
	    public short snSpeed;
        /// <summary>
        /// ��ǰ����,����Ϊ��λ
        /// </summary>
	    public short snCarLength;
        /// <summary>
        /// ��ǰ�������ʱ��,��.����
        /// </summary>
	    public float fRedTime;
        /// <summary>
        /// ��ǰ����ץ��ʱ��,��.���� 
        /// </summary>
	    public float fCapTime;
        /// <summary>
        /// ��ǰץ�����
        /// </summary>
	    public byte bSigSequence;
        /// <summary>
        /// ��ǰ������ץ������
        /// 0: �״������;1: �״������;2: ������������;3:������������
        /// 4: ����;5: �����;6: �����;7: �����;8: ȫ��ץ�Ļ��߿���
        /// </summary>
	    public byte bType;
        /// <summary>
        /// ���������:01:��ת���;02:ֱ�к��;03:��ת���
        /// </summary>
	    public byte bDirection;
        /// <summary>
        /// ��ǰ�����ĺ��̵�״̬��0: �̵�, 1: ���, 2: �Ƶ�
        /// </summary>
	    public byte bLightColor;
        /// <summary>
        /// �豸������ץ�ı�ʶ
        /// </summary>
	    public byte[] bSnapFlag;
    }

    /// <summary>
    /// ÿ�������������Ϣ
    /// </summary>
    public struct DH_CARWAY_INFO
    {
        /// <summary>
        /// ��ǰ������ 
        /// </summary>
	    public byte bCarWayID;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[] bReserve;
        /// <summary>
        /// ������ץ�ĵĸ���
        /// </summary>
	    public byte bSigCount;
        /// <summary>
        /// ��ǰ�����ϣ�������ץ�Ķ�Ӧ��ץ����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public DH_SIG_CARWAY_INFO[]  stuSigInfo;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	    public byte[] bReserved; 
    };

    /// <summary>
    /// �¼�����EVENT_TRAFFICSNAPSHOT(��ͨץ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFICSNAPSHOT_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// �����ֽ� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserv;
        /// <summary>
        /// ����ץ�ĵĳ�������
        /// </summary>
	    public byte bCarWayCount;
        /// <summary>
        /// ����ץ�ĵĳ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public DH_CARWAY_INFO[] stuCarWayInfo;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 340)]
	    public byte[] bReserved;
    }

    /// <summary>
    /// �¼�����EVENT_IVS_FACEDETECT(��������¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_FACEDETECT_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] reserved;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 932)]
	    public byte[] bReserved;
    } 

    
    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_RUNREDLIGHT(��ͨ-������¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ 
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ���̵�״̬ 0:δ֪ 1���̵� 2:��� 3:�Ƶ�
        /// </summary>
	    public Int32 nLightState;
        /// <summary>
        /// ����,km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    } 


    
    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_OVERLINE(��ͨ-ѹ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_OVERLINE_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʵ���ٶ�,Km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_RETROGRADE(��ͨ-�����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_RETROGRADE_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʵ���ٶ�,Km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_TURNLEFT(��ͨ-Υ����ת)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_TURNLEFT_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʵ���ٶ�,Km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

    }


    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_TURNRIGHT(��ͨ-Υ����ת)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_TURNRIGHT_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʵ���ٶ�,Km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    } 

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_UTURN(Υ�µ�ͷ�¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_UTURN_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʵ���ٶ�,Km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_OVERSPEED(��ͨ�����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_OVERSPEED_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ����ʵ���ٶ�Km/h
        /// </summary>
        public Int32 nSpeed;
        /// <summary>
        /// �ٶ����� ��λ��km/h
        /// </summary>
	    public Int32 nSpeedUpperLimit;
        /// <summary>
        /// �ٶ����� ��λ��km/h 
        /// </summary>
	    public Int32 nSpeedLowerLimit;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;	
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    }

    
    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_UNDERSPEED(��ͨǷ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_UNDERSPEED_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// ����ʵ���ٶ�Km/h
        /// </summary>
        public Int32 nSpeed;
        /// <summary>
        /// �ٶ����� ��λ��km/h
        /// </summary>
	    public Int32 nSpeedUpperLimit;
        /// <summary>
        /// �ٶ����� ��λ��km/h 
        /// </summary>
	    public Int32 nSpeedLowerLimit;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bReserved1;
        /// <summary>
        /// Ƿ�ٰٷֱ�
        /// </summary>
	    public Int32 nUnderSpeedingPercentage;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1008)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_PARKING(��ͨΥ��ͣ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_PARKING_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] reserved;
        /// <summary>
        /// ��ʼͣ��ʱ��
        /// </summary>
	    public NET_TIME_EX stuStartParkingTime;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����(bEventAction=2ʱ�˲�����Ч)
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʱ��������λ:�롣(���¼�Ϊ�������¼������յ���һ�����¼�֮��
        /// ���ڳ������ʱ���δ�յ����¼��ĺ����¼�������Ϊ���¼��쳣������)
        /// </summary>
	    public Int32 nAlarmIntervalTime;
        /// <summary>
        /// ����ͣ��ʱ������λ���롣
        /// </summary>
	    public Int32 nParkingAllowedTime;
        /// <summary>
        /// ���������򶥵���
        /// </summary>
	    public Int32 nDetectRegionNum;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public DH_POINT[] DetectRegion;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 924)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    	
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFICJAM(��ͨӵ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFICJAM_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����; 
        /// </summary>
	    public byte bEventAction;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] reserved;
        /// <summary>
        /// ��ʼͣ��ʱ��
        /// </summary>
	    public NET_TIME_EX stuStartJamTime;
        /// <summary>
        /// ��ʾץ����ţ���3,2,1,1��ʾץ�Ľ���,0��ʾ�쳣����(bEventAction=2ʱ�˲�����Ч)
        /// </summary>
	    public Int32 nSequence;
        /// <summary>
        /// ����ʱ��������λ:�롣(���¼�Ϊ�������¼������յ���һ�����¼�֮��
        /// ���ڳ������ʱ���δ�յ����¼��ĺ����¼�������Ϊ���¼��쳣������)
        /// </summary>
	    public Int32 nAlarmIntervalTime;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ	
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_WRONGROUTE(��ͨΥ��-����������ʻ)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_WRONGROUTE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ����ʵ���ٶȣ�km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_CROSSLANE(��ͨΥ��-Υ�±��)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_CROSSLANE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;           
        /// <summary>
        /// ����ʵ���ٶȣ�km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	 
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	    public byte[] bReserved;
    	
    }


    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_OVERYELLOWLINE(��ͨΥ��-ѹ����)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ����ʵ���ٶȣ�km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    	
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_DRIVINGONSHOULDER(��ͨΥ��-·����ʻ�¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_DRIVINGONSHOULDER_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID; 
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ����ʵ���ٶȣ�km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	    public byte[] bReserved;
    	
    }

    /// <summary>
    /// �¼�����EVENT_IVS_TRAFFIC_YELLOWPLATEINLANE(��ͨΥ��-���Ƴ�ռ���¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// �¼�����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// ʱ���(��λ�Ǻ���)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// �¼�������ʱ��
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// �¼�ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// ��⵽������
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// ������Ϣ
        /// </summary>
	    public DH_MSG_OBJECT stuVehicle;
        /// <summary>
        /// ��Ӧ������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �¼���Ӧ�ļ���Ϣ               
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// �¼�������0��ʾ�����¼�,1��ʾ�������¼���ʼ,2��ʾ�������¼�����;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ����ʵ���ٶȣ�km/h
        /// </summary>
	    public Int32 nSpeed;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        /// <summary>
        /// �����ֽ�,������չ.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	    public byte[] bReserved;
        /// <summary>
        /// ��ͨ������Ϣ
        /// </summary>
	    public DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;
    	
    }

    /// <summary>
    /// �¼����� EVENT_IVS_FIREDETECTION(����¼�)��Ӧ�����ݿ�������Ϣ
    /// </summary>
    public struct DEV_EVENT_ELECTROSPARK_INFO 
    {
        /// <summary>
        /// ChannelId
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// event name
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szName;
        /// <summary>
        /// PTS(ms)
        /// </summary>
	    public double PTS;
        /// <summary>
        /// the event happen time
        /// </summary>
	    public NET_TIME_EX UTC;
        /// <summary>
        /// event ID
        /// </summary>
	    public Int32 nEventID;
        /// <summary>
        /// have being detected object
        /// </summary>
	    public DH_MSG_OBJECT stuObject;
        /// <summary>
        /// event file info
        /// </summary>
	    public DH_EVENT_FILE_INFO  stuFileInfo;
        /// <summary>
        /// Event action��0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        /// </summary>
	    public byte bEventAction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// ץͼ��־(��λ)�������NET_RESERVED_COMMON	
        /// </summary>
        public UInt32 dwSnapFlagMask;
        //reserved
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 972)]
	    public byte[] bReserved;
    	
    }

    #endregion

    #region <<CtrlTypeö����ؽṹ��>>

    /// <summary>
    /// �ֶ�ץ�Ĳ���
    /// </summary>
    public struct MANUAL_SNAP_PARAMETER
    {
        /// <summary>
        /// ץͼͨ��,��0��ʼ
        /// </summary>
        public Int32 nChannel;
        /// <summary>
        /// ץͼ���к��ַ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] bySequence;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] byReserved;
    }

    /// <summary>
    /// �����豸�˱���Ԥ���ָ����
    /// </summary>
    public struct DEVICE_LOCALPREVIEW_SLIPT_PARAMETER
    {
        /// <summary>
        /// �ָ�ģʽ�����豸�˱���Ԥ��֧�ֵķָ�ģʽ
        /// </summary>
        public Int32 nSliptMode;
        /// <summary>
        /// ��ǰҪԤ�����ӷָ�,��1��ʼ
        /// </summary>
        public Int32 nSubSliptNum;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] byReserved;
    }

    public struct WIFI_CONNECT
    {
        /// <summary>
        /// SSID
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szSSID;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] bReserved;
    };

    /// <summary>
    /// Ӳ�̲���
    /// </summary>
    public struct DISKCTRL_PARAM
    {
        /// <summary>
        /// �ṹ���С���汾������
        /// </summary>
	    public UInt32 dwSize; 
        /// <summary>
        /// ΪӲ����Ϣ�ṹ��DH_HARDDISK_STATE�������stDisks�±꣬��0��ʼ
        /// </summary>
	    public Int32 nIndex;
        /// <summary>
        /// �������ͣ�
        /// 0 - �������, 1 - ��Ϊ��д��, 2 - ��Ϊֻ����
        /// 3 - ��Ϊ������, 4 - �ָ�����, 5 - ��Ϊ�����̣�7 - ����SD������SD��������Ч��
        /// </summary>
	    public Int32 ctrlType;
        /// <summary>
        /// ������Ϣ, ���ڴ���˳����ܸı䵼���±겻׼, ���������±�
        /// </summary>
	    NET_DEV_DISKSTATE	stuDisk;
    }

    public struct  DISKCTRL_SUBAREA
    {
        /// <summary>
        /// Ԥ�����ĸ���
        /// </summary>
	    public byte bSubareaNum;
        /// <summary>
        /// ΪӲ����Ϣ�ṹ��DH_HARDDISK_STATE�������stDisks�±꣬��0��ʼ
        /// </summary>
	    public byte bIndex;
        /// <summary>
        /// ������С���ٷֱȣ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] bSubareaSize;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
	    public byte[] bReserved; 
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    public struct ALARMCTRL_PARAM
    {
	    public UInt32 dwSize;
        /// <summary>
        /// ����ͨ���ţ���0��ʼ
        /// </summary>
	    public Int32 nAlarmNo; 
        /// <summary>
        ///  1������������0��ֹͣ����
        /// </summary>
	    public Int32 nAction;
    }

    /// <summary>
    /// �������
    /// </summary>
    public struct MATRIXCTRL_PARAM
    {
	    public UInt32 dwSize;
        /// <summary>
        /// ��Ƶ����ţ���0��ʼ
        /// </summary>
	    public Int32 nChannelNo;
        /// <summary>
        /// ��������ţ���0��ʼ
        /// </summary>
	    public Int32 nMatrixNo;
    }
 
    /// <summary>
    /// ��¼����
    /// </summary>
    public struct BURNNG_PARM
    {
        /// <summary>
        /// ͨ�����룬��λ��ʾҪ��¼��ͨ��
        /// </summary>
	    public Int32 channelMask;
        /// <summary>
        /// ��¼�����룬���ݲ�ѯ���Ŀ�¼���б���λ��ʾ
        /// </summary>
	    public byte devMask;
        /// <summary>
        /// ���л�ͨ��(ͨ����+32)
        /// </summary>
	    public byte bySpicalChannel;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[] byReserved; 
    }

    /// <summary>
    /// ������¼
    /// </summary>
    public struct BURNING_PARM_ATTACH
    {
        /// <summary>
        /// �Ƿ�Ϊ������¼��0:����; 1:��
        /// </summary>
	    public Int32 bAttachBurn;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	    public byte[] bReserved; 
    } 

    /// <summary>
    /// �����豸ץͼ�����ӿ�����Ϣ
    /// </summary>
    public struct NET_SNAP_COMMANDINFO 
    {
        /// <summary>
        /// ������Ϣ
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szCardInfo;
        /// <summary>
        /// ����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] reserved;
    }

    public struct  BACKUP_RECORD
    {
        /// <summary>
        /// �����豸����
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szDeviceName;
        /// <summary>
        /// ���ݼ�¼����
        /// </summary>
	    public Int32 nRecordNum;
        /// <summary>
        /// ���ݼ�¼��Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public NET_RECORDFILE_INFO[]	stuRecordInfo;
    } 

    public struct DHDEV_VEHICLE_WIFI_CONFIG
    {
        /// <summary>
        /// SSID
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szSSID;
        /// <summary>
        /// ���ȼ�,(1-32)
        /// </summary>
        public int nPriority;
        /// <summary>
        /// У������
        /// 0:OPEN 
        /// 1:RESTRICTE
        /// 2:WEP
        /// 3:WPA
        /// 4:WPA2
        /// 5:WPA-PSK
        /// 6:WPA2-PSK
        /// </summary>
	    public int nSafeType;
        /// <summary>
        /// ���ܷ�ʽ
        /// 0:OPEN
        /// 1:TKIP
        /// 2:WEP
        /// 3:AES
        /// 4:NONE(��У��)
        /// </summary>
	    public int nEncryprion;
        /// <summary>
        /// ������Կ
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szKey;
        /// <summary>
        /// ������ַ
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]	szHostIP;
        /// <summary>
        /// ��������
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]	szHostNetmask;
        /// <summary>
        /// ��������
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]	szHostGateway;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[]	bReserved;
    } 

    public struct DHDEV_USER_REJECT_INFO
    {
        /// <summary>
        /// ip
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szIpAddress;
        /// <summary>
        /// User Group
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szUserGroup;
        /// <summary>
        /// User Name
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szUserName;
        /// <summary>
        /// c++������Ϊpublic byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] reserved;
    }

    /// <summary>
    /// �޳��û�
    /// </summary>
    public struct DHDEV_REJECT_USER
    { 
        /// <summary>
        /// �û�����
        /// </summary>
	    public Int32 nUserCount; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	    public DHDEV_USER_REJECT_INFO[] stuUserInfo;
        /// <summary>
        /// c++������Ϊpublic byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] reserved;
    }

    public struct DHDEV_USER_SHIELD_INFO
    {
        /// <summary>
        /// ip��ַ
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szIpAddress;
        /// <summary>
        /// �û���
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szUserGroup;
        /// <summary>
        /// �û���
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szUserName;
        /// <summary>
        /// ����ʱ��
        /// public byte[]
        /// </summary>
	    public Int32 nForbiddenTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] reserved;
    }

    /// <summary>
    /// �����û�
    /// </summary>
    public struct DHDEV_SHIELD_USER
    { 
        /// <summary>
        /// �û�����
        /// </summary>
	    public Int32 nUserCount; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	    public DHDEV_USER_SHIELD_INFO[] stuUserInfo;     
        /// <summary>
        /// c++������Ϊpublic byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] reserved;
    }

    #endregion

    #region <<�ṹ��--����������--��ӦCLIENT_QueryNewSystemInfo>>


    // ����֧�ֵĹ���
    public struct SCENE_SUPPORT_RULE
    {
        /// <summary>
        /// ��������
        /// </summary>
	    public UInt32 dwSupportedRule;
        /// <summary>
        /// ��ǰ��������֧�ֵļ���������͸���
        /// </summary>
	    public Int32 nSupportedObjectTypeNum;
        /// <summary>
        /// ��ǰ��������֧�ֵļ�����������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypeName;
        /// <summary>
        /// ��ǰ��������֧�ֵļ�����嶯������
        /// </summary>
	    public int nSupportedActionsNum;
        /// <summary>
        /// ��ǰ��������֧�ֵļ�����嶯���б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szSupportedActions;
        /// <summary>
        /// ��ǰ��������֧�ֵļ�����͸���
        /// </summary>
	    public Int32 nSupportedDetectTypeNum;
        /// <summary>
        /// ��ǰ��������֧�ֵļ�������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szSupportedDetectTypes; 
    }

    /// <summary>
    /// �궨����������Ϣ
    /// </summary>
    public struct CFG_CAP_CELIBRATE_AREA
    {
        /// <summary>
        /// �궨��������
        /// </summary>
	    public EM_CALIBRATEAREA_TYPE  emType;
        /// <summary>
        /// ֧�ֵ�ˮƽ���������
        /// </summary>
        public byte byMaxHorizontalStaffNum;
        /// <summary>
        /// ֧�ֵ�ˮƽ�����С����
        /// </summary>
        public byte byMinHorizontalStaffNum;
        /// <summary>
        /// ֧�ֵĴ�ֱ���������
        /// </summary>
        public byte byMaxVerticalStaffNum;
        /// <summary>
        /// ֧�ֵĴ�ֱ�����С����
        /// </summary>
        public byte byMinVerticalStaffNum;
    }

    /// <summary>
    /// ��������
    /// </summary>
    public struct CFG_CAP_SCENE
    {
        /// <summary>
        /// ��������
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	    public byte[] szSceneName; 
        /// <summary>
        /// ��ǰ��������֧�ֵļ���������͸���
        /// </summary>
	    public Int32 nSupportedObjectTypeNum;
        /// <summary>
        /// ��ǰ��������֧�ֵļ�����������б�
        /// public byte[]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypeName;
        /// <summary>
        /// ֧�ֵĹ������
        /// </summary>
	    public Int32 nSupportRules;
        /// <summary>
        /// ֧�ֵĹ����б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public SCENE_SUPPORT_RULE[] stSpportRules;

	    //֧�ֵ�ģ�����
        /// <summary>
        /// �Ƿ�֧���Ŷ�ǿ������
        /// </summary>
	    public byte bDisturbance;
        /// <summary>
        /// �Ƿ�֧��ȥ�Ŷ�����
        /// </summary>
	    public byte bAntiDisturbance;
        /// <summary>
        /// �Ƿ�֧����⴦��
        /// </summary>
	    public byte bBacklight;
        /// <summary>
        /// �Ƿ�֧����Ӱ����
        /// </summary>
	    public byte bShadow;
        /// <summary>
        /// �Ƿ�֧�ּ�⾫��
        /// </summary>
	    public byte bAccuracy;
        /// <summary>
        /// �Ƿ�֧�ּ�ⲽ��
        /// </summary>
	    public byte bMovingStep;
        /// <summary>
        /// �Ƿ�֧�ּ������
        /// </summary>
	    public byte bScalingFactor;
        /// <summary>
        /// �Ƿ�֧��Y�����ж���ֵ
        /// </summary>
	    public byte bThresholdY;
        /// <summary>
        /// �Ƿ�֧��UV�����ж���ֵ
        /// </summary>
	    public byte bThresholdUV;
        /// <summary>
        /// �Ƿ�֧�ֱ�Ե����ж���ֵ
        /// </summary>
	    public byte bThresholdEdge;
        /// <summary>
        /// �Ƿ�֧�ּ��ƽ��
        /// </summary>
	    public byte bDetectBalance;
        /// <summary>
        /// �Ƿ�֧���㷨���
        /// </summary>
	    public byte bAlgorithmIndex;
        /// <summary>
        /// �Ƿ�֧�ָ߹⴦����Backgroud���� 
        /// </summary>
	    public byte bHighlight;
        /// <summary>
        /// �Ƿ�֧������ץͼ
        /// </summary>
	    public byte bSnapshot;

	    //֧�ֵĳ�������
        /// <summary>
        /// �Ƿ�����ͷλ�ò���
        /// </summary>
	    public byte bCameraAspect;
        /// <summary>
        /// �Ƿ�֧�ֶ�������
        /// </summary>
	    public byte bJitter;
        /// <summary>
        /// �Ƿ�֧��ȥ�����������
        /// </summary>
	    public byte bDejitter;

	    // ֧�ֵı궨������
        /// <summary>
        /// ���궨�������
        /// </summary>
	    public int nMaxCalibrateAreaNum;
        /// <summary>
        /// �궨����������Ϣ����
        /// </summary>
	    public int nCalibrateAreaNum;
        /// <summary>
        /// �궨����������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public CFG_CAP_CELIBRATE_AREA[] stCalibrateAreaCap;

    };


    /// <summary>
    /// �����б�
    /// </summary>
    public struct CFG_VACAP_SUPPORTEDSCENES
    {
        /// <summary>
        /// ֧�ֵĳ�������
        /// </summary>
	    public Int32 nScenes;
        /// <summary>
        /// ֧�ֵĳ����б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public CFG_CAP_SCENE[] stScenes;
    }


    public struct DEVICE_STATUS
    {
        /// <summary>
        /// Զ���豸������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]szDeviceName;
        /// <summary>
        /// Զ���豸��״̬ 0������ 1������
        /// </summary>
	    public byte	bDeviceStatus;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 63)]
	    public byte[] bReserved;
    }


    public struct CFG_REMOTE_DEVICE_STATUS
    {
        /// <summary>
        /// �豸״̬
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public DEVICE_STATUS[] devStatus;
        /// <summary>
        /// �豸����
        /// </summary>
	    public UInt32 dwDevCount;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[] bReserved;
    }

    /// <summary>
    /// ��Ƶ�����豸������Ϣ
    /// </summary>
    public struct CFG_CAP_DEVICE_ANALYSE_INFO
    {
        /// <summary>
        /// ֧�����ܷ��������ͨ����
        /// </summary>
	    public Int32 nMaxChannels;
    }

    /// <summary>
    /// ��Ƶ����������(CFG_CAP_CMD_VIDEOINPUT)����
    /// </summary>
    public struct CFG_CAP_VIDEOINPUT_INFO
    {
        /// <summary>
        /// ������������
        /// </summary>
	    public Int32 nMeteringRegionCount;
    };


    /// <summary>
    /// ʱ��
    /// </summary>
    public struct CFG_NET_TIME
    {
	    Int32 nStructSize;
        /// <summary>
        /// ��
        /// </summary>
	    UInt32 dwYear;
        /// <summary>
        /// ��
        /// </summary>
        UInt32 dwMonth;
        /// <summary>
        /// ��
        /// </summary>
        UInt32 dwDay;
        /// <summary>
        /// ʱ
        /// </summary>
        UInt32 dwHour;
        /// <summary>
        /// ��
        /// </summary>
        UInt32 dwMinute;
        /// <summary>
        /// ��
        /// </summary>
        UInt32 dwSecond;
    }


    public struct CFG_ACTIVEUSER_INFO
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ��û�ID��һ���ǻỰID
        /// </summary>
	    public Int32 nUserID;
        /// <summary>
        /// �û���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szUser;
        /// <summary>
        /// �û���������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szGroupName;
        /// <summary>
        /// �û�������ȼ�
        /// </summary>
	    public int  nGroupLevel;
        /// <summary>
        /// �ͻ�������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szClientType;
        /// <summary>
        /// �ͻ���IP��ַ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szClientAddr;
        /// <summary>
        /// �û�����ʱ��
        /// </summary>
	    public CFG_NET_TIME  stuLoginTime;
    };


    public struct CFG_NET_TIME_EX
    {
        /// <summary>
        /// ��
        /// </summary>
	    public UInt32 dwYear;
        /// <summary>
        /// ��
        /// </summary>
	    public UInt32 dwMonth;
        /// <summary>
        /// ��
        /// </summary>
	    public UInt32 dwDay;
        /// <summary>
        /// ʱ
        /// </summary>
	    public UInt32 dwHour;
        /// <summary>
        /// ��
        /// </summary>
	    public UInt32 dwMinute;
        /// <summary>
        /// ��
        /// </summary>
	    public UInt32 dwSecond;
        /// <summary>
        /// ����
        /// </summary>
	    public UInt32 dwMillisecond;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public UInt32[] dwReserved;
    }

    /// <summary>
    /// ��ȡ��Ƶͳ��ժҪ��Ϣ�ṹ��
    /// </summary>
    public struct CFG_VIDEOSATA_SUMMARY_INFO
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ͳ��ͨ����
        /// </summary>
        public Int32 nChannelID;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szRuleName;
        /// <summary>
        /// ͳ��ʱ�䣬ת����UTC
        /// </summary>
        public CFG_NET_TIME_EX stuStatTime;
        /// <summary>
        /// �����ܼ�
        /// </summary>
        public Int32 nEnteredTotal;
        /// <summary>
        /// ��������ܼ�
        /// </summary>
        public Int32 nEnteredToday;
        /// <summary>
        /// ���½����ܼ�
        /// </summary>
        public Int32 nEnteredMonth;
        /// <summary>
        /// ��������ܼ�
        /// </summary>
        public Int32 nEnteredYear;
        /// <summary>
        /// ÿ���������ܼ�
        /// </summary>
        public Int32 nEnteredDaily;
        /// <summary>
        /// ��ȥ�ܼ�
        /// </summary>
        public Int32 nExitedTotal;
        /// <summary>
        /// �����ȥ�ܼ�
        /// </summary>
        public Int32 nExitedToday;
        /// <summary>
        /// ���³�ȥ�ܼ�
        /// </summary>
        public Int32 nExitedMonth;
        /// <summary>
        /// �����ȥ�ܼ�
        /// </summary>
        public Int32 nExitedYear;
        /// <summary>
        /// ÿ������ȥ�ܼ�
        /// </summary>
        public Int32 nExitedDaily;
        /// <summary>
        /// ƽ�����б���ͳ��(��ȥ��ֵ)
        /// </summary>
        public Int32 nAvgTotal;
        /// <summary>
        /// ƽ�����챣��ͳ��
        /// </summary>
        public Int32 nAvgToday;
        /// <summary>
        /// ƽ�����±���ͳ��
        /// </summary>
        public Int32 nAvgMonth;
        /// <summary>
        /// ƽ�����걣��ͳ��         
        /// </summary>
        public Int32 nAvgYear;
        /// <summary>
        /// ������б���ͳ��(��ȥ��ֵ)
        /// </summary>
        public Int32 nMaxTotal;
        /// <summary>
        /// �����챣��ͳ��
        /// </summary>
        public Int32 nMaxToday;
        /// <summary>
        /// ����±���ͳ��
        /// </summary>
        public Int32 nMaxMonth;
        /// <summary>
        /// �����걣��ͳ��
        /// </summary>
        public Int32 nMaxYear;
    }

    // ��Ƶ��Ϸ���������(CFG_CAP_CMD_VIDEODIAGNOSIS_SERVER)
    public struct CFG_VIDEODIAGNOSIS_CAPS_INFO
    {
        /// <summary>
        /// ֧�ֵ���Ƶ������� ����
        /// </summary>
	    public Int32 nTypeCount;
        /// <summary>
        /// ֧�ֵ���Ƶ�������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11 * 260)]
	    public byte[] szSupportedType;
        /// <summary>
        /// �����������
        /// </summary>
	    public Int32 nMaxProfiles;
        /// <summary>
        /// ����������
        /// </summary>
	    public Int32 nMaxTasks;
        /// <summary>
        /// ��󵥸��������ƵԴ����
        /// </summary>
	    public Int32 nMaxSourcesOfTask;
        /// <summary>
        /// ��󷽰�����
        /// </summary>
	    public Int32 nMaxProjects;
    }

    #endregion

    #region <<�ṹ��--�������� ��ӦCLIENT_GetNewDevConfig��CLIENT_SetNewDevConfig�ӿ�>>



    /// <summary>
    /// ��Ƶ��ʽ
    /// </summary>
    public struct CFG_VIDEO_FORMAT
    {
	    // ����
	    public byte abCompression;
        public byte abWidth;
        public byte abHeight;
        public byte abBitRateControl;
        public byte abBitRate;
        public byte abFrameRate;
        public byte abIFrameInterval;
        public byte abImageQuality;
        public byte abFrameType;

	    // ��Ϣ
        /// <summary>
        /// ��Ƶѹ����ʽ
        /// </summary>
        public CFG_VIDEO_COMPRESSION emCompression;
        /// <summary>
        /// ��Ƶ���
        /// </summary>
        public Int32 nWidth;
        /// <summary>
        /// ��Ƶ�߶�
        /// </summary>
        public Int32 nHeight;
        /// <summary>
        /// ��������ģʽ
        /// </summary>
        public CFG_BITRATE_CONTROL emBitRateControl;
        /// <summary>
        /// ��Ƶ����(kbps)
        /// </summary>
        public Int32 nBitRate;
        /// <summary>
        /// ��Ƶ֡��
        /// </summary>
        public Int32 nFrameRate;
        /// <summary>
        /// I֡���(1-100)������50��ʾÿ49��B֡��P֡������һ��I֡��
        /// </summary>
        public Int32 nIFrameInterval;
        /// <summary>
        /// ͼ������
        /// </summary>
        public CFG_IMAGE_QUALITY emImageQuality;
        /// <summary>
        /// ���ģʽ��0��DHAV��1��"PS"
        /// </summary>
        public Int32 nFrameType;
    } 

    /// <summary>
    /// ��Ƶ�������
    /// </summary>
    public struct CFG_VIDEOENC_OPT
    {
	    // ����
	    public byte abVideoEnable;
        public byte abAudioEnable;
        public byte abSnapEnable;
        /// <summary>
        /// ��Ƶ��������
        /// </summary>
        public byte abAudioAdd;

	    // ��Ϣ
        /// <summary>
        /// ��Ƶʹ��
        /// </summary>
        public bool bVideoEnable;
        /// <summary>
        /// ��Ƶ��ʽ
        /// </summary>
        public CFG_VIDEO_FORMAT stuVideoFormat;
        /// <summary>
        /// ��Ƶʹ��
        /// </summary>
        public bool bAudioEnable;
        /// <summary>
        /// ��ʱץͼʹ��
        /// </summary>
        public bool bSnapEnable;
        /// <summary>
        /// ��Ƶ����ʹ��
        /// </summary>
        public bool bAudioAddEnable;
    } 

    /// <summary>
    /// RGBA��Ϣ
    /// </summary>
    public struct CFG_RGBA
    {
	    Int32 nRed;
	    Int32 nGreen;
	    Int32 nBlue;
	    Int32 nAlpha;
    }

    /// <summary>
    /// �ڵ���Ϣ
    /// </summary>
    public struct CFG_COVER_INFO
    {
	    // ����
	    public byte abBlockType;
        public byte abEncodeBlend;
        public byte abPreviewBlend;

	    // ��Ϣ
        /// <summary>
        /// ���ǵ���������
        /// </summary>
        public CFG_RECT stuRect;
        /// <summary>
        /// ���ǵ���ɫ
        /// </summary>
        public CFG_RGBA stuColor;
        /// <summary>
        /// ���Ƿ�ʽ��0���ڿ飬1��������
        /// </summary>
        public Int32 nBlockType;
        /// <summary>
        /// ���뼶�ڵ���1����Ч��0������Ч
        /// </summary>
        public Int32 nEncodeBlend;
        /// <summary>
        /// Ԥ���ڵ���1����Ч��0������Ч
        /// </summary>
        public Int32 nPreviewBlend;
    } 

    /// <summary>
    /// �������ڵ�����
    /// </summary>
    public struct CFG_VIDEO_COVER
    {
        /// <summary>
        /// ֧�ֵ��ڵ�����
        /// </summary>
	    public Int32 nTotalBlocks;
        /// <summary>
        /// �����õĿ���
        /// </summary>
	    public Int32 nCurBlocks;
        /// <summary>
        /// ���ǵ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public CFG_COVER_INFO[] stuCoverBlock;
    } 

    /// <summary>
    /// OSD��Ϣ
    /// </summary>
    public struct CFG_OSD_INFO
    {
	    // ����
	    public byte abShowEnable;

	    // ��Ϣ
        /// <summary>
        /// ǰ����ɫ
        /// </summary>
        public CFG_RGBA stuFrontColor;
        /// <summary>
        /// ������ɫ
        /// </summary>
        public CFG_RGBA stuBackColor;
        /// <summary>
        /// ��������
        /// </summary>
        public CFG_RECT stuRect;
        /// <summary>
        /// ��ʾʹ��
        /// </summary>
        public bool bShowEnable;
    }

    /// <summary>
    /// ������ɫ����
    /// </summary>
    public struct CFG_COLOR_INFO
    {
        /// <summary>
        /// ����(0-100)
        /// </summary>
	    public Int32 nBrightness;
        /// <summary>
        /// �Աȶ�(0-100) 
        /// </summary>
        public Int32 nContrast;
        /// <summary>
        /// ���Ͷ�(0-100)
        /// </summary>
        public Int32 nSaturation;
        /// <summary>
        /// ɫ��(0-100)
        /// </summary>
        public Int32 nHue;
        /// <summary>
        /// ����(0-100)
        /// </summary>
        public Int32 nGain;
        /// <summary>
        /// ����ʹ��
        /// </summary>
        public bool bGainEn;
    } ;

    /// <summary>
    /// ͼ��ͨ��������Ϣ
    /// </summary>
    public struct CFG_ENCODE_INFO
    {
        /// <summary>
        /// ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szChnName;
        /// <summary>
        /// ��������0����ͨ¼��1-����¼��2������¼��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public CFG_VIDEOENC_OPT[]	stuMainStream;
        /// <summary>
        /// ��������0��������1��1��������2��2��������3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public CFG_VIDEOENC_OPT[]	stuExtraStream;
        /// <summary>
        /// ץͼ��0����ͨץͼ��1������ץͼ��2������ץͼ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public CFG_VIDEOENC_OPT[]	stuSnapFormat;
        /// <summary>
        /// �����ڸ��������룬��λ�ֱ��Ǳ���Ԥ����¼���������
        /// </summary>
	    public UInt32 dwCoverAbilityMask;
        /// <summary>
        /// �����ڸ�ʹ�����룬��λ�ֱ��Ǳ���Ԥ����¼���������
        /// </summary>
	    public UInt32 dwCoverEnableMask;
        /// <summary>
        /// ���򸲸�
        /// </summary>
	    public CFG_VIDEO_COVER stuVideoCover;
        /// <summary>
        /// ͨ������
        /// </summary>
	    public CFG_OSD_INFO stuChnTitle;
        /// <summary>
        /// ʱ�����
        /// </summary>
	    public CFG_OSD_INFO stuTimeTitle;
        /// <summary>
        /// ������ɫ
        /// </summary>
	    public CFG_COLOR_INFO stuVideoColor;
        /// <summary>
        /// ��Ƶ��ʽ: 0:G711A,1:PCM,2:G711U,3:AMR,4:AAC
        /// </summary>
	    public CFG_AUDIO_FORMAT emAudioFormat;
    } ;

    /// <summary>
    /// �����ʽ, ������Ƶ����Ƶ
    /// </summary>
    public struct AV_CFG_EncodeFormat
    {
        public Int32 nStructSize;
        /// <summary>
        /// ��Ƶʹ��
        /// </summary>
        public bool bAudioEnable;
        /// <summary>
        /// ��Ƶ������
        /// </summary>
        public Int32 nAudioBitRate;
        /// <summary>
        /// ��Ƶѹ��ģʽ
        /// </summary>
        public CFG_AUDIO_FORMAT emAudioCompression;
        /// <summary>
        /// ��Ƶ�������
        /// </summary>
        public Int32 nAudioDepth;
        /// <summary>
        /// ��Ƶ����Ƶ��
        /// </summary>
        public Int32 nAudioFrequency;
        /// <summary>
        /// ��Ƶ����ģʽ
        /// </summary>
        public Int32 nAudioMode;
        /// <summary>
        /// ��Ƶ���ģʽ, 0-DHAV, 1-PS
        /// </summary>
        public Int32 nAudioPack;
        /// <summary>
        /// ��Ƶʹ��
        /// </summary>
        public bool bVideoEnable;
        /// <summary>
        /// ��Ƶ������
        /// </summary>
        public Int32 nVideoBitRate;
        /// <summary>
        /// ��������ģʽ
        /// </summary>
        public CFG_BITRATE_CONTROL emVideoBitRateControl;
        /// <summary>
        /// ��Ƶѹ��ģʽ
        /// </summary>
        public CFG_VIDEO_COMPRESSION emVideoCompression;
        /// <summary>
        /// ��Ƶ֡��
        /// </summary>
        public Int32 nVideoFPS;
        /// <summary>
        /// ��ƵI֡���
        /// </summary>
        public Int32 nVideoGOP;
        /// <summary>
        /// ��Ƶ���
        /// </summary>
        public Int32 nVideoWidth;
        /// <summary>
        /// ��Ƶ�߶�
        /// </summary>
        public Int32 nVideoHeight;
        /// <summary>
        /// ��Ƶͼ������
        /// </summary>
        public CFG_IMAGE_QUALITY emVideoQuality;
        /// <summary>
        /// ��Ƶ���ģʽ, 0-DHAV, 1-PS	
        /// </summary>
        public Int32 nVideoPack;
    };

    /// <summary>
    /// ��������
    /// </summary>
    public struct AV_CFG_Encode 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ������, ������ͨ����, �������, ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public AV_CFG_EncodeFormat[] stuMainFormat;
        /// <summary>
        /// ������, ����������1, ������2, ������3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public AV_CFG_EncodeFormat[]	stuExtraFormat;
        /// <summary>
        /// ץͼ, ������ͨץͼ, ����ץͼ, ����ץͼ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public AV_CFG_EncodeFormat[]	stuSnapFormat;
    }

    /// <summary>
    /// ʱ�����Ϣ
    /// </summary>
    public struct CFG_TIME_SECTION 
    {
        /// <summary>
        /// ¼�����룬��λ�ֱ�Ϊ��̬���¼�񡢱���¼�񡢶�ʱ¼��Bit3~Bit15������
        /// Bit16��̬���ץͼ��Bit17����ץͼ��Bit18��ʱץͼ
        /// </summary>
	    UInt32 dwRecordMask;
	    Int32 nBeginHour;
	    Int32 nBeginMin;
	    Int32 nBeginSec;
	    Int32 nEndHour;
	    Int32 nEndMin;
	    Int32 nEndSec;	
    } 


    /// <summary>
    /// ��ʱ¼��������Ϣ
    /// </summary>
    public struct CFG_RECORD_INFO
    {
        /// <summary>
        /// ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
        public CFG_TIME_SECTION[] stuTimeSection;
        /// <summary>
        /// Ԥ¼ʱ�䣬Ϊ��ʱ��ʾ�ر�(0~300)
        /// </summary>
        public Int32 nPreRecTime;
        /// <summary>
        /// ¼�����࿪��
        /// </summary>
        public bool bRedundancyEn;
        /// <summary>
        /// 0����������1��������1��2��������2��3��������3
        /// </summary>
        public Int32 nStreamType;
    }

    /// <summary>
    /// ʱ���
    /// </summary>
    public struct AV_CFG_TimeSection
    {
        public Int32 nStructSize;
        /// <summary>
        /// ����
        /// </summary>
        public Int32 nMask;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public Int32 nBeginHour;
        public Int32 nBeginMinute;
        public Int32 nBeginSecond;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public Int32 nEndHour;
        public Int32 nEndMinute;
        public Int32 nEndSecond;
    };
    
    // ¼������
    public struct AV_CFG_Record 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// Ԥ¼ʱ��, ��λs
        /// </summary>
        public Int32 nPreRecord; 
        /// <summary>
        /// ʱ��� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
        public AV_CFG_TimeSection[] stuTimeSection;
    };

    /// <summary>
    /// ������̨��Ϣ
    /// </summary>
    public struct CFG_PTZ_LINK
    {
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_LINK_TYPE emType;
        /// <summary>
        /// ����ȡֵ�ֱ��ӦԤ�õ�ţ�Ѳ���ŵȵ�
        /// </summary>
	    public Int32 nValue; 
    }

    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public struct CFG_ALARM_MSG_HANDLE
    {
	    //����
	    public byte abRecordMask;
	    public byte abRecordEnable;
	    public byte abRecordLatch;
	    public byte abAlarmOutMask;
	    public byte abAlarmOutEn;
	    public byte abAlarmOutLatch;	
	    public byte abExAlarmOutMask;
	    public byte abExAlarmOutEn;
	    public byte abPtzLinkEn;
	    public byte abTourMask;
	    public byte abTourEnable;
	    public byte abSnapshot;
	    public byte abSnapshotEn;
	    public byte abSnapshotPeriod;
	    public byte abSnapshotTimes;
	    public byte abTipEnable;
	    public byte abMailEnable;
	    public byte abMessageEnable;
	    public byte abBeepEnable;
	    public byte abVoiceEnable;
	    public byte abMatrixMask;
	    public byte abMatrixEnable;
	    public byte abEventLatch;
	    public byte abLogEnable;
	    public byte abDelay;
	    public byte abVideoMessageEn;
	    public byte abMMSEnable;
	    public byte abMessageToNetEn;
	    public byte abTourSplit;
	    public byte abSnapshotTitleEn;

	    //��Ϣ
        /// <summary>
        /// �豸����Ƶͨ����
        /// </summary>
	    public Int32 	nChannelCount;
        /// <summary>
        /// �豸�ı����������
        /// </summary>
	    public Int32 	nAlarmOutCount;
        /// <summary>
        /// ¼��ͨ������(��λ)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public UInt32[] dwRecordMask; 
        /// <summary>
        /// ¼��ʹ��
        /// </summary>
	    public bool bRecordEnable;
        /// <summary>
        /// ¼����ʱʱ��(��)
        /// </summary>
	    public Int32 	nRecordLatch;
        /// <summary>
        /// �������ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public UInt32[] dwAlarmOutMask;
        /// <summary>
        /// �������ʹ��
        /// </summary>
	    public bool bAlarmOutEn;
        /// <summary>
        /// ���������ʱʱ��(��)
        /// </summary>
	    public Int32 	nAlarmOutLatch;
        /// <summary>
        /// ��չ�������ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public  UInt32[] dwExAlarmOutMask;
        /// <summary>
        /// ��չ�������ʹ��
        /// </summary>
	    public bool bExAlarmOutEn;
        /// <summary>
        /// ��̨������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public CFG_PTZ_LINK[] stuPtzLink;
        /// <summary>
        /// ��̨����ʹ��
        /// </summary>
	    public bool bPtzLinkEn;
        /// <summary>
        /// ��ѯͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public UInt32[] dwTourMask;
        /// <summary>
        /// ��ѯʹ��
        /// </summary>
	    public bool bTourEnable;
        /// <summary>
        /// ����ͨ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public UInt32[] dwSnapshot;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public bool bSnapshotEn;
        /// <summary>
        /// ��������(��)
        /// </summary>
	    public Int32 	nSnapshotPeriod;
        /// <summary>
        /// ���Ĵ���
        /// </summary>
	    public Int32 	nSnapshotTimes;
        /// <summary>
        /// ������Ϣ����ʾ
        /// </summary>
	    public bool bTipEnable;
        /// <summary>
        /// �����ʼ��������ͼƬ����Ϊ����
        /// </summary>
	    public bool bMailEnable;
        /// <summary>
        /// �ϴ�������������
        /// </summary>
	    public bool bMessageEnable;
        /// <summary>
        /// ����
        /// </summary>
	    public bool bBeepEnable;
        /// <summary>
        /// ������ʾ
        /// </summary>
	    public bool bVoiceEnable;
        /// <summary>
        /// ������Ƶ����ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public UInt32[] dwMatrixMask;
        /// <summary>
        /// ������Ƶ����
        /// </summary>
	    public bool bMatrixEnable;
        /// <summary>
        /// ������ʼ��ʱʱ��(��)��0��15
        /// </summary>
	    public Int32 	nEventLatch;
        /// <summary>
        /// �Ƿ��¼��־
        /// </summary>
	    public bool bLogEnable;
        /// <summary>
        /// ����ʱ����ʱ����Ч����λΪ��
        /// </summary>
	    public Int32 	nDelay;
        /// <summary>
        /// ������ʾ��Ļ����Ƶ�����ӵ���Ļ�����¼����ͣ�ͨ���ţ����ʱ��
        /// </summary>
	    public bool bVideoMessageEn;
        /// <summary>
        /// ���Ͳ���ʹ��
        /// </summary>
	    public bool bMMSEnable;
        /// <summary>
        /// ��Ϣ�ϴ�������ʹ��
        /// </summary>
	    public bool bMessageToNetEn;
        /// <summary>
        /// ��Ѳʱ�ķָ�ģʽ 0: 1����; 1: 8����
        /// </summary>
	    public Int32 	nTourSplit;
        /// <summary>
        /// �Ƿ����ͼƬ����
        /// </summary>
	    public bool bSnapshotTitleEn;
    }

    // �ⲿ��������
    public struct CFG_ALARMIN_INFO
    {
        /// <summary>
        /// ����ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ����ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szChnName;
        /// <summary>
        /// ���������ͣ�0�����գ�1������
        /// </summary>
	    public Int32 nAlarmType;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
    }


    // �������뱨������
    public struct CFG_NETALARMIN_INFO 
    {
        /// <summary>
        /// ����ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ����ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szChnName;
        /// <summary>
        /// ���������ͣ�0�����գ�1������
        /// </summary>
	    public Int32 nAlarmType;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
    }

    // ��̬��ⱨ������
    public struct CFG_MOTION_INFO 
    {
        /// <summary>
        /// ����ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ������1��6
        /// </summary>
	    public Int32 nSenseLevel;
        /// <summary>
        /// ��̬������������
        /// </summary>
	    public Int32 nMotionRow;
        /// <summary>
        /// ��̬������������
        /// </summary>
	    public Int32 nMotionCol;
        /// <summary>
        /// ����������32*32������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 32)]
	    public byte[] byRegion;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
    } 

    // ��Ƶ��ʧ��������
    public struct CFG_VIDEOLOST_INFO 
    {
        /// <summary>
        /// ����ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
    } 

    // ��Ƶ�ڵ���������
    public struct CFG_SHELTER_INFO 
    {
        /// <summary>
        /// ����ͨ����(0��ʼ)
        /// </summary>
        public Int32 nChannelID;
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
        public bool bEnable;
        /// <summary>
        /// ������
        /// </summary>
        public Int32 nSenseLevel;
        /// <summary>
        /// ��������
        /// </summary>
        public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
        public CFG_TIME_SECTION[] stuTimeSection;
    }

    // �޴洢�豸��������
    public struct CFG_STORAGENOEXIST_INFO 
    {
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
    } ;

    // �洢�豸���ʳ���������
    public struct CFG_STORAGEFAILURE_INFO 
    {
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
    } 

    // �洢�豸�ռ䲻�㱨������
    public struct CFG_STORAGELOWSAPCE_INFO 
    {
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// Ӳ��ʣ���������ޣ��ٷ���(0~99)
        /// </summary>
	    public Int32 nLowerLimit;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
    } 

    // ����Ͽ���������
    public struct CFG_NETABORT_INFO 
    {
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������
        /// </summary>
        public CFG_ALARM_MSG_HANDLE stuEventHandler;
    } 

    // IP��ͻ��������
    public struct CFG_IPCONFLICT_INFO 
    {
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
    } 

    // ץͼ��������
    public struct CFG_SNAPCAPINFO_INFO  
    {
        /// <summary>
        /// ץͼͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ֧�ֵķֱ�����Ϣ
        /// </summary>
        public UInt32 dwIMageSizeNum;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public CFG_CAPTURE_SIZE[] emIMageSizeList;
        /// <summary>
        /// ֧�ֵ�֡����Ϣ
        /// </summary>
        public UInt32 dwFramesPerSecNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public Int32[] nFramesPerSecList;
        /// <summary>
        /// ֧�ֵĻ�����Ϣ
        /// </summary>
        public UInt32 dwQualityMun;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public CFG_IMAGE_QUALITY[] emQualityList;
        /// <summary>
        /// ģʽ,��λ����һλ����ʱ���ڶ�λ���ֶ���
        /// </summary>
        public UInt32 dwMode;
        /// <summary>
        /// ͼƬ��ʽģʽ,��λ����һλ��bmp���ڶ�λ��jpg��
        /// </summary>
        public UInt32 dwFormat;
    } 

    // ����洢����������
    public struct CFG_CHANNEL_TIME_SECTION 
    {
        /// <summary>
        /// �洢ʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 2)]
	    public CFG_TIME_SECTION[] stuTimeSection;
    } 

    public struct CFG_NAS_INFO
    {
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ����洢�������汾0=�ϵ�FTP��1=NAS�洢
        /// </summary>
	    public Int32 nVersion;
        /// <summary>
        /// Э������0=FTP 1=SMB
        /// </summary>
	    public Int32 nProtocol;
        /// <summary>
        /// IP��ַ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szAddress;
        /// <summary>
        /// �˿ں�
        /// </summary>
	    public Int32 nPort;
        /// <summary>
        /// �ʻ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szUserName;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szPassword;
        /// <summary>
        /// �����Ŀ¼��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szDirectory;
        /// <summary>
        /// �ļ�����
        /// </summary>
	    public Int32 nFileLen;
        /// <summary>
        /// �����ļ�ʱ����
        /// </summary>
	    public Int32 nInterval;
        /// <summary>
        /// �洢ʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public CFG_CHANNEL_TIME_SECTION[] stuChnTime;
        /// <summary>
        /// ��Ч�Ĵ洢ʱ�����
        /// </summary>
	    public Int32 nChnTimeCount;
    } 

    // Э����
    public struct CFG_PRONAME
    {
        /// <summary>
        /// Э���� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] name;
    } 

    // ���ڻ�������
    public struct CFG_COMM_PROP
    {
        /// <summary>
        /// ����λ��0��5��1��6��2��7��3��8
        /// </summary>
	    public byte byDataBit;
        /// <summary>
        /// ֹͣλ��0��1λ��1��1.5λ��2��2λ
        /// </summary>
        public byte byStopBit;
        /// <summary>
        /// У��λ��0����У�飬1����У�飻2��żУ��
        /// </summary>
        public byte byParity;
        /// <summary>
        /// �����ʣ�0��300��1��600��2��1200��3��2400��4��4800��
        /// 5��9600��6��19200��7��38400��8��57600��9��115200
        /// </summary>
        public byte byBaudRate;
	        
    } 


    // ��̨����
    public struct CFG_PTZ_INFO
    {
	    // ����
	    public byte abMartixID;
        public byte abCamID;
        public byte abPTZType;

	    // ��Ϣ
        /// <summary>
        /// ͨ����(0��ʼ)	
        /// </summary>
        public Int32 nChannelID;
        /// <summary>
        /// Э�����б�(ֻ��)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public CFG_PRONAME[] stuDecProName;
        /// <summary>
        /// Э�����ͣ���Ӧ"Э�����б�"�±�
        /// </summary>
        public Int32 nProName;
        /// <summary>
        /// ��������ַ��0 - 255
        /// </summary>
        public Int32 nDecoderAddress;
        public CFG_COMM_PROP struComm;
        /// <summary>
        /// �����
        /// </summary>
        public Int32 nMartixID;
        /// <summary>
        /// ��̨����0-���ݣ�������̨ 1-Զ��������̨
        /// </summary>
        public Int32 nPTZType;
        /// <summary>
        /// ����ͷID
        /// </summary>
        public Int32 nCamID;
    }   

    // ˮӡ����
    public struct CFG_WATERMARK_INFO 
    {
        /// <summary>
        /// ͨ����(0��ʼ)
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʹ�ܿ���
        /// </summary>
        public bool bEnable;
        /// <summary>
        /// ��������(1��n)��0����������
        /// </summary>
        public Int32 nStreamType;
        /// <summary>
        /// �������ͣ�1�����֣�2��ͼƬ
        /// </summary>
        public Int32 nDataType;
        /// <summary>
        /// �ַ���ˮӡ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] pData;
    } 

    // ÿ����Ƶ����ͨ����Ӧ����Ƶ������Դ������Ϣ
    public struct CFG_ANALYSESOURCE_INFO
    {
        /// <summary>
        /// ��Ƶ����ʹ��
        /// </summary>
	    public byte bEnable;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ���ܷ�����ǰ����Ƶͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ���ܷ�����ǰ����Ƶ�������ͣ�0:ץͼ����; 1:������; 2:������1; 3:������2; 4:������3; 5:������
        /// </summary>
	    public Int32 nStreamType;
        /// <summary>
        /// �豸��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRemoteDevice;
    	
    } 

    public struct CFG_RAINBRUSH_INFO
    {
        /// <summary>
        /// ��ˢʹ��
        /// </summary>
	    public byte bEnable;
        /// <summary>
        /// ��ˢ�ٶ�,1:����;2:����;3:����
        /// </summary>
	    public byte bSpeedRate;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[] bReserved;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;

    }

    // BreakingSnapTimes
    public struct BREAKINGSNAPTIMES_INFO
    {
        /// <summary>
        /// ����
        /// </summary>
	    Int32 nNormal;
        /// <summary>
        /// �����
        /// </summary>
	    Int32 nRunRedLight;
        /// <summary>
        /// ѹ��
        /// </summary>
	    Int32 nOverLine;
        /// <summary>
        /// ѹ����
        /// </summary>
	    Int32 nOverYellowLine;
        /// <summary>
        /// ����
        /// </summary>
	    Int32 nRetrograde;
        /// <summary>
        /// Ƿ��
        /// </summary>
	    Int32 nUnderSpeed;
        /// <summary>
        /// ����
        /// </summary>
        Int32 nOverSpeed;
        /// <summary>
        /// �г�ռ��
        /// </summary>
	    Int32 nWrongRunningRoute;
        /// <summary>
        /// ����ռ��
        /// </summary>
	    Int32 nYellowInRoute;
        /// <summary>
        /// ��������
        /// </summary>
	    Int32 nSpecialRetrograde;
        /// <summary>
        /// Υ����ת
        /// </summary>
	    Int32 nTurnLeft;
        /// <summary>
        /// Υ����ת
        /// </summary>
	    Int32 nTurnRight;
        /// <summary>
        /// Υ�±��
        /// </summary>
	    Int32 nCrossLane;
        /// <summary>
        /// Υ�µ�ͷ
        /// </summary>
	    Int32 nU_Turn;
        /// <summary>
        /// Υ��ͣ��
        /// </summary>
	    Int32 nParking;
        /// <summary>
        /// Υ�½��������
        /// </summary>
	    Int32 nWaitingArea;
        /// <summary>
        /// ����������ʻ
        /// </summary>
	    Int32 nWrongRoute;
    }

    public struct COILCONFIG_INFO
    {
        /// <summary>
        /// ��ʱ��������	ÿ����Ȧ��Ӧ����ʱ���ص���ţ���Χ0~5��0��ʾ����ʱ�κ������
        /// </summary>
	    public Int32 nDelayFlashID;
        /// <summary>
        /// ��������	��Χ0~5��0��ʾ��������ƣ�۴����Ŀ�ã�
        /// </summary>
        public Int32 nFlashSerialNum;
        /// <summary>
        /// ��Ʒ���	ÿ����Ȧ��Ӧ�ĺ�Ʒ���0-������,1-��ת���,2-ֱ�к��,3-��ת���,4-����,5-��ֱ,6-����, ֻ�ڵ羯����Ч
        /// </summary>
        public Int32 nRedDirection;
        /// <summary>
        /// ��Ȧ����ģʽ	����ģʽ��0-����Ȧ����1-����Ȧ������۴����Ŀ�ã�
        /// </summary>
        public Int32 nTriggerMode;
    }

    public struct DETECTOR_INFO
    {
        /// <summary>
        /// Υ����������	�ӵ�λ����λ�����ǣ�0-����1-�����2-ѹ��3-����4-Ƿ��5-����6-�г�ռ��7-����ռ��
        /// </summary>
	    public Int32 nDetectBreaking;
        /// <summary>
        /// ��Ȧ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public COILCONFIG_INFO[]    arstCoilCfg;
        /// <summary>
        /// ������	0-16 
        /// </summary>
	    public Int32 nRoadwayNumber;
        /// <summary>
        /// �������򣨳������ķ���	0-���� 1-�����򶫱� 2-�� 3-�������� 
        /// 4-������ 5-���������� 6-������ 7-���������� 8-����
        /// </summary>
	    public Int32 nRoadwayDirection;
        /// <summary>
        /// ����ͼƬ���	��ʾ���羯�е�ĳһ��ͼƬ��Ϊ����ͼƬ�������ţ���
        /// 0��ʾ�����ã�1~3,��ʾ���ö�Ӧ��ŵ�ͼƬ
        /// </summary>
	    public Int32 nRedLightCardNum;
        /// <summary>
        /// ��Ȧ����	1-3
        /// </summary>
	    public Int32 nCoilsNumber;
        /// <summary>
        /// ҵ��ģʽ	0-���ڵ羯1-�羯2-����
        /// </summary>
	    public Int32 nOperationType;
        /// <summary>
        /// ������Ȧ�ļ��	��Χ0-1000����λΪ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public Int32[] arnCoilsDistance;
        /// <summary>
        /// ÿ����Ȧ�Ŀ��	0~200cm
        /// </summary>
	    public Int32 nCoilsWidth;
        /// <summary>
        /// С�ͳ����ٶ����޺�����	0~255km/h�������ô�С������ʱ��Ϊ��ͨ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public Int32[] arnSmallCarSpeedLimit;
        /// <summary>
        /// ���ͳ����ٶ����޺�����	0~255km/h�����ô�С������ʱ��Ч
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public Int32[] arnBigCarSpeedLimit;
        /// <summary>
        /// �޸��ٿ���ֵ	��λ��km/h
        /// </summary>
	    public Int32 nOverSpeedMargin;
        /// <summary>
        /// ���޸��ٿ���ֵ	��λ��km/h�����ô�С������ʱ��Ч
        /// </summary>
	    public Int32 nBigCarOverSpeedMargin;
        /// <summary>
        /// �޵��ٿ���ֵ	��λ��km/h
        /// </summary>
	    public Int32 nUnderSpeedMargin;
        /// <summary>
        /// ���޵��ٿ���ֵ	��λ��km/h�����ô�С������ʱ��Ч
        /// </summary>
	    public Int32 nBigCarUnderSpeedMargin;
        /// <summary>
        /// �Ƿ����ô�С������
        /// </summary>
	    public byte bSpeedLimitForSize;
        /// <summary>
        /// �����Ƿ���ΪΥ����Ϊ
        /// </summary>
	    public byte bMaskRetrograde;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[] byReserved;
        /// <summary>
        /// "DrivingDirection" : ["Approach", "�Ϻ�", "����"],��ʻ����
        /// "Approach"-���У����������豸�����Խ��Խ����"Leave"-���У�
        /// ���������豸�����Խ��ԽԶ���ڶ��͵����������ֱ�������к�
        /// ���е������ص㣬UTF-8����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
        public byte[] szDrivingDirection;
        /// <summary>
        /// ���ٰٷֱȣ��������ٰٷֱȺ�ץ��
        /// </summary>
	    public Int32 nOverPercentage; 
     
    }

    public struct CFG_TRAFFICSNAPSHOT_INFO
    {
        /// <summary>
        /// �豸��ַ	UTF-8���룬256�ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szDeviceAddress;
        /// <summary>
        /// OSD������������	�ӵ�λ����λ�ֱ��ʾ��0-ʱ�� 1-�ص� 2-����3-���� 4-���� 5-����
        /// 6-������ 7-С������8-���� 9-Υ������10-������ 
        /// 11-������ɫ 12-�������� 13-������ɫ14-��Ƶ���ʱ�� 15-Υ������ 
        /// 16-�״﷽�� 17-�豸��� 18-�궨����ʱ�� 19-���� 20-��ʻ����
        /// </summary>
	    public Int32 nVideoTitleMask;
        /// <summary>
        /// ���������ʱ��	��ƿ�ʼ��һ��ʱ���ڣ�����ͨ�в��㴳��ƣ���λ����
        /// </summary>
	    public Int32 nRedLightMargin;
        /// <summary>
        /// ������������С��ֵ	��λ���ף�����
        /// </summary>
	    public float fLongVehicleLengthLevel;
        /// <summary>
        /// �󳵳�����ֵ	��λ���ף�����Сֵ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public float[] arfLargeVehicleLengthLevel;
        /// <summary>
        /// ���ͳ�������ֵ	��λ���ף�����Сֵ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public float[] arfMediumVehicleLengthLevel;
        /// <summary>
        /// С��������ֵ	��λ���ף�����Сֵ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public float[] arfSmallVehicleLengthLevel;
        /// <summary>
        /// Ħ�г����������ֵ	��λ���ף�������
        /// </summary>
	    public float fMotoVehicleLengthLevel;
        /// <summary>
        /// Υ��ץ������
        /// </summary>
	    public BREAKINGSNAPTIMES_INFO   stBreakingSnapTimes;
        /// <summary>
        /// ���������ã�ǰ�������ڷſ��ڵ�3����Ȧ���������ŵ羯��3����Ȧ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	    public DETECTOR_INFO[] arstDetector;
        /// <summary>
        /// ץ�ĳ�������	0-��С����ץ��1-ץ��С��2-ץ�Ĵ�3-��С������ץ��
        /// </summary>
	    public Int32 nCarType;
        /// <summary>
        /// ����õ��ٶȳ�������ٶ�ʱ����������ٶȼ�	0~255km/h
        /// </summary>
	    public Int32 nMaxSpeed;
        /// <summary>
        /// ֡���ģʽ	1-�ٶ�����Ӧ�������ٶ�����ȡ0����������ٶ�����ȡ2������м�ȡ1�����2-��������������
        /// </summary>
	    public Int32 nFrameMode;
        /// <summary>
        /// �ٶ�����Ӧ���޺����� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public Int32[] arnAdaptiveSpeed;
        /// <summary>
        /// ��ͨץ����������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE     stuEventHandler;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 768)]
	    public byte[] bReserved;
    }


    public struct CFG_OVERSPEED_INFO
    {
        /// <summary>
        /// ���ٰٷֱ�����Ҫ�����䲻���ص�����ЧֵΪ0,����,-1��-1��ʾ�����ֵ
        /// �����Ƿ�٣�Ҫ�����䲻���ص�����ЧֵΪ0,����,-1��
        /// -1��ʾ�����ֵ��Ƿ�ٰٷֱȵļ��㷽ʽ���޵���-ʵ�ʳ���/�޵���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public Int32[] nSpeedingPercentage;
        /// <summary>
        /// Υ�´���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szCode;
        /// <summary>
        /// Υ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDescription; 

    }

    public struct CFG_UNDERSPEED_INFO
    {
        /// <summary>
        /// ���ٰٷֱ�����Ҫ�����䲻���ص�����ЧֵΪ0,����,-1��-1��ʾ�����ֵ
        /// �����Ƿ�٣�Ҫ�����䲻���ص�����ЧֵΪ0,����,-1��
        /// -1��ʾ�����ֵ��Ƿ�ٰٷֱȵļ��㷽ʽ���޵���-ʵ�ʳ���/�޵���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public Int32[] nSpeedingPercentage;
        /// <summary>
        /// Υ�´���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szCode;
        /// <summary>
        /// Υ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDescription; 

    }

    public struct CFG_OVERSPEED_HIGHWAY_INFO
    {
        /// <summary>
        /// ���ٰٷֱ�����Ҫ�����䲻���ص�����ЧֵΪ0,����,-1��-1��ʾ�����ֵ
        /// �����Ƿ�٣�Ҫ�����䲻���ص�����ЧֵΪ0,����,-1��
        /// -1��ʾ�����ֵ��Ƿ�ٰٷֱȵļ��㷽ʽ���޵���-ʵ�ʳ���/�޵���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public Int32[] nSpeedingPercentage;
        /// <summary>
        /// Υ�´���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szCode;
        /// <summary>
        /// Υ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szDescription;

    }

    /// <summary>
    /// ViolationCode Υ�´������ñ�
    /// </summary>
    public struct VIOLATIONCODE_INFO
    {
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szRetrograde;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szRetrogradeDesc; 
        /// <summary>
        /// ����-���ٹ�·
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szRetrogradeHighway;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szRetrogradeHighwayDesc;
        /// <summary>
        /// �����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szRunRedLight;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szRunRedLightDesc;
        /// <summary>
        /// Υ�±��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szCrossLane;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szCrossLaneDesc;
        /// <summary>
        /// Υ����ת
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szTurnLeft;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szTurnLeftDesc;
        /// <summary>
        /// Υ����ת
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szTurnRight;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szTurnRightDesc;
        /// <summary>
        /// Υ�µ�ͷ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szU_Turn;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szU_TurnDesc;
        /// <summary>
        /// ��ͨӵ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szJam;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szJamDesc;
        /// <summary>
        /// Υ��ͣ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szParking;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szParkingDesc;

	    // ���� �� ���ٱ��� ֻ���ұ�����һ������
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szOverSpeed;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szOverSpeedDesc;
        /// <summary>
        /// ���ٱ�������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	    public CFG_OVERSPEED_INFO[]  stOverSpeedConfig;

	    // ����(���ٹ�·) �� ���ٱ���(���ٹ�·) ֻ���ұ�����һ������
        /// <summary>
        /// ����-���ٹ�·
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szOverSpeedHighway;
        /// <summary>
        /// ����-Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szOverSpeedHighwayDesc;
        /// <summary>
        /// ���ٱ�������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	    public CFG_OVERSPEED_HIGHWAY_INFO[] stOverSpeedHighwayConfig;

	    // Ƿ�� �� Ƿ�ٱ��� ֻ���ұ�����һ������
        /// <summary>
        /// Ƿ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szUnderSpeed;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szUnderSpeedDesc;
        /// <summary>
        /// Ƿ��������Ϣ	��һ�����飬��ͬ��Ƿ�ٱ�Υ�´��벻ͬ��Ϊ�ձ�ʾΥ�´��벻���ֳ��ٱ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	    public CFG_UNDERSPEED_INFO[] stUnderSpeedConfig;
        /// <summary>
        /// ѹ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szOverLine;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szOverLineDesc;
        /// <summary>
        /// ѹ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szOverYellowLine;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szOverYellowLineDesc;
        /// <summary>
        /// ����ռ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szYellowInRoute;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szYellowInRouteDesc;
        /// <summary>
        /// ����������ʻ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szWrongRoute;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szWrongRouteDesc;
        /// <summary>
        /// ·����ʻ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szDrivingOnShoulder;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDrivingOnShoulderDesc;
        /// <summary>
        /// ������ʻ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szPassing;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szPassingDesc;
        /// <summary>
        /// ��ֹ��ʻ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szNoPassing;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szNoPassingDesc;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szFakePlate;
        /// <summary>
        /// Υ��������Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szFakePlateDesc;
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[] bReserved;
    }

    /// <summary>
    /// ��ͨȫ���������ñ�
    /// </summary>
    public struct CFG_TRAFFICGLOBAL_INFO
    {
        /// <summary>
        /// Υ�´������ñ�
        /// </summary>
	    public VIOLATIONCODE_INFO   stViolationCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[] bReserved;
    }


    // ��ͨ���� (CFG_CMD_DEV_GENERRAL) General 
    public struct CFG_DEV_DISPOSITION_INFO
    {
        /// <summary>
        /// ������ţ���Ҫ����ң�������ֲ�ͬ�豸	0~998
        /// </summary>
	    public Int32 nLocalNo;
        /// <summary>
        /// �������ƻ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szMachineName;
        /// <summary>
        /// ��������ص㼴��·����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szMachineAddress; 
        /// <summary>
        /// �����������豸������λ	Ĭ��Ϊ�գ��û����Խ���ͬ���豸��Ϊһ�飬���ڹ������ظ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szMachineGroup;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[] bReserved; 
    }

    public struct CFG_ATMMOTION_INFO
    {
	    public Int32 nTimeLimit;
    }

    // �豸״̬��Ϣ
    public struct CFG_DEVICESTATUS_INFO
    {
        /// <summary>
        /// ��Դ����
        /// </summary>
	    public Int32 nPowerNum;
        /// <summary>
        /// ��Դ״̬��1:���� 2:�쳣 3:δ֪
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] byPowerStatus;
        /// <summary>
        /// CPU����
        /// </summary>
        public Int32 nCPUNum;
        /// <summary>
        /// CPU�¶�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] nCPUTemperature;
        /// <summary>
        /// ���ȸ���
        /// </summary>
        public Int32 nFanNum;
        /// <summary>
        /// ����ת��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Int32[] nRotatoSpeed;
    }

    // ��չ����Ϣ
    public struct CFG_HARDDISK_INFO 
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannel;
        /// <summary>
        /// Ӳ������
        /// </summary>
	    public Int32 nCapacity;
        /// <summary>
        /// Ӳ��״̬��0:unknown 1:running 2:fail
        /// </summary>
	    public byte byStatus;
        /// <summary>
        /// ʹ��״̬��1.���� 2.���� 3.δ֪
        /// </summary>
	    public byte byUsedStatus;
        /// <summary>
        /// �Ƿ����ȱ��̣�0:�ȱ��� 1:���ȱ���
        /// </summary>
        public byte byHotBack;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
	    public byte byReserved;
        /// <summary>
        /// ����Raid(������)������	"RaidName" : "Raid0",
        /// ����Raid(������)�����ơ��粻�����κ�Raid�����ֶ�Ϊnull��
        /// �����ȱ��̣�����ȫ���ȱ��̵ģ���null�� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRaidName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szType;                      // Ӳ���ͺ�
	    public Int32 nTank;                           // ��չ��, 0:����;1:��չ��1; 2:��չ��2	����
	    public Int32 nRemainSpace;					 // ʣ����������λM
    }

    public struct CFG_HARDDISKTANK_INFO
    {
        /// <summary>
        /// �洢������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szTankName;
        /// <summary>
        /// Ӳ�̸���
        /// </summary>
        public Int32 nHardDiskNum;
        /// <summary>
        /// Ӳ����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public CFG_HARDDISK_INFO[] stuHarddiskInfo;
    }

    public struct CFG_HARDISKTANKGROUP_INFO
    {
        /// <summary>
        /// Ӳ�̴洢�����
        /// </summary>
	    public Int32  nTankNum;
        /// <summary>
        /// Ӳ�̴洢������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public CFG_HARDDISKTANK_INFO[]    stuHarddisktank;
    }

    // Raid����Ϣ
    public struct CFG_RAID_INFO
    {
        /// <summary>
        /// Raid����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRaidName;
        /// <summary>
        /// ���� 1:Jbob, 2:Raid0, 3:Raid1, 4:Raid5
        /// </summary>
	    public byte byType;
        /// <summary>
        /// ״̬  0:unknown, 1:active, 2:degraded, 3:inactive, 4:recovering ͬ����
        /// </summary>
	    public byte byStatus;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[] byReserved;
        /// <summary>
        /// ��ɴ���ͨ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public Int32[] nMember;
        /// <summary>
        /// ���̸���
        /// </summary>
        public Int32 nDiskNUM;
        /// <summary>
        /// ����
        /// </summary>
        public Int32 nCapacity;
        /// <summary>
        /// ��չ��
        /// </summary>
        public Int32 nTank;
        /// <summary>
        /// ʣ����������λM
        /// </summary>
        public Int32 nRemainSpace;
    }

    public struct CFG_RAIDGROUP_INFO
    {
        /// <summary>
        /// Raid����
        /// </summary>
	    public Int32 nRaidNum;
        /// <summary>
        /// Raid����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public CFG_RAID_INFO[] stuRaidInfo;
    }

    // �洢������Ϣ
    public struct CFG_STORAGEPOOL_INFO
    {
        /// <summary>
        /// �洢������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szName;
        /// <summary>
        /// �豸����
        /// </summary>
        public Int32 nMemberNum;
        /// <summary>
        /// ����豸
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
        public byte[] szMember;
        /// <summary>
        /// ��������
        /// </summary>
        public Int32 nUsed;
        /// <summary>
        /// ������
        /// </summary>
        public Int32 nCapacity;
        /// <summary>
        /// ״̬	0:unknown 1:active 2:degraded 3:inactive
        /// </summary>
        public Int32 nStatus;
        /// <summary>
        /// ��չ��	0:����, 1:��չ��1, 2:��չ��2 ����
        /// </summary>
        public Int32 nTank;
    }

    public struct CFG_STORAGEPOOLGROUP_INFO
    {
        /// <summary>
        /// �洢�ظ���
        /// </summary>
	    public Int32 nStroagePoolNum; 
        /// <summary>
        /// �洢����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public CFG_STORAGEPOOL_INFO[] stuStoragePoolInfo;
    }


    // �ļ�ϵͳ����Ϣ
    public struct CFG_STORAGEPOSITION_INFO
    {
        /// <summary>
        /// �洢λ������	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szName;
        /// <summary>
        /// �洢������	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szStoragePoolName;
        /// <summary>
        /// ��������,��λG	
        /// </summary>
        public Int32 nUsedCapacity;
        /// <summary>
        /// ����,��λG	
        /// </summary>
        public Int32 nTotalCapacity;
        /// <summary>
        /// ״̬ 0.δ֪ 1.���� 2.�����쳣 3.�����쳣
        /// </summary>
	    public byte byStatus;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
    }

    public struct CFG_STORAGEPOSITIONGROUP_INFO
    {
        /// <summary>
        /// �洢��Ϣ����
        /// </summary>
	    public Int32 nStoragePositionNum;
        /// <summary>
        /// �ļ�ϵͳ����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public CFG_STORAGEPOSITION_INFO[] stuStoragePositionInfo;      
    }

    // ǰ���豸����Ϣ
    public struct CFG_VIDEOINDEV_INFO
    {
        /// <summary>
        /// ǰ���豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szDevName; 
        /// <summary>
        /// �豸ID	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szDevID;
        /// <summary>
        /// �豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szDevType;
        /// <summary>
        /// ��ͨ����
        /// </summary>
        public Int32 nTotalChan;
        /// <summary>
        /// ����ͨ������
        /// </summary>
	    public Int32 nTotalAlarmChan;
        /// <summary>
        /// �豸IP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szIP;
        /// <summary>
        /// ״̬ 0:δ֪ 1:���� 2:����
        /// </summary>
	    public byte byStatus;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byReserved;
    }

    public  struct CFG_VIDEOINDEVGROUP_INFO
    {
        /// <summary>
        /// ǰ���豸����
        /// </summary>
	    public Int32 nVideoDevNum; 
        /// <summary>
        /// ǰ���豸����Ϣ      
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public CFG_VIDEOINDEV_INFO[] stuVideoInDevInfo;
    }

    // ͨ��¼����״̬
    public struct CFG_DEVRECORD_INFO
    {
        /// <summary>
        /// �豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szDevName;
        /// <summary>
        /// �豸IP	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szIP;
        /// <summary>
        /// ͨ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szChannel;
        /// <summary>
        /// ͨ������	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szChannelName;
        /// <summary>
        /// �洢λ����Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szStoragePosition;
        /// <summary>
        /// ״̬ 0:δ֪ 1:¼�� 2:ֹͣ
        /// </summary>
	    public byte byStatus;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
    }

    public  struct CFG_DEVRECORDGROUP_INFO
    {
        /// <summary>
        /// ͨ������
        /// </summary>
	    public Int32 nChannelNum;
        /// <summary>
        /// ͨ��¼��״̬��Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public CFG_DEVRECORD_INFO[] stuDevRecordInfo;
    }

    // ����״̬
    public struct CFG_IPSERVER_STATUS
    {
        /// <summary>
        /// �ṩ�ķ������
        /// </summary>
	    public Int32  nSupportedServerNum;
        /// <summary>
        /// �ṩ�ķ������� Svr Svrd(SVR�ػ�����) DataBase DataBased(DataBase�ػ�����) 
        /// NtpServer NtpServerd(NtpServer�ػ�����) DahuaII DahuaIId(DahuaII�ػ�����) Samba Nfs Ftp iScsi 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)] 
	    public byte[] szSupportServer; 
        /// <summary>
        /// Svr�ṩ���ӷ�����Ϣ����
        /// </summary>
	    public Int32  nSvrSuppSubServerNum;
        /// <summary>
        /// Svr�ṩ���ӷ�����Ϣ CMS DMS	MTS	SS RMS DBR
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szSvrSuppSubServer;
        /// <summary>
        /// 0:δ֪ 1:���� 2:δ����
        /// �����ֶζ��������˼
        /// </summary>
        public byte byCMS;
	    public byte byDMS;
	    public byte byMTS;
	    public byte bySS;
	    public byte byRMS;
	    public byte byDBR;
	    public byte bySvrd;
	    public byte byDataBase;
	    public byte byDataBased;
	    public byte byNtpServer;
	    public byte byNtpServerd;
	    public byte byDahuaII;
	    public byte byDahuaIId;
	    public byte bySAMBA;  
	    public byte byNFS;    
	    public byte byFTP;    
	    public byte byISCSI;  
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved; 
    }


    public struct SNAPSOURCE_INFO_SINGLE_CHANNEL
    {
        /// <summary>
        /// ʹ��
        /// </summary>
	    public byte		bEnable;
        /// <summary>
        /// �����ֶΣ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved1;
        /// <summary>
        /// �豸��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] bDevice;
        /// <summary>
        /// ��Ƶͨ���� 
        /// </summary>
	    public UInt32		dwChannel;
        /// <summary>
        /// ץͼͨ����Ӧ����Ƶͨ����
        /// </summary>
	    public UInt32		dwLinkVideoChannel;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	    public byte[]	bReserved;
    }

    public struct CFG_SNAPSOURCE_INFO
    {
        /// <summary>
        /// Ҫ���õ�ͨ���ĸ���
        /// </summary>
	    public UInt32 dwCount;
        /// <summary>
        /// SNAPSOURCE_INFO_SINGLE_CHANNEL����ĵ�ַ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public SNAPSOURCE_INFO_SINGLE_CHANNEL[] singleChnSanpInfo;
    }


    // ��Ѳģʽ
    public struct CFG_TOUR_MODE
    {
        /// <summary>
        /// ����ָ�ģʽ,�ο�ö������MATRIX_VIEW_SPLITMODE
        /// </summary>
	    public Int32 nViewMode;
        /// <summary>
        /// ��ʾViewMod����:0x00000007:��ʾģʽ3(SPLIT8)�ķָ�1,2,3ʹ�ܿ���,����δʹ��,
        /// 0x0000000F��ʾ�ָ�1,2,3,4ʹ��eָ��ģʽ��,ʹ�ܵļ����ָ�����,ʹ�������﷽ʽ
        /// </summary>
	    public UInt32 dwViewSplitMask;
    }

    // SPOT��Ƶ���󷽰�
    public  struct CFG_VIDEO_MATRIX_PLAN
    {
        /// <summary>
        /// �������÷���ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ������Ѳ���,��λ��,>=1
        /// </summary>
	    public Int32 nTourPeriod;
        /// <summary>
        /// ��Ѳ���и���
        /// </summary>
	    public Int32 nTourModeNum;
        /// <summary>
        /// ��Ѳ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public CFG_TOUR_MODE[]   stuTourMode;
    }

    // SPOT��������
    public  struct CFG_VIDEO_MATRIX
    {
        /// <summary>
        /// ֧�ֵĻ���ָ��������
        /// </summary>
	    public Int32 nSupportSplitModeNumber;
        /// <summary>
        /// ֧�ֵĻ���ָ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] bySupportSplitMode;
        /// <summary>
        /// ���󷽰���
        /// </summary>
	    public Int32 nMatrixPlanNumber;
        /// <summary>
        /// ���󷽰�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public CFG_VIDEO_MATRIX_PLAN[] stuMatrixPlan;
    }


    // dsp����
    public struct CFG_DSPENCODECAP_INFO
    {
        /// <summary>
        /// ��Ƶ��ʽ���룬��λ��ʾ�豸�ܹ�֧�ֵ���Ƶ��ʽ
        /// </summary>
	    public UInt32 dwVideoStandardMask;
        /// <summary>
        /// �ֱ������룬��λ��ʾ�豸�ܹ�֧�ֵķֱ���
        /// </summary>
	    public UInt32 dwImageSizeMask;
        /// <summary>
        /// ����ģʽ���룬��λ��ʾ�豸�ܹ�֧�ֵı���ģʽ
        /// </summary>
	    public UInt32 dwEncodeModeMask;
        /// <summary>
        /// ��λ��ʾ�豸֧�ֵĶ�ý�幦�ܣ�
        /// ��һλ��ʾ֧��������
        /// �ڶ�λ��ʾ֧�ָ�����1
        /// ����λ��ʾ֧�ָ�����2
        /// ����λ��ʾ֧��jpgץͼ
        /// </summary>
	    public UInt32 dwStreamCap;
        /// <summary>
        /// ��ʾ������Ϊ���ֱ���ʱ��֧�ֵĸ������ֱ������롣
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public UInt32[] dwImageSizeMask_Assi;
        /// <summary>
        /// DSP֧�ֵ���߱�������
        /// </summary>
	    public UInt32 dwMaxEncodePower;
        /// <summary>
        /// ÿ��DSP֧�����������Ƶͨ���� 
        /// </summary>
	    public UInt16 wMaxSupportChannel;
        /// <summary>
        /// DSPÿͨ���������������Ƿ�ͬ����0����ͬ����1��ͬ��
        /// </summary>
	    public UInt16 wChannelMaxSetSync;
        /// <summary>
        /// ��ͬ�ֱ����µ����ɼ�֡�ʣ���dwVideoStandardMask��λ��Ӧ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] bMaxFrameOfImageSize;
        /// <summary>
        /// ��־������ʱҪ����������������������ò�����Ч��
        /// 0���������ı�������+�������ı������� <= �豸�ı���������
        /// 1���������ı�������+�������ı������� <= �豸�ı���������
        /// �������ı������� <= �������ı���������
        /// �������ķֱ��� <= �������ķֱ��ʣ�
        /// �������͸�������֡�� <= ǰ����Ƶ�ɼ�֡��
        /// 2��N5�ļ��㷽��
        /// �������ķֱ��� <= �������ķֱ���
        /// ��ѯ֧�ֵķֱ��ʺ���Ӧ���֡��
        /// </summary>
	    public byte bEncodeCap;
        /// <summary>
        /// bResolution�ĳ���
        /// </summary>
	    public byte byResolutionNum;
        /// <summary>
        /// bResolution_1�ĳ���
        /// </summary>
	    public byte byResolutionNum_1;
	    public byte byReserved;
        /// <summary>
        /// ������,���շֱ��ʽ������������֧�ָ÷ֱ��ʣ���bResolution[n]����֧�ֵ����֡��.����Ϊ0.	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] byResolution;
        /// <summary>
        /// ��������1,ͬ������˵��.
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]			
	    public byte[] byResolution_1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]			
	    public byte[] reserved;
    }

    public  struct VIDEO_INMETERING_INFO_CHANNEL
    {
	    // ����
	    public  byte bRegion;
	    public  byte bMode;
        /// <summary>
        /// �����ֶ�1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public  byte[] bReserved1;
    	/// <summary>
    	/// ����������
    	/// </summary>
	    public  Int32 nRegionNum; 
        /// <summary>
        /// �������, �ֲ����ʹ�ã�֧�ֶ���������ʹ�����������ϵ��ȡֵ��Ϊ0~8191
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public  CFG_RECT[] stuRegions;
        /// <summary>
        /// ���ģʽ,0:ƽ�����,1:�ֲ����
        /// </summary>
	    public  byte byMode;
        /// <summary>
        /// �����ֶ�2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public  byte[] bReserved2;
        /// <summary>
        /// �����ֶ�3
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public  byte[] bReserved3;
    }

    // �������(CFG_CMD_VIDEO_INMETERING)��һ�����飬ÿ����Ƶ����ͨ��һ������
    public struct CFG_VIDEO_INMETERING_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public  Int32 nChannelNum;
        /// <summary>
        /// ÿ��ͨ���Ĳ����Ϣ���±��Ӧͨ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public  VIDEO_INMETERING_INFO_CHANNEL[]	stuMeteringMode;
    }


    // ����ͳ�Ʊ�����Ϣ����
    public struct CFG_TRAFFIC_FLOWSTAT_ALARM_INFO
    {
        /// <summary>
        /// �Ƿ�ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ͳ�����ڣ���λ������
        /// </summary>
	    public int nPeriod;
        /// <summary>
        /// ͳ�������ڳ����������ޣ���λ����
        /// </summary>
	    public int nLimit;
        /// <summary>
        /// ͳ�������ڱ����ָ�����������λ���� 
        /// </summary>
	    public int nRestore;
        /// <summary>
        /// ��⵽������������ʼ�ϱ���ʱ��, ��λ:��,��Χ1~65535
        /// </summary>
        public int nDelay;
        /// <summary>
        /// �������ʱ��, ��λ:��, ��Χ1~65535
        /// </summary>
	    public int nInterval;
        /// <summary>
        /// �ϱ�����,1~255
        /// </summary>
	    public int nReportTimes;
        /// <summary>
        /// ��ǰ�ƻ�ʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[] stCurrentTimeSection;
    }

    public struct CFG_TRAFFIC_FLOWSTAT_INFO_LANE
    {
	    // ����
	    public byte abEnable;
        /// <summary>
        /// �Ƿ�ʹ��
        /// </summary>
	    public byte bEnable;
        /// <summary>
        /// �������߲���
        /// </summary>
	    public CFG_TRAFFIC_FLOWSTAT_ALARM_INFO  stuAlarmUpperInfo;
        /// <summary>
        /// �������߲���
        /// </summary>
	    public CFG_TRAFFIC_FLOWSTAT_ALARM_INFO  stuAlarmLowInfo; 
    }


    // ��Ƶ����ҹ����������ѡ������Ϲ��߽ϰ�ʱ�Զ��л���ҹ������ò���
    public struct CFG_VIDEO_IN_NIGHT_OPTIONS
    {
        /// <summary>
        /// 0-���л���1-���������л���2-����ʱ���л�
        /// </summary>
	    public byte bySwitchMode;
        /// <summary>
        /// ������ֵ 0~100	
        /// </summary>
	    public byte byBrightnessThreshold ;
        /// <summary>
        /// �����ճ�������ʱ�䣬����֮���ճ�֮ǰ��������ҹ����������á�
        /// </summary>
	    public byte bySunriseHour;
        /// <summary>
        /// 00:00:00 ~ 23:59:59
        /// </summary>
	    public byte bySunriseMinute;
	    public byte bySunriseSecond;
	    public byte bySunsetHour;
	    public byte bySunsetMinute;
	    public byte bySunsetSecond;  
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainRed;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainBlue;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainGreen;
        /// <summary>
        /// �ع�ģʽ��ȡֵ��Χȡ�����豸��������0-�Զ��ع⣬1-�ع�ȼ�1��
        /// 2-�ع�ȼ�2��n-1����ع�ȼ��� n��ʱ�������޵��Զ��ع� n+1�Զ���ʱ���ֶ��ع� (n==byExposureEn��
        /// </summary>
	    public byte byExposure;
        /// <summary>
        /// �Զ��ع�ʱ�����޻����ֶ��ع��Զ���ʱ��,����Ϊ��λ��ȡֵ0.1ms~80ms
        /// </summary>
	    public float fExposureValue1;
        /// <summary>
        /// �Զ��ع�ʱ������,����Ϊ��λ��ȡֵ0.1ms~80ms	
        /// </summary>
	    public float fExposureValue2;
        /// <summary>
        /// ��ƽ��, 0-"Disable", 1-"Auto", 2-"Custom", 3-"Sunny", 4-"Cloudy", 5-"Home",
        /// 6-"Office", 7-"Night", 8-"HighColorTemperature", 9-"LowColorTemperature", 10-"AutoColorTemperature", 
        /// 11-"CustomColorTemperature"
        /// </summary>
	    public byte byWhiteBalance ;
        /// <summary>
        /// 0~100, GainAutoΪtrueʱ��ʾ�Զ���������ޣ������ʾ�̶�������ֵ
        /// </summary>
	    public byte byGain;
        /// <summary>
        /// �Զ�����
        /// </summary>
	    public byte bGainAuto;
        /// <summary>
        /// �Զ���Ȧ
        /// </summary>
	    public byte bIrisAuto;
        /// <summary>
        /// ��ͬ������λ���� 0~360
        /// </summary>
	    public float fExternalSyncPhase;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	    public byte[] reserved; 
    } 


    // ���������
    public struct CFG_FLASH_CONTROL
    {
        /// <summary>
        /// ����ģʽ��0-��ֹ���⣬1-ʼ�����⣬2-�Զ�����
        /// </summary>
	    public byte byMode;
        /// <summary>
        /// ����ֵ, 0-0us, 1-64us, 2-128us, 3-192...15-960us
        /// </summary>
	    public byte byValue;
        /// <summary>
        /// ����ģʽ, 0-�͵�ƽ 1-�ߵ�ƽ 2-������ 3-�½���
        /// </summary>
	    public byte byPole;
        /// <summary>
        /// ����Ԥ��ֵ  ����0~100
        /// </summary>
	    public byte byPreValue;
        /// <summary>
        /// ռ�ձ�, 0~100
        /// </summary>
	    public byte byDutyCycle;
        /// <summary>
        /// ��Ƶ, 0~10
        /// </summary>
	    public byte byFreqMultiple;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 122)]
	    public byte[] reserved;
    }

        // ץ�Ĳ�����������
    public struct CFG_VIDEO_IN_SNAPSHOT_OPTIONS
    {
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainRed;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainBlue;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainGreen;
        /// <summary>
        /// �ع�ģʽ��ȡֵ��Χȡ�����豸��������0-�Զ��ع⣬1-�ع�ȼ�1��
        /// 2-�ع�ȼ�2��n-1����ع�ȼ��� n��ʱ�������޵��Զ��ع� n+1�Զ���ʱ���ֶ��ع� (n==byExposureEn��
        /// </summary>
	    public byte byExposure;
        /// <summary>
        /// �Զ��ع�ʱ�����޻����ֶ��ع��Զ���ʱ��,����Ϊ��λ��ȡֵ0.1ms~80ms
        /// </summary>
	    public float fExposureValue1;
        /// <summary>
        /// �Զ��ع�ʱ������,����Ϊ��λ��ȡֵ0.1ms~80ms	
        /// </summary>
	    public float fExposureValue2;
        /// <summary>
        /// ��ƽ��, 0-"Disable", 1-"Auto", 2-"Custom", 3-"Sunny", 4-"Cloudy",
        /// 5-"Home", 6-"Office", 7-"Night", 8-"HighColorTemperature", 9-"LowColorTemperature", 
        /// 10-"AutoColorTemperature", 11-"CustomColorTemperature"
        /// </summary>
	    public byte byWhiteBalance;
        /// <summary>
        /// ɫ�µȼ�, ��ƽ��Ϊ"CustomColorTemperature"ģʽ����Ч
        /// </summary>
	    public byte byColorTemperature;
        /// <summary>
        /// �Զ�����
        /// </summary>
	    public byte bGainAuto;
        /// <summary>
        /// �������, GainAutoΪtrueʱ��ʾ�Զ���������ޣ������ʾ�̶�������ֵ
        /// </summary>
	    public byte byGain;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
	    public byte[] reversed;
    } 

    // ��Ƶ����ǰ��ѡ��
    public struct CFG_VIDEO_IN_OPTIONS
    {
        /// <summary>
        /// ���ⲹ�������ⲹ���ȼ�ȡֵ��Χȡ�����豸��������0-�رգ�1-���ⲹ��ǿ��1��
        /// 2-���ⲹ��ǿ��2��n-��󱳹ⲹ���ȼ���
        /// </summary>
	    public byte byBacklight;
        /// <summary>
        /// ��/ҹģʽ��0-���ǲ�ɫ��1-���������Զ��л���2-���Ǻڰ�
        /// </summary>
	    public byte byDayNightColor;
        /// <summary>
        /// ��ƽ��, 0-"Disable", 1-"Auto", 2-"Custom", 3-"Sunny", 4-"Cloudy", 5-"Home",
        /// 6-"Office", 7-"Night", 8-"HighColorTemperature", 9-"LowColorTemperature",
        /// 10-"AutoColorTemperature", 11-"CustomColorTemperature"
        /// </summary>
	    public byte byWhiteBalance;
        /// <summary>
        /// ɫ�µȼ�, ��ƽ��Ϊ"CustomColorTemperature"ģʽ����Ч
        /// </summary>
	    public byte byColorTemperature;
        /// <summary>
        /// ����
        /// </summary>
	    public byte bMirror;
        /// <summary>
        /// ��ת
        /// </summary>
	    public byte bFlip;
        /// <summary>
        /// �Զ���Ȧ
        /// </summary>
	    public byte bIrisAuto;
        /// <summary>
        /// ���ݻ������Զ��������ⲹ����	
        /// </summary>
	    public byte bInfraRed;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainRed;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainBlue;
        /// <summary>
        /// ��ɫ������ڣ���ƽ��Ϊ"Custom"ģʽ����Ч 0~100
        /// </summary>
	    public byte byGainGreen;
        /// <summary>
        /// �ع�ģʽ��ȡֵ��Χȡ�����豸��������0-�Զ��ع⣬1-�ع�ȼ�1��
        /// 2-�ع�ȼ�2��n-1����ع�ȼ��� n��ʱ�������޵��Զ��ع� n+1�Զ���ʱ���ֶ��ع� (n==byExposureEn��
        /// </summary>
	    public byte byExposure;
        /// <summary>
        /// �Զ��ع�ʱ�����޻����ֶ��ع��Զ���ʱ��,����Ϊ��λ��ȡֵ0.1ms~80ms
        /// </summary>
	    public float fExposureValue1;
        /// <summary>
        /// �Զ��ع�ʱ������,����Ϊ��λ��ȡֵ0.1ms~80ms	
        /// </summary>
	    public float fExposureValue2;
        /// <summary>
        /// �Զ�����
        /// </summary>
	    public byte bGainAuto;
        /// <summary>
        /// �������, GainAutoΪtrueʱ��ʾ�Զ���������ޣ������ʾ�̶�������ֵ
        /// </summary>
	    public byte byGain;
        /// <summary>
        /// �źŸ�ʽ, 0-Inside(�ڲ�����) 1-BT656 2-720p 3-1080p  4-1080i  5-1080sF
        /// </summary>
	    public byte bySignalFormat;
        /// <summary>
        /// 0-����ת��1-˳ʱ��90�㣬2-��ʱ��90��	
        /// </summary>
	    public byte byRotate90;
        /// <summary>
        /// ��ͬ������λ���� 0~360	
        /// </summary>
	    public float fExternalSyncPhase;
        /// <summary>
        /// �ⲿͬ���ź�����,0-�ڲ�ͬ�� 1-�ⲿͬ��
        /// </summary>
	    public byte byExternalSync;
        /// <summary>
        /// ����
        /// </summary>
	    public byte reserved0;
        /// <summary>
        /// ˫����, 0-�����ã�1-˫����ȫ֡�ʣ���ͼ�����Ƶֻ�п��Ų�����ͬ��2-˫���Ű�֡�ʣ���ͼ�����Ƶ���ż���ƽ���������ͬ
        /// </summary>
	    public byte byDoubleExposure;
        /// <summary>
        /// ��ֵ̬
        /// </summary>
	    public byte byWideDynamicRange;
        /// <summary>
        /// ҹ�����
        /// </summary>
	    public CFG_VIDEO_IN_NIGHT_OPTIONS stuNightOptions;
        /// <summary>
        /// ���������
        /// </summary>
	    public CFG_FLASH_CONTROL	stuFlash;
        /// <summary>
        /// ץ�Ĳ���, ˫����ʱ��Ч
        /// </summary>
	    public CFG_VIDEO_IN_SNAPSHOT_OPTIONS stuSnapshot;
        /// <summary>
        /// ����
        /// </summary>
       /// [MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
	    public byte[] reserved;
    }

    public struct CFG_RTSP_INFO_IN
    {
	    Int32 nStructSize;
        /// <summary>
        /// ���������Ƿ�ʹ��
        /// </summary>
	    bool bEnable;
        /// <summary>
        /// RTSP����˿�
        /// </summary>
        Int32 nPort;
        /// <summary>
        /// RTP��ʼ�˿�
        /// </summary>
        Int32 nRtpStartPort;
        /// <summary>
        /// RTP�����˿�
        /// </summary>
        Int32 nRtpEndPort;
        /// <summary>
        /// RtspOverHttpʹ��
        /// </summary>
	    bool bHttpEnable;
        /// <summary>
        /// RtspOverHttp�˿�
        /// </summary>
        Int32 nHttpPort; 
    }

    public struct CFG_RTSP_INFO_OUT
    {
	    Int32 nStructSize;
        /// <summary>
        /// ���������Ƿ�ʹ��
        /// </summary>
	    bool bEnable; 
        /// <summary>
        /// RTSP����˿�
        /// </summary>
        Int32 nPort;
        /// <summary>
        /// RTP��ʼ�˿�
        /// </summary>
        Int32 nRtpStartPort;
        /// <summary>
        /// RTP�����˿�
        /// </summary>
        Int32 nRtpEndPort;
        /// <summary>
        /// RtspOverHttpʹ��
        /// </summary>
        bool bHttpEnable;
        /// <summary>
        /// RtspOverHttp�˿�
        /// </summary>
        Int32 nHttpPort;
    }

    public struct CFG_TRAFFICSNAPSHOT_NEW_INFO
    {
        /// <summary>
        /// ��Ч��Ա����
        /// </summary>
	    public Int32 nCount; 
        /// <summary>
        /// ��ͨץ�ı�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public CFG_TRAFFICSNAPSHOT_INFO[]	stInfo;
    }

    public struct CFG_MULTICASTS_INFO_IN
    {
	    public Int32 nStructSize;
        /// <summary>
        /// TS���鲥����
        /// CFG_MULTICAST_INFO*
        /// </summary>
        public IntPtr pTSMulticast;
        /// <summary>
        /// ��ЧTS�������
        /// </summary>
        public Int32 nTSCount;
        /// <summary>
        /// RTP���鲥����
        /// CFG_MULTICAST_INFO*
        /// </summary>
        public IntPtr pRTPMulticast;
        /// <summary>
        /// ��ЧRTP�������
        /// </summary>
        public Int32 nRTPCount;
    }

    // RTSP�������������������ýṹ��
    public struct CFG_MULTICAST_INFO
    {
	    public Int32  nStructSize;
	    public byte abStreamType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] byReserved;
        /// <summary>
        /// �Ƿ�ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// �鲥��ַ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szMulticastAddr;
        /// <summary>
        /// �鲥�˿�
        /// </summary>
	    public Int32  nPort;
        /// <summary>
        /// ������ַ�������鲥ָ����ϸ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szLocalAddr; 
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32  nChannelID;
        /// <summary>
        /// �������� 0-������, 1-������1,2-������2,3-������3
        /// </summary>
	    public Int32  nStreamType; 
    }

    public struct CFG_MULTICASTS_INFO
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����鲥����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public CFG_MULTICAST_INFO[] stuMultiInfo;
        /// <summary>
        /// ��Ч�������
        /// </summary>
	    public Int32 nCount;
    }

    public struct CFG_MULTICASTS_INFO_OUT
    {
	    public Int32                  nStructSize;
        /// <summary>
        /// TS���鲥����
        /// </summary>
	    public CFG_MULTICASTS_INFO  stuTSMulticast;
        /// <summary>
        /// RTP���鲥����
        /// </summary>
	    public CFG_MULTICASTS_INFO  stuRTPMulticast;
    }

    ///////////////////////////////////��Ƶ�������///////////////////////////////////////
    // ��Ƶ�������
    public struct CFG_VIDEO_DITHER_DETECTION
    {
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
    }

    // ���Ƽ��
    public struct CFG_VIDEO_STRIATION_DETECTION 
    {
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
        /// <summary>
        /// �ֽڶ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]   
	    public byte[] byReserved1;
        /// <summary>
        /// UV�����Ƿ���					
        /// </summary>
	    public bool bUVDetection;
    }

    // ��Ƶ��ʧ���
    public struct CFG_VIDEO_LOSS_DETECTION
    {
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
    }

    // ��Ƶ�ڵ����
    public struct CFG_VIDEO_COVER_DETECTION
    {
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
    }

    // ���涳����
    public struct CFG_VIDEO_FROZEN_DETECTION
    {
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
    }

    // �����쳣���
    public struct CFG_VIDEO_BRIGHTNESS_DETECTION
    {	
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte bylowerThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte bylowerThrehold2;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byUpperThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byUpperThrehold2;
    }

    // �Աȶ��쳣���
    public struct CFG_VIDEO_CONTRAST_DETECTION
    {	
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte bylowerThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte bylowerThrehold2;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byUpperThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byUpperThrehold2;
    }

    // ƫɫ���
    public struct CFG_VIDEO_UNBALANCE_DETECTION
    {	
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
    }

    // �������
    public struct CFG_VIDEO_NOISE_DETECTION
    {	
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
    }

    // ģ�����
    public struct CFG_VIDEO_BLUR_DETECTION
    {
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
    }

    // �����仯���
    public struct CFG_VIDEO_SCENECHANGE_DETECTION
    {	
        /// <summary>
        /// ʹ������
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��̳���ʱ�� ��λ���� 0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// Ԥ����ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold1;
        /// <summary>
        /// ������ֵ ȡֵ1-100
        /// </summary>
	    public byte byThrehold2;
    }

    public struct CFG_VIDEO_DIAGNOSIS_PROFILE
    {
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]     
	    public byte[] szName;

        /// <summary>
        /// ��Ƶ�������
        /// CFG_VIDEO_DITHER_DETECTION*
        /// </summary>
	    public IntPtr pstDither;
        /// <summary>
        /// ��Ƶ���Ƽ��
        /// CFG_VIDEO_STRIATION_DETECTION*
        /// </summary>
	    public IntPtr	pstStriation;
        /// <summary>
        /// ��Ƶ��ʧ���
        /// CFG_VIDEO_LOSS_DETECTION*
        /// </summary>
	    public IntPtr pstLoss;
        /// <summary>
        /// ��Ƶ�ڵ����
        /// CFG_VIDEO_COVER_DETECTION*
        /// </summary>
	    public IntPtr pstCover;
        /// <summary>
        /// ��Ƶ������
        /// CFG_VIDEO_FROZEN_DETECTION*
        /// </summary>
	    public IntPtr pstFrozen;
        /// <summary>
        /// ��Ƶ�����쳣���
        /// CFG_VIDEO_BRIGHTNESS_DETECTION*
        /// </summary>
	    public IntPtr pstBrightness;
        /// <summary>
        /// �Աȶ��쳣���
        /// CFG_VIDEO_CONTRAST_DETECTION*
        /// </summary>
	    public IntPtr pstContrast;
        /// <summary>
        /// ƫɫ�쳣���
        /// CFG_VIDEO_UNBALANCE_DETECTION*
        /// </summary>
	    public IntPtr pstUnbalance;
        /// <summary>
        /// �������
        /// CFG_VIDEO_NOISE_DETECTION*
        /// </summary>
	    public IntPtr pstNoise;
        /// <summary>
        ///ģ�����
        /// CFG_VIDEO_BLUR_DETECTION*
        /// </summary>
	    public IntPtr pstBlur;
        /// <summary>
        /// �����仯���
        /// CFG_VIDEO_SCENECHANGE_DETECTION*
        /// </summary>
	    public IntPtr pstSceneChange;
    }

    // ��Ƶ��ϲ�����(CFG_CMD_VIDEODIAGNOSIS_PROFILE)��֧�ֶ��ֲ������ñ�����������   �����������ڴ沢��ʼ��
    public struct CFG_VIDEODIAGNOSIS_PROFILE
    {
        /// <summary>
        /// �����߷���������� ������������ȡ
        /// </summary>
	    public Int32 nTotalProfileNum;
        /// <summary>
        /// ���ص�ʵ�ʲ�������
        /// </summary>
	    public Int32 nReturnProfileNum;
        /// <summary>
        /// �����߷���nProfileCount��VIDEO_DIAGNOSIS_PROFILE
        /// CFG_VIDEO_DIAGNOSIS_PROFILE*
        /// </summary>
	    public IntPtr pstProfiles;
    }

    // �豸��ϸ��Ϣ
    public struct CFG_TASK_REMOTEDEVICE
    {
        /// <summary>
        /// �豸��ַ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]  
	    public byte[] szAddress;
        /// <summary>
        /// �˿ں�
        /// </summary>
	    public UInt32 dwPort;
        /// <summary>
        /// �û���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]  
	    public byte[] szUserName;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]  
	    public byte[] szPassword;
        /// <summary>
        /// �����豸��Э������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]  
	    public byte[] szProtocolType;
    }
    
    public struct CFG_TAST_SOURCES
    {
	    // ����
	    public byte abDeviceID;
	    public byte abRemoteDevice;
        /// <summary>
        /// �豸ID
        /// </summary>
	    public byte[] szDeviceID;
        /// <summary>
        /// �豸��ϸ��Ϣ
        /// </summary>
	    public CFG_TASK_REMOTEDEVICE stRemoteDevice;
        /// <summary>
        /// ��Ƶͨ����
        /// </summary>
	    public Int32 nVideoChannel;
        /// <summary>
        /// ��Ƶ��������
        /// </summary>
	    public CFG_EM_STREAM_TYPE emVideoStream;
        /// <summary>
        /// �������ʱ��
        /// </summary>
	    public Int32 nDuration;
    }

    public struct CFG_DIAGNOSIS_TASK
    {
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]         
	    public byte[] szTaskName;
        /// <summary>
        /// ������ʹ�õ���ϲ�������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]         
	    public byte[] szProfileName;
        /// <summary>
        /// �����߷�����������Դ�ĸ���  ������������ȡ
        /// </summary>
	    public Int32 nTotalSourceNum;
        /// <summary>
        /// ����ʵ����������Դ�ĸ���
        /// </summary>
	    public Int32 nReturnSourceNum;
        /// <summary>
        /// ��������Դ �����߷����ڴ�nTotalSourceNum��
        /// CFG_TAST_SOURCES*
        /// </summary>
	    public IntPtr pstSources;
    };

    // ��Ƶ��������(CFG_CMD_VIDEODIAGNOSIS_TASK),��ͬ������ͨ����������  �����������ڴ沢��ʼ��
    public struct CFG_VIDEODIAGNOSIS_TASK
    {
        /// <summary>
        /// �����߷����������  ������������ȡ
        /// </summary>
	    public Int32 nTotalTaskNum;
        /// <summary>
        /// ����ʵ���������
        /// </summary>
	    public Int32 nReturnTaskNum;
        /// <summary>
        /// �������� �����߷����ڴ�nTotalTaskNum��
        /// CFG_DIAGNOSIS_TASK*
        /// </summary>
	    public IntPtr pstTasks;
    }

    // ��Ƶ��ϼƻ�
    public struct CFG_PROJECT_TASK
    {
        /// <summary>
        /// �����Ƿ�ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	    public byte[] szTaskName;
        /// <summary>
        /// ����ʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[] stTimeSection; 
    }

    public struct CFG_DIAGNOSIS_PROJECT
    {
        /// <summary>
        /// �ƻ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	    public byte[] szProjectName;
        /// <summary>
        /// �����߷��������б����  ������������ȡ
        /// </summary>
	    public Int32 nTotalTaskNum;
        /// <summary>
        /// ����ʵ�������б����
        /// </summary>
	    public Int32 nReturnTaskNum;
        /// <summary>
        /// �����б� �����߷����ڴ�nTotalTaskNum��
        /// CFG_PROJECT_TASK*
        /// </summary>
	    public IntPtr pstProjectTasks;
    }

    // Ƶ��ϼƻ���(CFG_CMD_VIDEODIAGNOSIS_PROJECT),��ͬ�ļƻ�ͨ���������� �����������ڴ沢��ʼ��
    public struct CFG_VIDEODIAGNOSIS_PROJECT
    {
        /// <summary>
        /// �����߷���ƻ�����  ������������ȡ
        /// </summary>
	    public Int32 nTotalProjectNum;
        /// <summary>
        /// ����ʵ�ʼƻ�����
        /// </summary>
	    public Int32 nReturnProjectNum;
        /// <summary>
        /// �ƻ����� �����߷����ڴ�nTotalProjectNum��
        /// CFG_DIAGNOSIS_PROJECT*
        /// </summary>
	    public IntPtr pstProjects;
    }

    // ��Ƶ���ȫ�ֱ�(CFG_CMD_VIDEODIAGNOSIS_GLOBAL),ÿ��ͨ��֧��һ��������� 
    public struct CFG_VIDEODIAGNOSIS_GLOBAL_CHNNL
    {
        /// <summary>
        /// �ƻ��Ƿ�ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��������Ӧ��	����Ӧ�ñ�ʾ���������񣬼ƻ����޸�������Ч������ȵ���ǰ����ִ�е�������ɺ���Ч��
        /// </summary>
	    public bool bApplyNow;
        /// <summary>
        /// �ƻ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] 
	    public byte[] szProjectName;
    }

    public struct CFG_VIDEODIAGNOSIS_GLOBAL
    {
        /// <summary>
        /// �����߷���ȫ�����ø���  ������������ȡ
        /// </summary>
	    public Int32 nTotalGlobalNum;
        /// <summary>
        /// ����ʵ��ȫ�����ø���
        /// </summary>
	    public Int32 nReturnGlobalNum;
        /// <summary>
        /// ��Ƶ���ȫ������ �����߷����ڴ�nGlobalCount��CFG_VIDEODIAGNOSIS_GLOBAL_CHNNL
        /// CFG_VIDEODIAGNOSIS_GLOBAL_CHNNL	*
        /// </summary>
	    public IntPtr pstGlobals;
    }

    // �洢����Ϣ
    public struct CFG_STORAGEGROUP_INFO
    {
        /// <summary>
        /// �洢������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szGroupName;
        /// <summary>
        /// ���������Ż�����
        /// BYTE*
        /// </summary>
	    public IntPtr byDisks;
        /// <summary>
        /// ������byDisks�ĳ���
        /// </summary>
	    public Int32 nBufSize;
        /// <summary>
        /// �洢���еĴ�����
        /// </summary>
	    public Int32 nDiskNum;
        /// <summary>
        /// �洢�����(1~���Ӳ����)
        /// </summary>
	    public Int32 nGroupIndex;
    }

    // �豸����״̬��Ϣ
    public struct CFG_TRAFFIC_WORKSTATE_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ץ��ģʽ
        /// </summary>
	    public CFG_TRAFFIC_SNAP_MODE   emSnapMode;
        /// <summary>
        /// ץ��ƥ��ģʽ: 0-��ʵʱƥ�䷽ʽ���ȱ�����ץ�ģ�ץ��֡���Ǳ���֡;  1-ʵʱƥ��ģʽ������֡��ץ��֡��ͬһ֡ 
        /// </summary>
	    public Int32 nMatchMode;
    }

    // ¼��-�洢�� ��Ӧ��Ϣ
    public struct CFG_RECORDTOGROUP_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ʹ��    
        /// </summary>
	    public bool bEnable; 
        /// <summary>
        /// �洢������, ֻ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]         
	    public byte[] szGroupName;
        /// <summary>
        /// �洢�����(1~�������, 0���ʾ�޶�Ӧ����)��ͨ���˲�����CFG_STORAGE_GROUP_INFO����
        /// </summary>
	    public Int32 nGroupIndex;
    }

    // ͨ������
    public struct AV_CFG_ChannelName
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����ͷΨһ���
        /// </summary>
	    public Int32 nSerial;
        /// <summary>
        /// ͨ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szName;
    };

    // ¼��ģʽ
    public struct AV_CFG_RecordMode
    {
        public Int32 nStructSize;
        /// <summary>
        /// ¼��ģʽ, 0-�Զ�¼��1-�ֶ�¼��2-�ر�¼��
        /// </summary>
        public Int32 nMode;	
    }

    // ��Ƶ�������
    public struct AV_CFG_VideoOutAttr
    {
        public Int32 nStructSize;
        /// <summary>
        /// ��߾�, ����, 0~100
        /// </summary>
        public Int32 nMarginLeft;
        /// <summary>
        /// �ϱ߾�, ����, 0~100
        /// </summary>
        public Int32 nMarginTop;
        /// <summary>
        /// �ұ߾�, ����, 0~100
        /// </summary>
        public Int32 nMarginRight;
        /// <summary>
        /// �±߾�, ����, 0~100
        /// </summary>
        public Int32 nMarginBottom;
        /// <summary>
        /// ����, 0~100
        /// </summary>
        public Int32 nBrightness;
        /// <summary>
        /// �Աȶ�, 0~100
        /// </summary>
        public Int32 nContrast;
        /// <summary>
        /// ���Ͷ�, 0~100
        /// </summary>
        public Int32 nSaturation;
        /// <summary>
        /// ɫ��, 0~100
        /// </summary>
        public Int32 nHue;
        /// <summary>
        /// ˮƽ�ֱ���
        /// </summary>
        public Int32 nWidth;
        /// <summary>
        /// ��ֱ�ֱ���
        /// </summary>
        public Int32 nHeight;
        /// <summary>
        /// ��ɫ���
        /// </summary>
        public Int32 nBPP;
        /// <summary>
        /// 0-Auto, 1-TV, 2-VGA, 3-DVI
        /// </summary>
        public Int32 nFormat;
        /// <summary>
        /// ˢ��Ƶ��
        /// </summary>
        public Int32 nRefreshRate;
        /// <summary>
        /// ���ͼ����ǿ
        /// </summary>
        public bool bIQIMode;
    };

    // Զ���豸
    public  struct AV_CFG_RemoteDevice 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// �豸ID
        /// </summary> 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szID;
        /// <summary>
        /// �豸IP
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] 
	    public byte[] szIP;
        /// <summary>
        /// �˿�
        /// </summary>
	    public Int32 nPort;
        /// <summary>
        /// Э������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] 
	    public byte[] szProtocol;
        /// <summary>
        /// �û���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] 
	    public byte[] szUser;
	    /// <summary>
	    /// ����
	    /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] 
	    public byte[] szPassword;
        /// <summary>
        /// �豸���к�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] 
	    public byte[] szSerial;
        /// <summary>
        /// �豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] 
	    public byte[] szDevClass;
        /// <summary>
        /// �豸�ͺ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] 
	    public byte[] szDevType;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] 
	    public byte[] szName;
        /// <summary>
        /// ��������ص�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)] 
	    public byte[] szAddress;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szGroup;
        /// <summary>
        /// ������, 0-����, 1-����
        /// </summary>
	    public Int32 nDefinition;
        /// <summary>
        /// ��Ƶ����ͨ����
        /// </summary>
	    public Int32 nVideoChannel;
        /// <summary>
        /// ��Ƶ����ͨ����
        /// </summary>
	    public Int32 nAudioChannel;
    };

    // Զ��ͨ��
    public struct AV_CFG_RemoteChannel 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// �豸ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szDeviceID;
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannel;
    };

    // ��ʾԴ
    public struct AV_CFG_DisplaySource 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʹ��
        /// </summary>
        public bool bEnable;
        /// <summary>
        /// �豸ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] szDeviceID;
        /// <summary>
        /// ��Ƶͨ����
        /// </summary>
        public Int32 nVideoChannel;
        /// <summary>
        /// ��Ƶ����
        /// </summary>
        public Int32 nVideoStream;
        /// <summary>
        /// ��Ƶͨ����
        /// </summary>
        public Int32 nAudioChannle;
        /// <summary>
        /// ��Ƶ����
        /// </summary>
        public Int32 nAudioStream;
    };

    // ͨ���ָ���ʾԴ
    public struct AV_CFG_ChannelDisplaySource 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// �ָ������
        /// </summary>
	    public Int32 nWindowNum;
        /// <summary>
        /// �ָ����ʾԴ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public AV_CFG_DisplaySource[]	stuSource;
    };

    // Raid��Ϣ
    public struct AV_CFG_Raid 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
        /// <summary>
        /// �ȼ�
        /// </summary>
	    public Int32 nLevel;
        /// <summary>
        /// ���̳�Ա����
        /// </summary>
	    public Int32 nMemberNum;
        /// <summary>
        /// ���̳�Ա
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 260)]
        public byte[] szMembers;
    };

    // ¼��Դ
    public struct AV_CFG_RecordSource
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// �豸ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDeviceID;
        /// <summary>
        /// ��Ƶͨ����
        /// </summary>
	    public Int32 nVideoChannel;
        /// <summary>
        /// ��Ƶ����
        /// </summary>
	    public Int32 nVideoStream;
        /// <summary>
        /// ��Ƶͨ����
        /// </summary>
	    public Int32 nAudioChannle;
        /// <summary>
        /// ��Ƶ����
        /// </summary>
	    public Int32 nAudioStream;
    };

    // ��Ƶ������ɫ����, ÿ����Ƶ����ͨ����Ӧ�����ɫ����
    public struct AV_CFG_VideoColor
    {
        public Int32 nStructSize;
        /// <summary>
        /// ʱ���
        /// </summary>
        public AV_CFG_TimeSection stuTimeSection;
        /// <summary>
        /// ����, 1~100
        /// </summary>
        public Int32 nBrightness;
        /// <summary>
        /// �Աȶ�, 1~100
        /// </summary>
        public Int32 nContrast;
        /// <summary>
        /// ���Ͷ�, 1~100
        /// </summary>
        public Int32 nSaturation;
        /// <summary>
        /// ɫ��, 1~100
        /// </summary>
        public Int32 nHue;
    };

    // ͨ����Ƶ������ɫ����
    public struct AV_CFG_ChannelVideoColor 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ͨ����ɫ������
        /// </summary>
	    public Int32 nColorNum;
        /// <summary>
        /// ͨ����ɫ����, ÿ��ͨ����Ӧ�����ɫ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	    public AV_CFG_VideoColor[]	stuColor;
    };

    // ��ɫ
    public struct AV_CFG_Color
    {
        public Int32 nStructSize;
        /// <summary>
        /// ��
        /// </summary>
        public Int32 nRed;
        /// <summary>
        /// ��
        /// </summary>
        public Int32 nGreen;
        /// <summary>
        /// ��
        /// </summary>
        public Int32 nBlue;
        /// <summary>
        /// ͸��
        /// </summary>
        public Int32 nAlpha;
    };


    // ����
    public struct AV_CFG_Rect
    {
        public Int32 nStructSize;
        public Int32 nLeft;
        public Int32 nTop;
        public Int32 nRight;
        public Int32 nBottom;
    };

    // �������-ͨ������
    public struct AV_CFG_VideoWidgetChannelTitle
    {
        public Int32 nStructSize;
        /// <summary>
        /// ���ӵ�������
        /// </summary>
        public bool bEncodeBlend;
        /// <summary>
        /// ���ӵ�������1
        /// </summary>
        public bool bEncodeBlendExtra1;
        /// <summary>
        /// ���ӵ�������2
        /// </summary>
        public bool bEncodeBlendExtra2;
        /// <summary>
        /// ���ӵ�������3
        /// </summary>
        public bool bEncodeBlendExtra3;
        /// <summary>
        /// ���ӵ�ץͼ
        /// </summary>
        public bool bEncodeBlendSnapshot;
        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public AV_CFG_Color stuFrontColor;
        /// <summary>
        /// ����ɫ
        /// </summary>
        public AV_CFG_Color stuBackColor;
        /// <summary>
        /// ����, ����ȡֵ0~8191, ��ʹ��left��topֵ, ��(left,top)Ӧ��(right,bottom)���ó�ͬ���ĵ�
        /// </summary>
        public AV_CFG_Rect stuRect;
    };

    // �������-ʱ�����
    public struct AV_CFG_VideoWidgetTimeTitle
    {
        public Int32 nStructSize;
        /// <summary>
        /// ���ӵ�������
        /// </summary>
        public bool bEncodeBlend;
        /// <summary>
        /// ���ӵ�������1
        /// </summary>
        public bool bEncodeBlendExtra1;
        /// <summary>
        /// ���ӵ�������2
        /// </summary>
        public bool bEncodeBlendExtra2;
        /// <summary>
        /// ���ӵ�������3
        /// </summary>
        public bool bEncodeBlendExtra3;
        /// <summary>
        /// ���ӵ�ץͼ
        /// </summary>
        public bool bEncodeBlendSnapshot;
        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public AV_CFG_Color stuFrontColor;
        /// <summary>
        /// ����ɫ
        /// </summary>
        public AV_CFG_Color stuBackColor;
        /// <summary>
        /// ����, ����ȡֵ0~8191, ��ʹ��left��topֵ, ��(left,top)Ӧ��(right,bottom)���ó�ͬ���ĵ�
        /// </summary>
        public AV_CFG_Rect stuRect;
        /// <summary>
        /// �Ƿ���ʾ����
        /// </summary>
        public bool bShowWeek;
    };

    // �������-���򸲸�����
    public struct AV_CFG_VideoWidgetCover
    {
        public Int32 nStructSize;
        /// <summary>
        /// ���ӵ�������
        /// </summary>
        public bool bEncodeBlend;
        /// <summary>
        /// ���ӵ�������1
        /// </summary>
        public bool bEncodeBlendExtra1;
        /// <summary>
        /// ���ӵ�������2
        /// </summary>
        public bool bEncodeBlendExtra2;
        /// <summary>
        /// ���ӵ�������3
        /// </summary>
        public bool bEncodeBlendExtra3;
        /// <summary>
        /// ���ӵ�ץͼ
        /// </summary>
        public bool bEncodeBlendSnapshot;
        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public AV_CFG_Color stuFrontColor;
        /// <summary>
        /// ����ɫ
        /// </summary>
        public AV_CFG_Color stuBackColor;
        /// <summary>
        /// ����, ����ȡֵ0~8191
        /// </summary>
        public AV_CFG_Rect stuRect;
    };

    // �������-�Զ������
    public struct AV_CFG_VideoWidgetCustomTitle 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ���ӵ�������
        /// </summary>
	    public bool bEncodeBlend;
        /// <summary>
        /// ���ӵ�������1
        /// </summary>
	    public bool bEncodeBlendExtra1;
        /// <summary>
        /// ���ӵ�������2
        /// </summary>
	    public bool bEncodeBlendExtra2;
        /// <summary>
        /// ���ӵ�������3
        /// </summary>
	    public bool bEncodeBlendExtra3;
        /// <summary>
        /// ���ӵ�ץͼ
        /// </summary>
	    public bool bEncodeBlendSnapshot;
        /// <summary>
        /// ǰ��ɫ
        /// </summary>
	    public AV_CFG_Color stuFrontColor;
        /// <summary>
        /// ����ɫ
        /// </summary>
	    public AV_CFG_Color stuBackColor;
        /// <summary>
        /// ����, ����ȡֵ0~8191, ��ʹ��left��topֵ, ��(left,top)Ӧ��(right,bottom)���ó�ͬ���ĵ�
        /// </summary>
	    public AV_CFG_Rect stuRect;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[] szText;
    };

    // ��Ƶ�����������
    public struct AV_CFG_VideoWidget 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ͨ������
        /// </summary>
	    public AV_CFG_VideoWidgetChannelTitle	stuChannelTitle;
        /// <summary>
        /// ʱ�����
        /// </summary>
	    public AV_CFG_VideoWidgetTimeTitle		stuTimeTitle;
        /// <summary>
        /// ���򸲸�����
        /// </summary>
	    public Int32 nConverNum;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public AV_CFG_VideoWidgetCover[] stuCovers;
        /// <summary>
        /// �Զ����������
        /// </summary>
	    public Int32 nCustomTitleNum;
        /// <summary>
        /// �Զ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public AV_CFG_VideoWidgetCustomTitle[]	stuCustomTitle;
    };

    // �洢��ͨ���������
    public struct AV_CFG_StorageGroupChannel 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ÿ��ͨ���ļ���ͼƬ�洢����, �����͸���
        /// </summary>
	    public Int32 nMaxPictures;
        /// <summary>
        /// ͨ����������������ַ�����ʾ, %c��Ӧ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szPath;
    };

    // �洢������
    public struct AV_CFG_StorageGroup 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ��������
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
        /// <summary>
        /// ����˵��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] szMemo;
        /// <summary>
        /// �ļ�����ʱ��
        /// </summary>
	    public Int32 nFileHoldTime;
        /// <summary>
        /// �洢�ռ����Ƿ񸲸�
        /// </summary>
	    public bool bOverWrite;
        /// <summary>
        /// ¼���ļ�·����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	    public byte[] szRecordPathRule;
        /// <summary>
        /// ͼƬ�ļ�·����������
        /// %y��, %M��, %d��, %hʱ, %m��, %s��, %cͨ��·��
        /// ���������ʱ�����������, ��һ�α�ʾ��ʼʱ��, �ڶ��α�ʾ����ʱ��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	    public byte[] szPicturePathRule;
        /// <summary>
        /// ͨ��������� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public AV_CFG_StorageGroupChannel[]	stuChannels;
        /// <summary>
        /// ͨ��������
        /// </summary>
	    public Int32 nChannelCount;
    };

    // DSTʱ��
    public struct AV_CFG_DSTTime
    {
        public Int32 nStructSize;
        /// <summary>
        /// ��, 2000~2038
        /// </summary>
        public Int32 nYear;
        /// <summary>
        /// ��, 1~12
        /// </summary>
        public Int32 nMonth;
        /// <summary>
        /// �ڼ���, 1-��һ��,2-�ڶ���,...,-1-���һ��,0-�����ڼ���
        /// </summary>
        public Int32 nWeek;
        /// <summary>
        /// ���ڼ�������
        ///���ܼ���ʱ, 0-����, 1-��һ,..., 6-����
        /// ��������ʱ, ��ʾ����, 1~31
        /// </summary>
        public Int32 nDay;
        /// <summary>
        /// Сʱ
        /// </summary>
        public Int32 nHour;
        /// <summary>
        /// ����
        /// </summary>
        public Int32 nMinute;
    };

    // ��������
    public struct AV_CFG_Locales 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʱ���ʽ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szTimeFormat;
        /// <summary>
        /// ����ʱʱ��
        /// </summary>
	    public bool bDSTEnable;
        /// <summary>
        /// ����ʱ��ʼʱ��
        /// </summary>
	    public AV_CFG_DSTTime stuDstStart;
        /// <summary>
        /// ����ʱ����ʱ��
        /// </summary>
	    public AV_CFG_DSTTime stuDstEnd;
    };

    // ��������
    public struct AV_CFG_Language
    {
        public Int32 nStructSize;
        public AV_CFG_LanguageType emLanguage;						// ��ǰ����
    };

    // ���ʵ�ַ����
    public struct AV_CFG_AccessFilter
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ����, 0-������, 1-������
        /// </summary>
	    public Int32 nType;
        /// <summary>
        /// ������IP����
        /// </summary>
	    public Int32 nWhiteListNum;
        /// <summary>
        /// ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 96)]
	    public byte[] szWhiteList;
        /// <summary>
        /// ������IP��IP������
        /// </summary>
	    public Int32 nBlackListNum;
        /// <summary>
        /// ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024 * 96)]
	    public byte[] szBlackList;
    };


    // �Զ�ά��
    public struct AV_CFG_AutoMaintain
    {
        public Int32 nStructSize;
        /// <summary>
        /// �Զ���������, -1����, 0~6����~����, 7ÿ��
        /// </summary>
        public Int32 nAutoRebootDay;
        /// <summary>
        /// �Զ�����Сʱ, 0~23
        /// </summary>
        public Int32 nAutoRebootHour;
        /// <summary>
        /// �Զ���������, 0~59
        /// </summary>
        public Int32 nAutoRebootMinute;
        /// <summary>
        /// �Զ��ػ�����
        /// </summary>
        public Int32 nAutoShutdownDay;
        /// <summary>
        /// �Զ��ػ�Сʱ
        /// </summary>
        public Int32 nAutoShutdownHour;
        /// <summary>
        /// �Զ��ػ�����
        /// </summary>
        public Int32 nAutoShutdownMinute;
        /// <summary>
        /// �Զ���������
        /// </summary>
        public Int32 nAutoStartupDay;
        /// <summary>
        /// �Զ�����Сʱ
        /// </summary>
        public Int32 nAutoStartupHour;
        /// <summary>
        /// �Զ���������
        /// </summary>
        public Int32 nAutoStartupMinute;
    };

    // Զ���豸�¼�����
    public struct AV_CFG_RemoteEvent 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// �豸ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDeviceID;
        /// <summary>
        /// �¼���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szCode;
        /// <summary>
        /// ���
        /// </summary>
	    public Int32 nIndex;
    };

    // ����ǽ���ͨ����Ϣ
    public struct AV_CFG_MonitorWallTVOut
    {
	    public Int32		nStructSize;
        /// <summary>
        /// �豸ID, Ϊ�ջ�"Local"��ʾ�����豸
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szDeviceID;
        /// <summary>
        /// ͨ��ID
        /// </summary>
	    public Int32		nChannelID;				
        /// <summary>
        /// ��Ļ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
    };

    // ����ǽ����
    public struct AV_CFG_MonitorWallBlock 
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����TVռ����������
        /// </summary>
	    public Int32 nLine;
        /// <summary>
        /// ����TVռ����������
        /// </summary>
	    public Int32 nColumn;
        /// <summary>
        /// �������������
        /// </summary>
	    public AV_CFG_Rect stuRect;
        /// <summary>
        /// TV����
        /// </summary>
	    public Int32 nTVCount;
        /// <summary>
        /// TV����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public AV_CFG_MonitorWallTVOut[]	stuTVs;
    };

    // ����ǽ
    public struct AV_CFG_MonitorWall
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
        /// <summary>
        /// ��������
        /// </summary>
	    public Int32 nLine;
        /// <summary>
        /// ��������
        /// </summary>
	    public Int32 nColumn;
        /// <summary>
        /// ��������
        /// </summary>
	    public Int32 nBlockCount;
        /// <summary>
        /// ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public AV_CFG_MonitorWallBlock[] stuBlocks;

    };

    // ƴ����
    public struct AV_CFG_SpliceScreen
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ƴ��������	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
        /// <summary>
        /// ��������ǽ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szWallName;
        /// <summary>
        /// �����������
        /// </summary>
	    public Int32 nBlockID;
        /// <summary>
        /// ��������(0~8191)
        /// </summary>
	    public AV_CFG_Rect stuRect;
    };

    // ������̨��Ϣ
    public struct AV_CFG_PtzLink
    {
        public Int32 nStructSize;
        /// <summary>
        /// �������� 
        /// </summary>
        public AV_CFG_PtzLinkType emType;
        /// <summary>
        /// ��������1
        /// </summary>
        public Int32 nParam1;
        /// <summary>
        /// ��������2
        /// </summary>
        public Int32 nParam2;
        /// <summary>
        /// ��������3
        /// </summary>
        public Int32 nParam3;
        /// <summary>
        /// ��������̨ͨ��
        /// </summary>
        public Int32 nChannelID;
    } 

    // �����
    public struct AV_CFG_Point
    {
	    public Int32 nStructSize;
	    public Int32 nX;
	    public Int32 nY;
    } 

    // ���
    public struct AV_CFG_Size
    {
	    public Int32 nStructSize;
	    public UInt32 nWidth;
	    public UInt32 nHeight;
    } 	


    // �¼���������
    public struct AV_CFG_EventTitle
    {
	    public Int32 nStructSize;
        /// <summary>
        /// �����ı�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szText;
        /// <summary>
        /// �������Ͻ�����, ����0-8191�������ϵ
        /// </summary>
	    public AV_CFG_Point		stuPoint;
        /// <summary>
        /// ����Ŀ�Ⱥ͸߶�,����0-8191�������ϵ��ĳ���������Ϊ0��ʾ������������Ӧ���
        /// </summary>
	    public AV_CFG_Size			stuSize;
        /// <summary>
        /// ǰ����ɫ
        /// </summary>
        public AV_CFG_Color		stuFrontColor;
        /// <summary>
        /// ������ɫ
        /// </summary>
        public AV_CFG_Color		stuBackColor;
    } 

    // ��Ѳ��������
    public struct AV_CFG_TourLink
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ��Ѳʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ��Ѳʱ�ķָ�ģʽ
        /// </summary>
	    public AV_CFG_SplitMode emSplitMode;
        /// <summary>
        /// ��Ѳͨ�����б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public Int32[] nChannels;
        /// <summary>
        /// ��Ѳͨ������
        /// </summary>
        public Int32 nChannelCount;
    } 


    // ��������
    public  struct AV_CFG_EventHandler
    {
	    public Int32			nStructSize;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public AV_CFG_TimeSection[]  stuTimeSect; 
        /// <summary>
        /// ¼��ʹ��
        /// </summary>
	    public bool bRecordEnable;
        /// <summary>
        /// ¼��ͨ�����б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public UInt32[] nRecordMask;
        /// <summary>
        /// ������, ��ʶnRecordLatch�Ƿ���Ч
        /// </summary>
	    public bool abRecordLatch;
        /// <summary>
        /// ¼����ʱʱ�䣨10~300�룩
        /// </summary>
	    public Int32 nRecordLatch;
        /// <summary>
        /// �������ʹ��
        /// </summary>
	    public bool bAlarmOutEn;
        /// <summary>
        /// �������ͨ�����б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public UInt32[] nAlarmOutMask;
        /// <summary>
        /// ������, ��ʶnAlarmOutLatch�Ƿ���Ч
        /// </summary>
	    public bool abAlarmOutLatch;
        /// <summary>
        /// ���������ʱʱ�䣨10~300�룩
        /// </summary>
	    public Int32 nAlarmOutLatch;
        /// <summary>
        /// ��չ�������ʹ��
        /// </summary>
	    public bool bExAlarmOutEn;
        /// <summary>
        /// ��չ�������ͨ���б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public UInt32[] nExAlarmOutMask;
        /// <summary>
        /// ��̨����ʹ��
        /// </summary>
	    public bool bPtzLinkEn;
        /// <summary>
        /// ��Ч��������Ŀ
        /// </summary>
	    public Int32 nPtzLinkNum;
        /// <summary>
        /// ��̨������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public AV_CFG_PtzLink[]		stuPtzLink;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public bool bSnapshotEn;
        /// <summary>
        /// ����ͨ�����б�	
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public UInt32[] nSnapshotMask;
        /// <summary>
        /// // ������, ��ʶnSnapshotPeriod�Ƿ���Ч
        /// </summary>
	    public bool abSnapshotPeriod;	
        /// <summary>
        /// ֡�����ÿ������֡ץһ��ͼƬ��һ��ʱ����ץ�ĵ���������ץͼ֡���йء�0��ʾ����֡������ץ�ġ�
        /// </summary>
	    public Int32 nSnapshotPeriod;	
        /// <summary>
        /// ������, nSnapshotTimes��Ч��
        /// </summary>
	    public bool abSnapshotTimes;	
        /// <summary>
        /// ���Ĵ���, ��SnapshotEnableΪtrue������£�SnapshotTimesΪ0���ʾ����ץ�ģ�ֱ���¼�������
        /// </summary>
	    public Int32 nSnapshotTimes;		
        /// <summary>
        /// �Ƿ����ͼƬ����
        /// </summary>
	    public bool bSnapshotTitleEn;	
        /// <summary>
        /// ��ЧͼƬ������Ŀ
        /// </summary>
	    public Int32 nSnapTitleNum; 
        /// <summary>
        /// ͼƬ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public AV_CFG_EventTitle[]   stuSnapTitles;
        /// <summary>
        /// ������Ϣ����ʾ
        /// </summary>
	    public bool bTipEnable;
        /// <summary>
        /// �����ʼ��������ͼƬ����Ϊ����
        /// </summary>
	    public bool bMailEnable;
        /// <summary>
        /// �ϴ�������������
        /// </summary>
	    public bool bMessageEnable;
        /// <summary>
        /// ����
        /// </summary>
	    public bool bBeepEnable;
        /// <summary>
        /// ������ʾ
        /// </summary>
	    public bool bVoiceEnable;
        /// <summary>
        /// ������, nDejitter��Ч��
        /// </summary>
	    public bool abDejitter;
        /// <summary>
        /// �ź�ȥ����ʱ�䣬��λΪ��,0~100
        /// </summary>
	    public Int32 nDejitter;
        /// <summary>
        /// �Ƿ��¼��־
        /// </summary>
	    public bool bLogEnable;
        /// <summary>
        /// nDelay��Ч��
        /// </summary>
	    public bool abDelay;
        /// <summary>
        /// ����ʱ����ʱ����Ч, ��λΪ��
        /// </summary>
	    public Int32 nDelay;
        /// <summary>
        /// �Ƿ������Ƶ���⣬��Ҫָ������
        /// </summary>
	    public bool bVideoTitleEn;
        /// <summary>
        /// ��Ч��Ƶ������Ŀ
        /// </summary>
	    public Int32 nVideoTitleNum;
        /// <summary>
        /// ��Ƶ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public AV_CFG_EventTitle[]	stuVideoTitles;
        /// <summary>
        /// ���Ͳ���ʹ��
        /// </summary>
	    public bool bMMSEnable;
        /// <summary>
        /// ��Ѳ������Ŀ������Ƶ���һ��
        /// </summary>
	    public Int32 nTourNum;
        /// <summary>
        /// ��Ѳ��������, ÿ����Ƶ�����Ӧһ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public AV_CFG_TourLink[]	    stuTour;
        /// <summary>
        /// �ؼ�������
        /// </summary>
	    public Int32 nDBKeysNum;
        /// <summary>
        /// �ؼ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64 * 32)]
	    public byte[] szDBKeys;
        /// <summary>
        /// ������, ��ʶbyJpegSummary�Ƿ���Ч
        /// </summary>
	    public bool abJpegSummary;
        /// <summary>
        /// ���ӵ�JPEGͼƬ��ժҪ��Ϣ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	    public byte[] byJpegSummary;
    } 

    // �¶ȱ�������
    public  struct AV_CFG_TemperatureAlarm
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
        /// <summary>
        /// �����¶���Сֵ
        /// </summary>
	    public float fNormalTempMin;
        /// <summary>
        /// �����¶����ֵ
        /// </summary>
	    public float fNormalTempMax;
        /// <summary>
        /// ��������
        /// </summary>
	    public  AV_CFG_EventHandler stuEventHandler;
    } 

    // ����ת�ٱ�������
    public  struct AV_CFG_FanSpeedAlarm
    {
	    public Int32 nStructSize;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public bool bEnable;
        /// <summary>
        /// ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[] szName;
        /// <summary>
        /// ����ת����Сֵ
        /// </summary>
	    public UInt32 nNormalSpeedMin;
        /// <summary>
        /// ����ת�����ֵ
        /// </summary>
	    public UInt32 nNormalSpeedMax;
        /// <summary>
        /// ��������
        /// </summary>
	    public AV_CFG_EventHandler stuEventHandler;
    } 

    // ¼��ش�����
    public struct AV_CFG_RecordBackup
    {
	    public Int32 nStructSize;
        /// <summary>
        /// �����������, ��λKbps
        /// </summary>
	    public UInt32 nBitrateLimit;
    } ;

    #endregion

    #region <<��ͨ�����¼� -- ��Ӧ�Ĺ�������>>


    // �¼�����EVENT_IVS_TRAFFICGATE(��ͨ�����¼�)��Ӧ�Ĺ�������
    public struct CFG_TRAFFICGATE_INFO
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// �������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// �����(������Ȧ)1������
        /// </summary>
	    public Int32 nDetectLinePoint1;
        /// <summary>
        /// �����1
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuDetectLine1;
        /// <summary>
        /// �����(������Ȧ)2������
        /// </summary>
	    public Int32 nDetectLinePoint2;
        /// <summary>
        /// �����2
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuDetectLine2;
        /// <summary>
        /// �󳵵��߶�����
        /// </summary>
	    public Int32 nLeftLinePoint;
        /// <summary>
        /// �󳵵���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuLeftLine;
        /// <summary>
        /// �ҳ����߶�����
        /// </summary>
	    public Int32 nRightLinePoint;
        /// <summary>
        /// �ҳ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuRightLine;
        /// <summary>
        /// �ٶ�Ȩ��ϵ��(���ճ���=��������*Ȩ��ϵ��)
        /// </summary>
	    public Int32 nSpeedWeight;
        /// <summary>
        /// ���������ʵ�ʾ���,��λ����
        /// </summary>
	    public double MetricDistance;
        /// <summary>
        /// �ٶ����� 0��ʾ�������� ��λ��km/h
        /// </summary>
	    public Int32 nSpeedUpperLimit;
        /// <summary>
        /// �ٶ����� 0��ʾ�������� ��λ��km/h
        /// </summary>
	    public Int32 nSpeedLowerLimit;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��������(�������ķ���)��0-�� 1-���� 2-�� 3-���� 4-�� 5-���� 6-�� 7-����
        /// </summary>
	    public Int32 nDirection;
        /// <summary>
        /// ����ģʽ����
        /// </summary>
	    public Int32 nTriggerModeNum;
        /// <summary>
        /// ����ģʽ��"OverLine":ѹ��,"Retrograde":����,"OverSpeed":����,"UnderSpeed":Ƿ��
        /// "Passing":����·�ڣ�������ץ��, "WrongRunningRoute":�г�ռ��(����ʹ��),"YellowVehicleInRoute": ����ռ��
        /// "OverYellowLine":ѹ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 32)]
	    public byte[] szTriggerMode;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
        /// <summary>
        /// �Ƿ��������У��������е�����������
        /// </summary>
	    public bool bMaskRetrograde;
    } 

    // �¼�����EVENT_IVS_TRAFFICJUNCTION(��ͨ·���¼�)��Ӧ�Ĺ�������
    public struct CFG_TRAJUNCTION_INFO
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// �������
        /// </summary>
	    public Int32 nLane;
        /// <summary>
        /// ��������(�������ķ���),0-�� 1-���� 2-�� 3-���� 4-�� 5-���� 6-�� 7-����
        /// </summary>
	    public Int32 nDirection;
        /// <summary>
        /// ǰ�ü���߶�����
        /// </summary>
	    public Int32 nPreLinePoint;
        /// <summary>
        /// ǰ�ü����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuPreLine;
        /// <summary>
        /// �м����߶�����
        /// </summary>
	    public Int32 nMiddleLinePoint;
        /// <summary>
        /// �м�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuMiddleLine;
        /// <summary>
        /// ���ü���߶�����
        /// </summary>
	    public Int32 nPostLinePoint;
        /// <summary>
        /// ���ü����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuPostLine;
        /// <summary>
        /// �������ޣ���λ��/��
        /// </summary>
	    public Int32 nFlowLimit;
        /// <summary>
        /// �ٶ����ޣ���Ϊ0�����ʾ�������ޣ�km/h
        /// </summary>
	    public Int32 nSpeedDownLimit;
        /// <summary>
        /// �ٶ����ޣ���Ϊ0�����ʾ�������ޣ�km/h
        /// </summary>
	    public Int32 nSpeedUpLimit;
        /// <summary>
        /// ����ģʽ����
        /// </summary>
	    public Int32 nTriggerModeNum;
        /// <summary>
        /// ����ģʽ��"Passing" : ����·��(���м�����Ϊ׼��ֻ�ܵ���ʹ��),"RunRedLight" : �����
        /// "Overline":ѹ�׳�����,"OverYellowLine": ѹ����, "Retrograde":����
        /// "TurnLeft":Υ����ת, "TurnRight":Υ����ת, "CrossLane":Υ�±��
        /// "U-Turn" Υ�µ�ͷ, "Parking":Υ��ͣ��, "WaitingArea" Υ�½��������
        /// "OverSpeed": ����,"UnderSpeed":Ƿ��,"Overflow" : ��������
        /// "Human":����,"NoMotor":�ǻ�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 32)]
	    public byte[] szTriggerMode;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
        /// <summary>
        /// �Ƿ��������У��������е�����������
        /// </summary>
	    public bool bMaskRetrograde;
    			
    } 

    // �¼�����EVENT_IVS_TRAFFICACCIDENT(��ͨ�¹��¼�)��Ӧ�Ĺ�������
    public struct CFG_TRAACCIDENT_INFO
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// �����������
        /// </summary>
	    public Int32 nDetectRegionPoint;
        /// <summary>
        /// �����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
    	
    } 

    // �¼�����EVENT_IVS_TRAFFICCONTROL(��ͨ�����¼�)��Ӧ�Ĺ�������
    public struct CFG_TRAFFICCONTROL_INFO 
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// ����߶�����
        /// </summary>
	    public Int32 nDetectLinePoint;
        /// <summary>
        /// �����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuDetectLine;
        /// <summary>
        /// ����ʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSchedule;
        /// <summary>
        /// ������С���͸���
        /// </summary>
	    public Int32 nVehicleSizeNum;
        /// <summary>
        /// ������С�����б�"Light-duty":С�ͳ�;	"Medium":���ͳ�; "Oversize":���ͳ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 32)]
	    public byte[] szVehicleSizeList;
        /// <summary>
        /// �������͸���
        /// </summary>
	    public Int32 nPlateTypeNum;
        /// <summary>
        /// ���������б�"Unknown" δ֪; "Normal" ���ƺ���; "Yellow" ����; "DoubleYellow" ˫���β��
        /// "Police" ����; "Armed" �侯��; "Military" ���Ӻ���; "DoubleMilitary" ����˫��
        /// "SAR" �۰���������; "Trainning" ����������; "Personal" ���Ժ���; "Agri" ũ����
        /// "Embassy" ʹ�ݺ���; "Moto" Ħ�г�����; "Tractor" ����������; "Other" ��������
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32 * 32)]
	    public byte[] szPlateTypesList;
        /// <summary>
        /// ���Ƶ�˫�� 0:����; 1:˫��; 2:��˫��;	
        /// </summary>
	    public Int32 nPlateNumber;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
    } 


    // �¼�����EVENT_IVS_FACEDETECT(��������¼�)��Ӧ�Ĺ�������
    public struct CFG_FACEDETECT_INFO
    {
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public bool bRuleEnable;
	    /// <summary>
	    /// �����ֶ�
	    /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public int nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// �����������
        /// </summary>
	    public int nDetectRegionPoint;
        /// <summary>
        /// �����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// �����¼����������͸���
        /// </summary>
	    public Int32 nHumanFaceTypeCount;
        /// <summary>
        /// �����¼�����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 32)]
	    public byte[] szHumanFaceType;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
    }

    // �¼�����EVENT_IVS_PASTEDETECTION(ATM�����¼�)��Ӧ�Ĺ�������
    public struct CFG_PASTE_INFO
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// ��̳���ʱ��	��λ���룬0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// ������򶥵���
        /// </summary>
	    public Int32 nDetectRegionPoint;
        /// <summary>
        /// �������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
    		
    } 

    // ��Ƶ�����¼���������
    // �¼�����EVENT_IVS_CROSSLINEDETECTION(�������¼�)��Ӧ�Ĺ�������
    public struct CFG_CROSSLINE_INFO
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// ��ⷽ��:0:��������;1:��������;2:���߶�����
        /// </summary>
	    public Int32 nDirection;
        /// <summary>
        /// �����߶�����
        /// </summary>
	    public Int32 nDetectLinePoint;
        /// <summary>
        /// ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYLINE[] stuDetectLine;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
        /// <summary>
        /// �����ض��ĳߴ�������Ƿ���Ч
        /// </summary>
	    public bool bSizeFileter;
        /// <summary>
        /// �����ض��ĳߴ������
        /// </summary>
	    public CFG_SIZEFILTER_INFO stuSizeFileter;
        /// <summary>
        /// ��������λ����
        /// </summary>
	    public Int32 nTriggerPosition;      
        /// <summary>
        /// ��������λ��,0-Ŀ����ӿ�����, 1-Ŀ����ӿ��������, 2-Ŀ����ӿ򶥶�����, 3-Ŀ����ӿ��Ҷ�����, 4-Ŀ����ӿ�׶�����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[] bTriggerPosition;

    } 

    // �¼�����EVENT_IVS_CROSSREGIONDETECTION(�������¼�)��Ӧ�Ĺ�������
    public struct CFG_CROSSREGION_INFO
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16* 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// ��ⷽ��:0:Enter;1:Leave;2:Both
        /// </summary>
	    public Int32 nDirection;
        /// <summary>
        /// ������������
        /// </summary>
	    public Int32 nDetectRegionPoint;
        /// <summary>
        /// ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
        /// <summary>
        /// �����ض��ĳߴ�������Ƿ���Ч
        /// </summary>
	    public bool bSizeFileter;
        /// <summary>
        /// �����ض��ĳߴ������
        /// </summary>
	    public CFG_SIZEFILTER_INFO stuSizeFileter;
        /// <summary>
        /// ��⶯����
        /// </summary>
	    public Int32 nActionType;
        /// <summary>
        /// ��⶯���б�,0-���� 1-��ʧ 2-�������� 3-��Խ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[] bActionType;
        /// <summary>
        /// ��СĿ�����(��bActionType�а���"2-��������"ʱ��Ч)
        /// </summary>
	    public Int32 nMinTargets;
        /// <summary>
        /// ���Ŀ�����(��bActionType�а���"2-��������"ʱ��Ч)
        /// </summary>
	    public Int32 nMaxTargets;
        /// <summary>
        /// ��̳���ʱ�䣬 ��λ��(��bActionType�а���"2-��������"ʱ��Ч)
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// ����ʱ������ ��λ��(��bActionType�а���"2-��������"ʱ��Ч)
        /// </summary>
	    public Int32 nReportInterval;
    		
    } 

    // �¼�����EVENT_IVS_WANDERDETECTION(�ǻ��¼�)��Ӧ�Ĺ�������
    public struct CFG_WANDER_INFO 
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[] bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// ��̳���ʱ��	��λ���룬0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// ������򶥵���
        /// </summary>
	    public Int32 nDetectRegionPoint;
        /// <summary>
        /// �������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;
        /// <summary>
        /// ��������λ����
        /// </summary>
	    public Int32 nTriggerPosition;
        /// <summary>
        /// ��������λ��,0-Ŀ����ӿ�����, 1-Ŀ����ӿ��������, 2-Ŀ����ӿ򶥶�����, 3-Ŀ����ӿ��Ҷ�����, 4-Ŀ����ӿ�׶����� 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[] bTriggerPosition;
        /// <summary>
        /// �����������ǻ�����������
        /// </summary>
	    public Int32 nTriggerTargetsNumber;
        /// <summary>
        /// ����ʱ����,��λ��
        /// </summary>
	    public Int32 nReportInterval;
        /// <summary>
        /// �����ض��ĳߴ�������Ƿ���Ч
        /// </summary>
	    public bool bSizeFileter;
        /// <summary>
        /// �����ض��ĳߴ������
        /// </summary>
	    public CFG_SIZEFILTER_INFO stuSizeFileter;

    } 

    // �¼�����EVENT_IVS_RIOTERDETECTION(�����¼�)��Ӧ�Ĺ�������
    public struct CFG_RIOTER_INFO 
    {
	    // ��Ϣ
        /// <summary>
        /// ��������,��ͬ����������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szRuleName;
        /// <summary>
        /// ����ʹ��
        /// </summary>
	    public byte bRuleEnable;
        /// <summary>
        /// �ۼ���ռ��������ٷֱ�
        /// </summary>
	    public byte bAreaPercent;
        /// <summary>
        /// �����ȣ�ȡֵ1-10��ֵԽС������Խ�ͣ���Ӧ��Ⱥ���ܼ��̶�Խ��(ȡ��bAreaPercent)
        /// </summary>
	    public byte bSensitivity;
        /// <summary>
        /// �����ֶ�
        /// </summary>
	    public byte bReserved;
        /// <summary>
        /// ��Ӧ�������͸���
        /// </summary>
	    public Int32 nObjectTypeNum;
        /// <summary>
        /// ��Ӧ���������б�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 * 32)]
	    public byte[] szObjectTypes;
        /// <summary>
        /// ��̳���ʱ��	��λ���룬0~65535
        /// </summary>
	    public Int32 nMinDuration;
        /// <summary>
        /// ������򶥵���
        /// </summary>
	    public Int32 nDetectRegionPoint;
        /// <summary>
        /// �������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public CFG_POLYGON[] stuDetectRegion;
        /// <summary>
        /// ��������
        /// </summary>
	    public CFG_ALARM_MSG_HANDLE stuEventHandler;
        /// <summary>
        /// �¼���Ӧʱ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7 * 6)]
	    public CFG_TIME_SECTION[]	stuTimeSection;
        /// <summary>
        /// ��̨Ԥ�õ���	0~65535
        /// </summary>
	    public Int32 nPtzPresetId;

    }

    public struct ReservedDataIntelBox
    {
        /// <summary>
        /// �¼�����
        /// </summary>
        public UInt32 dwEventCount;
        /// <summary>
        /// ָ���������¼����͵�ֵ���ռ����û��Լ����롣
        /// DWORD* dwPtrEventType;
        /// </summary>
        public IntPtr dwPtrEventType;
        /// <summary>
        /// �����ֽ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] bReserved;
    }

    public struct NET_RESERVED_COMMON
    {
        public UInt32 dwStructSize;
        /// <summary>
        /// ����RESERVED_TYPE_FOR_INTEL_BOX
        /// c++�¶��壺
        /// ReservedDataIntelBox* pIntelBox;
        /// </summary>
        public IntPtr pIntelBox;
        /// <summary>
        /// ץͼ��־(��λ)��0λ:"*",1λ:"Timing",2λ:"Manual",3λ:"Marked",4λ:"Event",5λ:"Mosaic",6λ:"Cutout"
        /// </summary>
        public UInt32 dwSnapFlagMask;
    }

    public struct ReservedPara
    {
        /// <summary>
        /// pData����������
        /// </summary>
        public UInt32 dwType;
        /// <summary>
        ///��[dwType]ΪRESERVED_TYPE_FOR_INTEL_BOX ʱ��pData ��ӦΪ�ṹ��ReservedDataIntelBox�ĵ�ַ					
        /// ��[dwType]Ϊ...ʱ��[pData]��Ӧ...
        /// ����
        /// c++�¶���Ϊ��
        /// void*	pData;	//����
        /// </summary>
        public IntPtr pData;

    }
    #endregion

    #region <<���ܽ�ͨ--����ͼƬ����ؽṹ��>>

    // DH_MEDIA_QUERY_TRAFFICCAR��Ӧ�Ĳ�ѯ����
    public struct  MEDIA_QUERY_TRAFFICCAR_PARAM
    {
        /// <summary>
        /// ͨ���Ŵ�0��ʼ��-1��ʾ��ѯ����ͨ��
        /// </summary>
	    public Int32 nChannelID;
        /// <summary>
        /// ��ʼʱ��	
        /// </summary>
	    public NET_TIME StartTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
	    public NET_TIME EndTime;
        /// <summary>
        /// �ļ����ͣ�0:��ѯ��������,1:��ѯjpgͼƬ
        /// </summary>
	    public Int32 nMediaType;
        /// <summary>
        /// �¼����ͣ����"���ܷ����¼�����", 0:��ʾ��ѯ�����¼�
        /// </summary>
	    public Int32 nEventType;
        /// <summary>
        /// ���ƺ�, "\0"���ʾ��ѯ���⳵�ƺ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szPlateNumber;
        /// <summary>
        /// ��ѯ�ĳ��ٷ�Χ; �ٶ����� ��λ: km/h
        /// </summary>
	    public Int32 nSpeedUpperLimit;
        /// <summary>
        /// ��ѯ�ĳ��ٷ�Χ; �ٶ����� ��λ: km/h 
        /// </summary>
	    public Int32 nSpeedLowerLimit;
        /// <summary>
        /// �Ƿ��ٶȲ�ѯ; TRUE:���ٶȲ�ѯ,nSpeedUpperLimit��nSpeedLowerLimit��Ч��
        /// </summary>
	    public bool bSpeedLimit;
        /// <summary>
        /// Υ�����ͣ�
        /// ���¼�����Ϊ EVENT_IVS_TRAFFICGATEʱ
        /// ��һλ:����;  �ڶ�λ:ѹ����ʻ; ����λ:������ʻ; 
        /// ����λ��Ƿ����ʻ; ����λ:�����;
        /// ���¼�����Ϊ EVENT_IVS_TRAFFICJUNCTION
        /// ��һλ:�����;  �ڶ�λ:�����涨������ʻ;  
        /// ����λ:����; ����λ��Υ�µ�ͷ;
        /// ����λ:ѹ����ʻ;
        /// </summary>
        public UInt32 dwBreakingRule;
        /// <summary>
        /// �������ͣ�"Unknown" δ֪,"Normal" ���ƺ���,"Yellow" ����,"DoubleYellow" ˫���β��,"Police" ����"Armed" �侯��,
        /// "Military" ���Ӻ���,"DoubleMilitary" ����˫��,"SAR" �۰���������,"Trainning" ����������
        /// "Personal" ���Ժ���,"Agri" ũ����,"Embassy" ʹ�ݺ���,"Moto" Ħ�г�����,"Tractor" ����������,"Other" ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] szPlateType;
        /// <summary>
        /// ������ɫ, "Blue"��ɫ,"Yellow"��ɫ, "White"��ɫ,"Black"��ɫ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szPlateColor;
        /// <summary>
        /// ������ɫ:"White"��ɫ, "Black"��ɫ, "Red"��ɫ, "Yellow"��ɫ, "Gray"��ɫ, "Blue"��ɫ,"Green"��ɫ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szVehicleColor;
        /// <summary>
        /// ������С����:"Light-duty":С�ͳ�;"Medium":���ͳ�; "Oversize":���ͳ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] szVehicleSize;
        /// <summary>
        /// �¼�����(��ֵ>=0ʱ��Ч)
        /// </summary>
	    public Int32 nGroupID;
        /// <summary>
        /// ������(��ֵ>=0ʱ��Ч)
        /// </summary>
	    public Int16 byLane;
        /// <summary>
        /// �ļ���־, 0xFF-ʹ��nFileFlagEx, 0-��ʾ����¼��, 1-��ʱ�ļ�, 2-�ֶ��ļ�, 3-�¼��ļ�, 4-��Ҫ�ļ�, 5-�ϳ��ļ�
        /// </summary>
	    public byte byFileFlag;
        /// <summary>
        /// �ļ���־, ��λ��ʾ: bit0-��ʱ�ļ�, bit1-�ֶ��ļ�, bit2-�¼��ļ�, bit3-��Ҫ�ļ�, bit4-�ϳ��ļ�, 0xFFFFFFFF-����¼��
        /// </summary>
	    public Int32 nFileFlagEx;
	    public byte reserved;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
	    public Int32[] bReserved;
    }

    // DH_MEDIA_QUERY_TRAFFICCAR��ѯ������media�ļ���Ϣ
    public struct MEDIAFILE_TRAFFICCAR_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
        public UInt32 ch;
        /// <summary>
        /// �ļ�·��
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szFilePath;
        /// <summary>
        /// �ļ�����
        /// </summary>
        public UInt32 size;
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public NET_TIME starttime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public NET_TIME endtime;
        /// <summary>
        /// ����Ŀ¼���									
        /// </summary>
        public UInt32 nWorkDirSN;
        /// <summary>
        /// �ļ�����  1��jpgͼƬ
        /// </summary>
        public byte nFileType;
        /// <summary>
        /// �ļ���λ����
        /// </summary>
        public byte bHint;
        /// <summary>
        /// ���̺�
        /// </summary>
        public byte bDriveNo;
        public byte bReserved2;
        /// <summary>
        /// �غ�
        /// </summary>
        public UInt32 nCluster;
        /// <summary>
        /// ͼƬ����, 0-��ͨ, 1-�ϳ�, 2-��ͼ
        /// </summary>
        public byte byPictureType;
        /// <summary>
        /// �����ֶ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] bReserved;

        //�����ǽ�ͨ������Ϣ
        /// <summary>
        /// ���ƺ���
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPlateNumber;
        /// <summary>
        /// ��������"Unknown" δ֪; "Normal" ���ƺ���; "Yellow" ����; "DoubleYellow" ˫���β��
        /// "Police" ����; "Armed" �侯��; "Military" ���Ӻ���; "DoubleMilitary" ����˫��
        /// "SAR" �۰���������; "Trainning" ����������; "Personal" ���Ժ���; "Agri" ũ����
        /// "Embassy" ʹ�ݺ���; "Moto" Ħ�г�����; "Tractor" ����������; "Other" ��������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szPlateType;
        /// <summary>
        /// ������ɫ:"Blue","Yellow", "White","Black"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szPlateColor;
        /// <summary>
        /// ������ɫ:"White", "Black", "Red", "Yellow", "Gray", "Blue","Green"
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szVehicleColor;
        /// <summary>
        /// ����,��λKm/H
        /// </summary>
        public Int32 nSpeed;
        /// <summary>
        /// �������¼�����
        /// </summary>
        public Int32 nEventsNum;
        /// <summary>
        /// �������¼��б�,����ֵ��ʾ��Ӧ���¼������"���ܷ����¼�����"		
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Int32[] nEvents;
        /// <summary>
        /// ����Υ����������,��һλ:�����; �ڶ�λ:�����涨������ʻ;
        /// ����λ:����; ����λ��Υ�µ�ͷ;����Ĭ��Ϊ:��ͨ·���¼�
        /// </summary>
        public UInt32 dwBreakingRule;
        /// <summary>
        /// ������С����:"Light-duty":С�ͳ�;"Medium":���ͳ�; "Oversize":���ͳ�
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szVehicleSize;
        /// <summary>
        /// ���ػ�Զ�̵�ͨ������
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szChannelName;
        /// <summary>
        /// ���ػ�Զ���豸����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] szMachineName;
        /// <summary>
        /// �ٶ����� ��λ: km/h
        /// </summary>
        public Int32 nSpeedUpperLimit;
        /// <summary>
        /// �ٶ����� ��λ: km/h	
        /// </summary>
        public Int32 nSpeedLowerLimit;
        /// <summary>
        /// �¼��������
        /// </summary>
        public Int32 nGroupID;
        /// <summary>
        /// һ���¼����ڵ�ץ������
        /// </summary>
        public byte byCountInGroup;
        /// <summary>
        /// һ���¼����ڵ�ץ�����
        /// </summary>
        public byte byIndexInGroup;
        /// <summary>
        /// ����
        /// </summary>
        public byte byLane;
        /// <summary>
        /// ����
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 49)]
        public byte[] bReserved1;
    } 


    public struct DH_DEV_ENABLE_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	    public UInt32[] IsFucEnable;				// Function list capacity set. Corresponding to the above mentioned enumeration. Use bit to represent sub-function.
    }

    // ץͼ�������Խṹ��
    public struct DH_QUERY_SNAP_INFO
    {
        /// <summary>
        /// ͨ����
        /// </summary>
	    public Int32 nChannelNum; 
        /// <summary>
        /// �ֱ���(��λ)������鿴ö��CAPTURE_SIZE
        /// </summary>
	    public UInt32 dwVideoStandardMask;
		/// <summary>
		/// Frequence[128]�������Ч����
		/// </summary>
	    public Int32 nFramesCount;
        /// <summary>
        /// ֡��(����ֵ)
        /// -25��25��1֡��-24��24��1֡��-23��23��1֡��-22��22��1֡
        /// ����
        /// 0����Ч��1��1��1֡��2��1��2֡��3��1��3֡
        /// 4��1��4֡��5��1��5֡��17��1��17֡��18��1��18֡
        /// 19��1��19֡��20��1��20֡
        /// ����
        /// 25: 1��25֡
        /// char
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public sbyte[] Frames; 
        /// <summary>
        /// SnapMode[16]�������Ч����
        /// </summary>
	    public Int32 nSnapModeCount;
        /// <summary>
        /// (����ֵ)0����ʱ����ץͼ��1���ֶ�����ץͼ
        /// char
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] SnapMode;
        /// <summary>
        /// Format[16]�������Ч����
        /// </summary>
	    public Int32 nPicFormatCount;
        /// <summary>
        /// (����ֵ)0��BMP��ʽ��1��JPG��ʽ
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[] PictureFormat;
        /// <summary>
        /// Quality[32]�������Ч����
        /// </summary>
	    public Int32 nPicQualityCount;
        /// <summary>
        /// ����ֵ
        /// 100��ͼ������100%��80:ͼ������80%��60:ͼ������60%
        /// 50:ͼ������50%��30:ͼ������30%��10:ͼ������10%
        /// char
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[] PictureQuality;
        /// <summary>
        /// ����
        /// char
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[] nReserved; 
    } 

    public struct DH_SNAP_ATTR_EN
    {
        /// <summary>
        /// ͨ������
        /// </summary>
	    public Int32 nChannelCount; 

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public DH_QUERY_SNAP_INFO[]  stuSnap;
    } 

    
    // ץͼ�����ṹ��
    public struct SNAP_PARAMS
    {
        /// <summary>
        /// ץͼ��ͨ��
        /// </summary>
	    public UInt32 Channel;
        /// <summary>
        /// ���ʣ�1~6
        /// </summary>
	    public UInt32 Quality;
        /// <summary>
        /// �����С��0��QCIF��1��CIF��2��D1
        /// </summary>
	    public UInt32 ImageSize;
        /// <summary>
        /// ץͼģʽ��0����ʾ����һ֡��1����ʾ��ʱ��������2����ʾ��������
        /// </summary>
	    public Int32 mode;
        /// <summary>
        /// ʱ�䵥λ�룻��mode=1��ʾ��ʱ��������ʱ����ʱ����Ч
        /// </summary>
	    public UInt32 InterSnap;
        /// <summary>
        /// �������к�
        /// </summary>
	    public UInt32 CmdSerial;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public UInt32[] Reserved;
    }

    #endregion

}