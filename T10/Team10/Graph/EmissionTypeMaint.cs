using System;
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PX.Data;
using PX.Data.BQL.Fluent;

namespace Team10
{
  public class EmissionTypeMaint : PXGraph<EmissionTypeMaint, EmissionType>
  {
        public PXSelect<EmissionType> Emission; 

        public PXSelect<EmissionType,
            Where<EmissionType.emissionID, Equal<Current<EmissionType.emissionID>>>>
            CurrentEmission;

        [PXCopyPasteHiddenView]
        public PXSelect<EmissionTran,
            Where<EmissionTran.emissionID, Equal<Current<EmissionType.emissionID>>>>
            Transaction;

        public EmissionType MyEmissionType = new EmissionType();

        public System.Timers.Timer timer = new System.Timers.Timer(200);

        public PXAction<EmissionType> makeApi;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Make Api Call", Enabled = true, Visible = true)]
        public virtual IEnumerable MakeApi(PXAdapter adapter)
        {
            Save.Press();
            // Acuminator disable once PX1008 LongOperationDelegateSynchronousExecution [Justification]
            PXLongOperation.StartOperation(this, delegate
            {
                //getCo2e(Emission.Current);
                getCo2e();
            });



            return adapter.Get();
        }

        //private async Task<EmissionType> getCo2e(EmissionType header)
        //private async void getCo2e()
        //{
        //    EmissionType header = Emission.Current;
        //    HttpClient client = new HttpClient();
        //    Request req = new Request
        //    {
        //        emissionfactor = new Emissionfactor
        //        {
        //            activity_id = header.ActivityID/*"electrical_equipment-type_it_primary_material_production"*/,
        //            source = header.Source/*"BEIS"*/,
        //            year = header.Year.GetValueOrDefault(0)/*2023*/,
        //            region = header.RegionName/*"GB"*/,
        //            version = "8.8"
        //        },
        //        parameter = new Parameter
        //        {
        //            param = "weight"
        //        }
        //    };

        //    string requestBody = String.Format("{{\"emission_factor\": {{\"activity_id\": \"{0}\",\"source\": \"{1}\",\"region\": \"{2}\",\"year\": {3},\"data_version\": \"{4}\"}},\"parameters\": {{\"{5}\": 1}}}}",
        //        req.emissionfactor.activity_id,
        //             req.emissionfactor.source,
        //             req.emissionfactor.region,
        //             req.emissionfactor.year,
        //             req.emissionfactor.version,
        //             req.parameter.param);

        //    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://beta4.api.climatiq.io/estimate"));
        //    //request.Headers.Add("Authorization", "Bearer XZN6MMVERAMDBSQJKKHN8YAV5BNC");
        //    request.Headers.Add("Authorization", "Bearer WZ3PD445YRMW68KKXZEDKEPRBRDQ");
        //    request.Content = new StringContent(requestBody as string, Encoding.UTF8);

        //    var response = await client.SendAsync(request);
        //    string res = await response.Content.ReadAsStringAsync();

        //    //var response = client.SendAsync(request);
        //    //string res = response.Content.ReadAsStringAsync();

        //    Response resp = JsonConvert.DeserializeObject<Response>(res);

        //    //EmissionTypeMaint graph = PXGraph.CreateInstance<EmissionTypeMaint>();

        //    //graph.Emission.Current = graph.Emission.Search<EmissionType.emissionID>(header.EmissionID);


        //    //EmissionType et = (EmissionType) graph.Emission.Cache.CreateCopy(header);
        //    //et.Name = resp.emission_factor.name;
        //    //et.Category = resp.emission_factor.category;
        //    //et.Co2e = resp.co2e;
        //    //et.Co2eUnit = resp.co2e_unit;

        //    //graph.Emission.Update(et);
        //    //graph.Save.Press();

        //    //PXRedirectRequiredException ex = new PXRedirectRequiredException(graph, "");
        //    //return null;

        //    CurrentEmission.Cache.SetValueExt<EmissionType.name>(CurrentEmission.Current, resp.emission_factor.name);
        //    CurrentEmission.Cache.SetValueExt<EmissionType.category>(CurrentEmission.Current, resp.emission_factor.category);
        //    //CurrentEmission.SetValueExt<EmissionType.sector>(CurrentEmission.Current, null);
        //    //CurrentEmission.SetValueExt<EmissionType.description>(CurrentEmission.Current, null);
        //    //CurrentEmission.SetValueExt<EmissionType.unit>(CurrentEmission.Current, null);
        //    CurrentEmission.Cache.SetValueExt<EmissionType.co2e>(CurrentEmission.Current, resp.co2e);
        //    CurrentEmission.Cache.SetValueExt<EmissionType.co2eUnit>(CurrentEmission.Current, resp.co2e_unit);
        //    //Emission.Current.Co2eUnit = resp.co2e_unit;
        //    CurrentEmission.Cache.Update(Emission.Current);
        //    //CurrentEmission.View.Clear();
        //    CurrentEmission.View.RequestRefresh();
        //}



