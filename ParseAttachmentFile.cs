namespace EmailParser
{
    public class ParseAttachmentFile
    {
        public  ParseAttachmentFile(string fileName)
        {

        }

    }

    public class VesselReportDto
    {
        public string vessel_category { get; set; }
        public string version { get; set; }
        public string template_version { get; set; }
        public string report_recipient { get; set; }
        public string report_type { get; set; }
        public string ksmName { get; set; }
        public string ksmISMNo { get; set; }
        public string MasterName { get; set; }
        public string ChiefMateName { get; set; }
        public string ChiefEngineerName { get; set; }
        public string ksmVoyageID { get; set; }
        public string voyageCPDate { get; set; }
        public string MessageDate { get; set; }
        public string MessageTime { get; set; }
        public string ksmTimeZone { get; set; }
        public string slowSteamReasonListed { get; set; }
        public string slowSteamReasonOther { get; set; }
        public string slowStemReason { get; set; }
        public string slowSteamComment { get; set; }
        public string ksmVoyageCharterer { get; set; }
        public string otherCharterer { get; set; }
        public string agent { get; set; }
        public string otherAgent { get; set; }
        public string AgentPIC { get; set; }
        public string AgentTelephone { get; set; }
        public string VoyageLegNumber { get; set; }
        public string ksmBallastOrLaden { get; set; }
        public string ksmVoyageOrderedSpeed { get; set; }
        public string ksmVoyageAvgSpeed { get; set; }
        public string voyageOrderedCons { get; set; }
        public string previousPortSailingDate { get; set; }
        public string previousPortSailingTime { get; set; }
        public string previousPortField { get; set; }
        public string OtherPreviousPort { get; set; }
        public string NextPortETA { get; set; }
        public string NextPortETATime { get; set; }
        public string ksmNextPort { get; set; }
        public string OtherNextPort { get; set; }
        public string NextPortETADateLT { get; set; }
        public string nextPortETATimeInLT { get; set; }
        public string NextPortETADateGMT { get; set; }
        public string NextPortETATimeGMT { get; set; }
        public string DTG { get; set; }
        public string previousPortharbourDistanceOut { get; set; }
        public string previousPortHarbourDistanceIn { get; set; }
        public string LegLatitudeDegreeAtEnd { get; set; }
        public string LegLatitudeMnsAtEnd { get; set; }
        public string LegLatitudeDirectionAtEnd { get; set; }
        public string LegLongiudeDegreeAtEnd { get; set; }
        public string LegLongitudeMnsAtEnd { get; set; }
        public string LegLongitudeDirectionAtEnd { get; set; }
        public string LegLatituteDegreeAtStart { get; set; }
        public string LegLatitudeMnsAtStart { get; set; }
        public string LegLatitudeDirectionAtStart { get; set; }
        public string LegLongitudeDegreeAtStart { get; set; }
        public string LegLongitudeMnsAtStart { get; set; }
        public string LegLongitudeDirectionAtStart { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ksmCurrentLatitudeDegree { get; set; }
        public string ksmCurrentLatitudeMins { get; set; }
        public string LatitudeDirection { get; set; }
        public string ksmCurrentLongitudeDegree { get; set; }
        public string ksmCurrentLongitudeMins { get; set; }
        public string LongitudeDirection { get; set; }
        public string runningTimeinHours { get; set; }
        public string ksmRPM { get; set; }
        public string RunningTimeInMinutes { get; set; }
        public string ksmTrueDistance { get; set; }
        public string PropellerSlip { get; set; }
        public string ksmSpeed { get; set; }
        public string csmAvgMEPower { get; set; }
        public string ksmDirectionWind { get; set; }
        public string ksmWindForce { get; set; }
        public string ksmDirectionSea { get; set; }
        public string ksmSeaState { get; set; }
        public string ksmDirectionCurrent { get; set; }
        public string ksmCurrentSpeed { get; set; }
        public IList<string> BunkerActivity { get; set; }
        public IList<string> EngineType { get; set; }
        public IList<string> FuelType { get; set; }
        public IList<string> Consumption { get; set; }
        public IList<string> Power { get; set; }
        public IList<string> AverageRPM { get; set; }
        public IList<string> RunningHours { get; set; }
        public IList<string> StartDatetime { get; set; }
        public IList<string> EndDatetime { get; set; }
        public string ME1 { get; set; }
        public string ME2 { get; set; }
        public string ME3 { get; set; }
        public string ME4 { get; set; }
        public string AE1 { get; set; }
        public string AE2 { get; set; }
        public string AE3 { get; set; }
        public string AE4 { get; set; }
        public string AE5 { get; set; }
        public string AE6 { get; set; }
        public string AEOtherReason { get; set; }
        public string BoilerReason { get; set; }
        public string ksmROBCOSPFO { get; set; }
        public string ksmROBCOSPVLSFO { get; set; }
        public string ksmROBCOSPLSFO { get; set; }
        public string ksmROBCOSPGO { get; set; }
        public string ksmROBCOSPLSGO { get; set; }
        public string ksmROBCOSPLNG { get; set; }
        public string ksmROBCOSPFW { get; set; }
        public string csmMESystemLubOil { get; set; }
        public string csmMECylinderLubOilHS { get; set; }
        public string csmMECylinderLubOilLS { get; set; }
        public string csmAELubOilL { get; set; }
        public string SW_FWD { get; set; }
        public string SW_AFT { get; set; }
        public string Deadweight { get; set; }
        public string Slops { get; set; }
        public string OilSlops { get; set; }
        public string WaterSlops { get; set; }
        public string ScrubberStartDatetime { get; set; }
        public string ScrubberEndDatetime { get; set; }
        public string Temperature { get; set; }
        public string StoppagesAtSeaReason { get; set; }
        public string remarks { get; set; }

    }
}
