using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{/// <summary>
/// this class calculate the distance and and the time between two addreses with "backgroundWorker" thread.
/// we load the data of the addreses with "WebRequest" from "MapQuest".
/// at "lbl_imp.cp"  at the function ""  public List<Tester> testersInTheArae(BE.Address add)"
/// we  will use the infromation here in order to determine whthere the tester is live near the student`s home.
/// </summary>
    public class CalculateDistanceAndTimeThread
    {
        #region fields
        private string time; // the driving time from one address to other
        private double distanceInKM; //the distance between two addreses
        private BE.Address Destanion;
        private BE.Address source;
        private string responsereader; // the path to our specific WebRequest
        private int MaxWebRequests=10; // the maximum of webRequests
        private string messToSender = null; // message to the sender in order to understand the resualt of the Thread

        public BackgroundWorker worker;

        #endregion
        #region ctor
        public CalculateDistanceAndTimeThread(BE.Address _source, BE.Address _destanion)
        {
            source = _source;
            Destanion = _destanion;
            this.findTimeAndDistance(_source,_destanion);
        }
        #endregion
        #region Properties
        public double DistanceInKM { get => distanceInKM; }
        public string Time { get => time; }
        public string MessToSender { get => messToSender; }
        #endregion
        public void findTimeAndDistance(BE.Address _source, BE.Address _destanion)
        {
           
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerAsync(); // start the excution of background therad.
        }

       public void Worker_DoWork(object sender, DoWorkEventArgs e)
       {
            string origin = source.StreetName + ""+source.NumberOfBuilding+ " st."+source.City;
            //for example: string origin = "pisga 45 st. jerusalem";
            string destination = Destanion.StreetName + "" + Destanion.NumberOfBuilding + " st." + Destanion.City;
            //for ecample: string destination = "gilgal 78 st. ramat-gan";

            string KEY = @"6TRhTD6UF02ilSY1EiGrBBcUgeithVmK"; // key to mapquest service

            string url = @"https://www.mapquestapi.com/directions/v2/route" + @"?key=" + KEY +
            @"&from=" + origin + @"&to=" + destination + @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";

            //request from MapQuest service the distance between the 2 addresses 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            responsereader = sreader.ReadToEnd();
            response.Close();
        }

        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
            //this function not in use at this example
       }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //the response is given in an XML format 
            XmlDocument xmldoc = new XmlDocument();
            int counterRequests = 0;
            try
            {
                while (counterRequests < MaxWebRequests)
                {
                    xmldoc.LoadXml(responsereader);
                    if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
                    //we have the expected answer
                    {
                        //display the returned distance
                        XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                        double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                        distanceInKM = distInMiles * 1.609344;

                        //display the returned driving time
                        XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                        time = formattedTime[0].ChildNodes[0].InnerText;

                        counterRequests = MaxWebRequests; //exit from "while" loop
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(2000); // wating two second until the next request
                        counterRequests++;
                    }
                }
            }
            catch (Exception ex)
            {
                if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
                    messToSender = " an error occurred, one of the addresses is not found";
                else
                    messToSender = "We have'nt got an answer, maybe the net is busy";
            }
            worker.CancelAsync(); // Cancel the asynchronous  background thread operation.
        }
    }
}