        private async void getCo2e()
        {
            EmissionType header = Emission.Current;
            HttpClient client = new HttpClient();
            Request req = new Request
            {
                emissionfactor = new Emissionfactor
                {
                    activity_id = header.ActivityID/*"electrical_equipment-type_it_primary_material_production"*/,
                    source = header.Source/*"BEIS"*/,
                    year = header.Year.GetValueOrDefault(0)/*2023*/,
                    region = header.RegionName/*"GB"*/,
                    version = "8.8"
                },
                parameter = new Parameter
                {
                    param = "weight"
                }
            };

            string requestBody = String.Format("{{\"emission_factor\": {{\"activity_id\": \"{0}\",\"source\": \"{1}\",\"region\": \"{2}\",\"year\": {3},\"data_version\": \"{4}\"}},\"parameters\": {{\"{5}\": 1}}}}",
                req.emissionfactor.activity_id,
                     req.emissionfactor.source,
                     req.emissionfactor.region,
                     req.emissionfactor.year,
                     req.emissionfactor.version,
                     req.parameter.param);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://beta4.api.climatiq.io/estimate"));
            //request.Headers.Add("Authorization", "Bearer XZN6MMVERAMDBSQJKKHN8YAV5BNC");
            request.Headers.Add("Authorization", "Bearer WZ3PD445YRMW68KKXZEDKEPRBRDQ");
            request.Content = new StringContent(requestBody as string, Encoding.UTF8);

            var response = await client.SendAsync(request).ConfigureAwait(false);
            string res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            //var response = client.SendAsync(request);
            //string res = response.Content.ReadAsStringAsync();

            Response resp = JsonConvert.DeserializeObject<Response>(res);

            //EmissionTypeMaint graph = PXGraph.CreateInstance<EmissionTypeMaint>();

            //graph.Emission.Current = graph.Emission.Search<EmissionType.emissionID>(header.EmissionID);


            //EmissionType et = (EmissionType) graph.Emission.Cache.CreateCopy(header);
            //et.Name = resp.emission_factor.name;
            //et.Category = resp.emission_factor.category;
            //et.Co2e = resp.co2e;
            //et.Co2eUnit = resp.co2e_unit;

            //graph.Emission.Update(et);
            //graph.Save.Press();

            //PXRedirectRequiredException ex = new PXRedirectRequiredException(graph, "");
            //return null;

            EmissionTypeMaint graph = PXGraph.CreateInstance<EmissionTypeMaint>();

            graph.Emission.Current = this.Emission.Current;
            EmissionType emitype = graph.CurrentEmission.Current;

            emitype.Name = resp.emission_factor.name;
            emitype.Category = resp.emission_factor.category;
            emitype.Co2e = resp.co2e;
            emitype.Co2eUnit = resp.co2e_unit;

            graph.CurrentEmission.Update(emitype);
            graph.Save.Press();



            //CurrentEmission.Cache.SetValueExt<EmissionType.name>(CurrentEmission.Current, resp.emission_factor.name);
            //CurrentEmission.Cache.SetValueExt<EmissionType.category>(CurrentEmission.Current, resp.emission_factor.category);
            ////CurrentEmission.SetValueExt<EmissionType.sector>(CurrentEmission.Current, null);
            ////CurrentEmission.SetValueExt<EmissionType.description>(CurrentEmission.Current, null);
            ////CurrentEmission.SetValueExt<EmissionType.unit>(CurrentEmission.Current, null);
            //CurrentEmission.Cache.SetValueExt<EmissionType.co2e>(CurrentEmission.Current, resp.co2e);
            //CurrentEmission.Cache.SetValueExt<EmissionType.co2eUnit>(CurrentEmission.Current, resp.co2e_unit);
            ////Emission.Current.Co2eUnit = resp.co2e_unit;
            //CurrentEmission.Cache.Update(Emission.Current);
            ////CurrentEmission.View.Clear();
            Emission.View.Clear();
            Emission.View.RequestRefresh();
            CurrentEmission.View.Clear();
            CurrentEmission.View.RequestRefresh();
        }


        public class Emissionfactor
        {
            public string activity_id;
            public string source;
            public int year;
            public string region;
            public string version;

            public string name;
            public string id;
            public string access_type;
            public string source_dataset;
            public string category;
            public string source_lca_activity;

        }
        public class Parameter
        {
            public string param;
        }
        public class Request
        {
            public Emissionfactor emissionfactor;
            public Parameter parameter;
        }
        public class Response
        {
            //public string co2e;
            public decimal? co2e;
            public string co2e_unit;
            public string co2e_calculation_method;
            public string co2e_calculation_origin;
            public Emissionfactor emission_factor;
            public Constituent constituent_gases;
            public Activity_data activity_data;

            public string audit_trail;
        }
        public class Constituent
        {
            public string co2e_total;
            public string co2e_other;
            public string co2;
            public string ch4;
            public string n2o;

        }
        public class Activity_data
        {
            public string activity_value;
            public string activity_unit;

        }

    }

}