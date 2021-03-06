USE [Jac]
GO
/****** Object:  Table [dbo].[actualprescriptionmeds]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actualprescriptionmeds](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[drug_description] [nvarchar](255) NULL,
	[surname] [nvarchar](255) NULL,
	[forenames] [nvarchar](255) NULL,
	[hospital_no] [float] NULL,
	[frequency_description] [nvarchar](255) NULL,
	[frequency_code] [nvarchar](255) NULL,
	[ward] [nvarchar](255) NULL,
	[discontinued_by] [nvarchar](255) NULL,
	[ward_stock] [nvarchar](255) NULL,
	[order_type] [nvarchar](255) NULL,
	[secondary_dose] [float] NULL,
	[status] [nvarchar](255) NULL,
	[primary_dose_description] [nvarchar](255) NULL,
	[primary_dose] [float] NULL,
	[lnkpid] [nvarchar](255) NULL,
	[current_spell] [float] NULL,
	[prn] [nvarchar](255) NULL,
	[stop_date] [nvarchar](255) NULL,
	[stop_days_doses] [nvarchar](255) NULL,
	[stop_days_doses_flag] [nvarchar](255) NULL,
	[change_start_date] [datetime] NULL,
	[change_start_time] [datetime] NULL,
	[lnkordid] [float] NULL,
	[route] [nvarchar](255) NULL,
	[stat] [nvarchar](255) NULL,
	[stop_date1] [nvarchar](255) NULL,
	[prescribing_drug_id] [nvarchar](255) NULL,
	[lnkordid1] [float] NULL,
	[group_code] [nvarchar](255) NULL,
	[c_alt_dose] [nvarchar](255) NULL,
	[c_bulk] [float] NULL,
	[suspend_date] [datetime] NULL,
	[suspend_time] [datetime] NULL,
	[resume_date] [nvarchar](255) NULL,
	[resume_time] [nvarchar](255) NULL,
	[suspend_reason] [nvarchar](255) NULL,
 CONSTRAINT [PK_actualprescriptionmeds] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admissiondetails]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admissiondetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[start_date] [datetime] NULL,
	[start_time] [datetime] NULL,
	[end_date] [nvarchar](255) NULL,
	[end_time] [nvarchar](255) NULL,
	[lnkpid] [nvarchar](255) NULL,
	[consultant] [nvarchar](255) NULL,
	[lnkspell] [float] NULL,
 CONSTRAINT [PK_admissiondetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[allergies]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[allergies](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[lnkpid] [nvarchar](255) NULL,
	[allergy_description] [nvarchar](255) NULL,
	[reaction] [nvarchar](255) NULL,
 CONSTRAINT [PK_allergies] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[allusers]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[allusers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[surname] [nvarchar](255) NULL,
	[forenames] [nvarchar](255) NULL,
	[title] [nvarchar](255) NULL,
	[department] [nvarchar](255) NULL,
	[jobtitle] [nvarchar](255) NULL,
 CONSTRAINT [PK_allusers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bnfcodes]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bnfcodes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[lnkdid] [nvarchar](255) NULL,
	[c_strength] [nvarchar](255) NULL,
	[c_bnf_code] [nvarchar](255) NULL,
	[c_cd] [float] NULL,
 CONSTRAINT [PK_bnfcodes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clinicalnotes]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clinicalnotes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[added_date] [datetime] NULL,
	[reason] [nvarchar](255) NULL,
	[F3] [nvarchar](max) NULL,
	[title] [nvarchar](255) NULL,
	[lnkpid] [nvarchar](255) NULL,
	[lnkspell] [float] NULL,
	[added_by] [nvarchar](255) NULL,
	[drug_name] [nvarchar](255) NULL,
	[lnkordid] [float] NULL,
 CONSTRAINT [PK_clinicalnotes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuidelineManagement]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuidelineManagement](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GuidelineName] [nvarchar](100) NULL,
	[GuidelineLink] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_GuidelineManagement] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedAdmins]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedAdmins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[admin_reason] [varchar](35) NULL,
	[administered_date] [date] NULL,
	[admin_time] [time](7) NULL,
	[charted_date] [date] NULL,
	[administered_time] [time](7) NULL,
	[lnkpid] [varchar](10) NULL,
	[lnkordid] [numeric](15, 0) NULL,
	[administrator] [varchar](45) NULL,
 CONSTRAINT [PK_MedAdmins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicines]    Script Date: 05/15/18 6:28:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DrugName] [nvarchar](200) NULL,
	[Bnfcode] [nvarchar](200) NULL,
	[Route] [nvarchar](200) NULL,
	[ExclusionWards] [nvarchar](200) NULL,
	[RiskFactor] [int] NOT NULL,
	[IsHighRisk] [bit] NOT NULL,
	[IsMediumRisk] [bit] NOT NULL,
	[POPAANPTA] [bit] NOT NULL,
	[IsVTE] [bit] NOT NULL,
	[IsCautious] [bit] NOT NULL,
	[IsMissedDoseNotification] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Medicines] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NewsHead] [varchar](512) NULL,
	[NewsBody] [text] NULL,
	[NewsImagePath] [varchar](255) NULL,
	[NewsDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[LastUpdate] [datetime] NULL,
 CONSTRAINT [PK_tnews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patientmeds]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patientmeds](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[lnkpid] [nvarchar](255) NULL,
	[start_date] [datetime] NULL,
	[lnkspell] [float] NULL,
	[drug_description] [nvarchar](255) NULL,
	[prn] [nvarchar](255) NULL,
	[stat] [nvarchar](255) NULL,
	[status] [nvarchar](255) NULL,
	[frequency_description] [nvarchar](255) NULL,
	[freeform_frequency] [nvarchar](255) NULL,
	[primary_dose] [float] NULL,
	[change_start_date] [datetime] NULL,
	[change_start_time] [datetime] NULL,
	[stop_date] [nvarchar](255) NULL,
	[lnkordid] [float] NULL,
	[stop_time] [nvarchar](255) NULL,
	[route] [nvarchar](255) NULL,
	[self_administer] [nvarchar](255) NULL,
	[prescribing_drug_id] [nvarchar](255) NULL,
	[order_type] [nvarchar](255) NULL,
	[suspend_date] [datetime] NULL,
	[suspend_time] [datetime] NULL,
	[resume_date] [datetime] NULL,
	[resume_time] [datetime] NULL,
	[suspend_reason] [nvarchar](255) NULL,
 CONSTRAINT [PK_patientmeds] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[surname] [nvarchar](255) NULL,
	[hospital_no] [float] NULL,
	[ward] [nvarchar](255) NULL,
	[group_code] [nvarchar](255) NULL,
	[lnkpid] [nvarchar](255) NULL,
	[current_spell] [float] NULL,
	[forenames] [nvarchar](255) NULL,
 CONSTRAINT [PK_patients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PMB]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PMB](
	[MsgID] [int] IDENTITY(1,1) NOT NULL,
	[ReceiverID] [int] NULL,
	[Msg] [varchar](7000) NULL,
	[SenderID] [int] NULL,
	[IsActive] [bit] NULL,
	[DateTime] [datetime] NULL,
 CONSTRAINT [PK_PMB] PRIMARY KEY CLUSTERED 
(
	[MsgID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scheduler]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scheduler](
	[SchedulerID] [int] IDENTITY(1,1) NOT NULL,
	[InspectorID] [int] NULL,
	[ScheduleDate] [datetime] NULL,
	[ScheduleTime] [datetime] NULL,
	[ScheduleTitle] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[SomeImportantKey] [int] NULL,
	[StatusENUM] [int] NULL,
	[AppointmentLength] [int] NULL,
 CONSTRAINT [PK_tInspectorScheduler] PRIMARY KEY CLUSTERED 
(
	[SchedulerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specialconsideration]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specialconsideration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[drug_speccon] [nvarchar](255) NULL,
	[lnkdid] [nvarchar](255) NULL,
	[piece_no] [float] NULL,
	[speccon_description] [nvarchar](255) NULL,
	[drug_basic_common] [nvarchar](255) NULL,
	[lnkdid1] [nvarchar](255) NULL,
	[c_drugname] [nvarchar](255) NULL,
	[c_strength] [nvarchar](255) NULL,
	[c_form] [nvarchar](255) NULL,
	[c_bnf_code] [nvarchar](255) NULL,
 CONSTRAINT [PK_specialconsideration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[superusers]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[superusers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[surname] [nvarchar](255) NULL,
	[forenames] [nvarchar](255) NULL,
	[UltimateUser] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_superusers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[verified]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[verified](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](255) NULL,
	[verified_by] [nvarchar](255) NULL,
	[verify_date] [datetime] NULL,
	[verify_time] [datetime] NULL,
	[lnkordid] [float] NULL,
	[lnkpid] [nvarchar](255) NULL,
	[change_start_date] [datetime] NULL,
	[change_start_time] [datetime] NULL,
 CONSTRAINT [PK_verified] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WardPatient]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WardPatient](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DrugName] [nvarchar](100) NULL,
	[DrugCode] [nvarchar](100) NULL,
 CONSTRAINT [PK_WardPatient] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wards]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WardName] [nvarchar](200) NULL,
 CONSTRAINT [PK_dbo.Wards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wardstock]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wardstock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[lnkdid] [nvarchar](255) NULL,
	[costcentre] [nvarchar](255) NULL,
	[drugfull] [nvarchar](255) NULL,
	[drug_form] [nvarchar](255) NULL,
	[drug_name] [nvarchar](255) NULL,
	[drug_packsize] [nvarchar](255) NULL,
	[drug_strength] [nvarchar](255) NULL,
 CONSTRAINT [PK_wardstock] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Scheduler] ADD  CONSTRAINT [DF_tScheduler_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [dbo].[GetInpatientOrder]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec GetInpatientOrder 'P40'
-- =============================================
CREATE PROCEDURE [dbo].[GetInpatientOrder]
	-- Add the parameters for the stored procedure here
	@lnkpid nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	   SELECT x_med_orders.ID,x_med_orders.drug_description, x_med_orders.surname, x_med_orders.forenames, x_med_orders.hospital_no, 
		x_med_orders.frequency_description, x_med_orders.frequency_code,x_med_orders.ward, 
		x_med_orders.discontinued_by, x_med_orders.order_type, x_med_orders.secondary_dose, 
		x_med_orders.status, x_med_orders.primary_dose_description, x_med_orders.primary_dose, 
		x_med_orders.lnkpid, x_med_orders.current_spell, x_med_orders.prn, x_med_orders.stop_date, 
		x_med_orders.stop_days_doses, x_med_orders.stop_days_doses_flag, x_med_orders.lnkpid, 
		x_med_orders.route, x_med_orders.stat, x_med_orders.stop_date, 
		x_med_orders.prescribing_drug_id, x_med_orders.lnkordid, x_med_orders.lnkpid, x_med_orders.c_alt_dose, 
		x_med_orders.c_bulk

		FROM   actualprescriptionmeds x_med_orders
		WHERE  x_med_orders.status='Active' AND x_med_orders.order_type='Inpatient' 
		AND x_med_orders.discontinued_by IS  NULL  AND x_med_orders.lnkpid=@lnkpid
		ORDER BY x_med_orders.prn, x_med_orders.drug_description
END

GO
/****** Object:  StoredProcedure [dbo].[GetMedicine]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec [dbo].[GetMedicine]  'CARTOON WARD'
-- =============================================
CREATE PROCEDURE [dbo].[GetMedicine] 
	-- Add the parameters for the stored procedure here
	@ward nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select  p.lnkpid, concat(p.forenames, ' ', p.surname) As PatientName, STUFF((SELECT ', ' +'DRUG:-  '+ CAST(m.drug_description AS VARCHAR(10))+ ';  DOSE:-  '+ CAST(m.primary_dose AS VARCHAR(10)) [text()] 
         FROM [dbo].[patientmeds] m	
         WHERE m.lnkpid = p.lnkpid
         FOR XML PATH(''), TYPE)
         .value('.','NVARCHAR(MAX)'),1,2,' ') Medicine_Output,


		 STUFF((SELECT  ', ' + CAST(ma.admin_reason AS VARCHAR(MAX))  [text()]
         FROM [dbo].[MedAdmins] ma
		 INNER JOIN patientmeds pm on ma.lnkordid=pm.lnkordid and ma.lnkpid=pm.lnkpid
         WHERE ma.lnkpid = p.lnkpid 
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') Missed_Output ,


		 STUFF((SELECT  ', ' +c.title, CAST(c.F3 AS VARCHAR(MAX))  [text()]
         FROM [dbo].[clinicalnotes] c
         WHERE c.lnkpid = p.lnkpid
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') Follow_Output ,

		
		 STUFF((SELECT '/' + CAST([Value] AS VARCHAR(MAX)) [text()]
         FROM 
		 ( 
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value] from  verified  where lnkpid=p.lnkpid and status='U' 
		 UNION ALL
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value]  from  verified  where lnkpid=p.lnkpid and status='R' 
		 UNION ALL
		 SELECT CASE WHEN count(v.status) > 0 THEN count(v.status) ELSE 0 END AS [Value]  from  verified v
		 INNER JOIN patientmeds pm on v.lnkordid=pm.lnkordid and v.lnkpid=pm.lnkpid and pm.suspend_date is not null and pm.suspend_time is not null
		 WHERE v.lnkpid=p.lnkpid and v.status='S'
		 ) t    
         FOR XML PATH(''), TYPE)
         .value('.','NVARCHAR(MAX)'),1,1,' ') Screened_Output,
		
		 STUFF((SELECT ', ' + CAST(c.suspend_reason AS VARCHAR(MAX)) [text()]
         FROM [dbo].[patientmeds] c
         WHERE c.lnkpid = p.lnkpid
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') Reason_Output from [dbo].[patients] p where p.ward=@ward		
END
GO
/****** Object:  StoredProcedure [dbo].[MedicationOrders1]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec [dbo].[MedicationOrders1] 'TELE WARD' 
-- =============================================
CREATE PROCEDURE [dbo].[MedicationOrders1] 
	-- Add the parameters for the stored procedure here
	@ward nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here	

	select p.lnkpid, concat(p.forenames, ' ', p.surname) As PatientName, p.hospital_no,a.ward As WardName,a.drug_description, concat(a.primary_dose, ' ', a.primary_dose_description) As Primary_Dose,a.frequency_description,a.route,a.prn,a.stat,a.c_alt_dose,c.title As Nomad_Output, STUFF((SELECT ', ' + CAST(w.drug_packsize AS VARCHAR(10)) [text()]
         FROM [dbo].[wardstock] w
         WHERE w.lnkdid = a.prescribing_drug_id  
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') PackSize_Output,

		STUFF((SELECT ', ' + CAST(a.ward_stock AS VARCHAR(10)) [text()]
         FROM [dbo].[wardstock] w
         WHERE w.lnkdid = a.prescribing_drug_id And a.ward=w.costcentre 
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') WardStock_Output,

		STUFF((SELECT ', ' + CAST(s.speccon_description AS VARCHAR(MAX)) [text()]
         FROM [dbo].[specialconsideration] s
         WHERE s.lnkdid = a.prescribing_drug_id
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') SpecialConsid_Output,	
		
		 STUFF((SELECT '/' + CAST([Value] AS VARCHAR(MAX)) [text()]
         FROM 
		( 
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value] from  verified  where lnkpid=a.lnkpid and status='U' 
		 UNION ALL
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value]  from  verified  where lnkpid=a.lnkpid and status='R' 
		 UNION ALL
		 SELECT CASE WHEN count(v.status) > 0 THEN count(v.status) ELSE 0 END AS [Value]  from  verified v 
		 INNER JOIN patientmeds pm on v.lnkordid=pm.lnkordid and v.lnkpid=pm.lnkpid and pm.suspend_date is not null and pm.suspend_time is not null
		 WHERE v.lnkpid=a.lnkpid and v.status='S'
		 ) t
         FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,1,' ') Screened_Output	
  
		  from [dbo].[clinicalnotes] c, patients p   , [dbo].[actualprescriptionmeds] a where a.lnkpid=p.lnkpid AND c.lnkpid = a.lnkpid And c.lnkspell=0 And c.reason='Medicines Reconciliation / Drug hx' AND  a.ward=@ward;
END
GO
/****** Object:  StoredProcedure [dbo].[MedicationOrders2]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec [dbo].[MedicationOrders2] 'P40'
-- =============================================
CREATE PROCEDURE [dbo].[MedicationOrders2] 
	-- Add the parameters for the stored procedure here
	@lnkpid nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.lnkpid,a.drug_description, concat(a.primary_dose, ' ', a.primary_dose_description) As Primary_Dose,a.frequency_description,a.route,a.prn,a.stat,a.c_alt_dose,c.title As Nomad_Output, STUFF((SELECT ', ' + CAST(w.drug_packsize AS VARCHAR(10)) [text()]
         FROM [dbo].[wardstock] w
         WHERE w.lnkdid = a.prescribing_drug_id
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') PackSize_Output,

		STUFF((SELECT ', ' + CAST(a.ward_stock AS VARCHAR(10)) [text()]
         FROM [dbo].[wardstock] w
         WHERE w.lnkdid = a.prescribing_drug_id And a.ward=w.costcentre
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') WardStock_Output,

		STUFF((SELECT ', ' + CAST(s.speccon_description AS VARCHAR(MAX)) [text()]
         FROM [dbo].[specialconsideration] s
         WHERE s.lnkdid = a.prescribing_drug_id
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') SpecialConsid_Output,
		
		 STUFF((SELECT '/' + CAST([Value] AS VARCHAR(MAX)) [text()]
         FROM 
		( 
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value] from  verified  where lnkpid=a.lnkpid and status='U' 
		 UNION ALL
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value]  from  verified  where lnkpid=a.lnkpid and status='R' 
		 UNION ALL
		 SELECT CASE WHEN count(v.status) > 0 THEN count(v.status) ELSE 0 END AS [Value]  from  verified v 
		 INNER JOIN patientmeds pm on v.lnkordid=pm.lnkordid and v.lnkpid=pm.lnkpid and pm.suspend_date is not null and pm.suspend_time is not null
		 WHERE v.lnkpid=a.lnkpid and v.status='S'
		 ) t
         FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,1,' ') Screened_Output from [dbo].[clinicalnotes] c, [dbo].[actualprescriptionmeds] a where c.lnkpid = a.lnkpid And c.lnkspell=0 And c.reason='Medicines Reconciliation / Drug hx' AND a.lnkpid=@lnkpid
END
GO
/****** Object:  StoredProcedure [dbo].[MedicationOrders3]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec [dbo].[MedicationOrders3] 
-- =============================================
CREATE PROCEDURE [dbo].[MedicationOrders3] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select p.lnkpid, concat(p.forenames, ' ', p.surname) As PatientName, p.hospital_no,a.ward As WardName,a.drug_description, concat(a.primary_dose, ' ', a.primary_dose_description) As Primary_Dose,a.frequency_description,a.route,a.prn,a.stat,a.c_alt_dose,c.title As Nomad_Output, STUFF((SELECT ', ' + CAST(w.drug_packsize AS VARCHAR(10)) [text()]
         FROM [dbo].[wardstock] w
         WHERE w.lnkdid = a.prescribing_drug_id
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') PackSize_Output,

		STUFF((SELECT ', ' + CAST(a.ward_stock AS VARCHAR(10)) [text()]
         FROM [dbo].[wardstock] w
         WHERE w.lnkdid = a.prescribing_drug_id And a.ward=w.costcentre
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') WardStock_Output,

		STUFF((SELECT ', ' + CAST(s.speccon_description AS VARCHAR(MAX)) [text()]
         FROM [dbo].[specialconsideration] s
         WHERE s.lnkdid = a.prescribing_drug_id
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') SpecialConsid_Output,
		
		 STUFF((SELECT '/' + CAST([Value] AS VARCHAR(MAX)) [text()]
         FROM 
		( 
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value] from  verified  where lnkpid=a.lnkpid and status='U' 
		 UNION ALL
		 SELECT CASE WHEN count(status) > 0 THEN count(status) ELSE 0 END AS [Value]  from  verified  where lnkpid=a.lnkpid and status='R' 
		 UNION ALL
		 SELECT CASE WHEN count(v.status) > 0 THEN count(v.status) ELSE 0 END AS [Value]  from  verified v 
		 INNER JOIN patientmeds pm on v.lnkordid=pm.lnkordid and v.lnkpid=pm.lnkpid and pm.suspend_date is not null and pm.suspend_time is not null
		 WHERE v.lnkpid=a.lnkpid and v.status='S'
		 ) t
         FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,1,' ') Screened_Output	
  
		 from [dbo].[clinicalnotes] c , patients p   , [dbo].[actualprescriptionmeds] a where c.lnkpid = a.lnkpid And c.lnkspell=0 And c.reason='Medicines Reconciliation / Drug hx' AND a.lnkpid=p.lnkpid
END
GO
/****** Object:  StoredProcedure [dbo].[WardPage]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec WardPage 'CARTOON WARD'
-- =============================================
CREATE PROCEDURE [dbo].[WardPage] 
	-- Add the parameters for the stored procedure here
		@ward nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	   select  p.lnkpid, concat(p.forenames, ' ', p.surname) As PatientName,p.hospital_no, p.ward, p.group_code, p.current_spell, STUFF((SELECT ', ' + CAST(m.drug_description AS VARCHAR(10)) [text()]
         FROM [dbo].[patientmeds] m	
         WHERE m.lnkpid = p.lnkpid 
         FOR XML PATH(''), TYPE)
         .value('.','NVARCHAR(MAX)'),1,2,' ') Medicine_Output,

		 	 STUFF((SELECT ', ' + CAST(bn.c_bnf_code AS VARCHAR(MAX))  [text()]
         FROM [dbo].[bnfcodes] bn		
         WHERE bn.lnkdid = pm.prescribing_drug_id AND  bn.lnkdid  LIKE 'D%'
         FOR XML PATH(''), TYPE)
        .value('.','NVARCHAR(MAX)'),1,2,' ') BNF_Output 
		 FROM patients p ,patientmeds pm where p.ward=@ward AND pm.lnkpid=p.lnkpid 
END
GO
/****** Object:  StoredProcedure [dbo].[WardStockList]    Script Date: 05/15/18 6:28:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- exec WardStockList 'TELE WARD'
-- =============================================
CREATE PROCEDURE [dbo].[WardStockList]
	-- Add the parameters for the stored procedure here
	@WardName nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT wardstock.lnkdid, wardstock.costcentre, wardstock.drugfull, wardstock.drug_form, wardstock.drug_name, wardstock.drug_packsize, wardstock.drug_strength
FROM wardstock
WHERE wardstock.costcentre = @WardName
END
GO
