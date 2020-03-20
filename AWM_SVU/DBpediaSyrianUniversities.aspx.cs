using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using VDS.RDF;
using VDS.RDF.Query;
using VDS.RDF.Parsing;
using VDS.RDF.Update;
using VDS.RDF.Update.Commands;
using VDS.RDF.Query.Patterns;
using VDS.RDF.Query.Datasets;
using VDS.RDF.Configuration;
using VDS.RDF.Web;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;
using HtmlAgilityPack;

public partial class _Default : System.Web.UI.Page
{
    public static DataTable FillDataTable(SparqlResultSet Results)
    {
        SparqlResult resultt = new SparqlResult();
        DataTable DT = new DataTable();
        if (Results.Results.Count > 0)
        {
            resultt = Results.Results[0];
            for (int i = 0; i < resultt.Variables.ToList().Count; i++)
                DT.Columns.Add(resultt.Variables.ToList()[i], typeof(String));
        }
        foreach (SparqlResult result in Results)
        {
            DataRow DR = DT.NewRow();
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == null)
                    DR[i] = "";
                else if (result[i].NodeType == NodeType.Uri)
                    DR[i] = ((UriNode)result[i]).Uri;
                else if (result[i].NodeType == NodeType.Blank)
                    DR[i] = ((BlankNode)result[i]).InternalID.ToString();
                else if (result[i].NodeType == NodeType.Literal)
                    DR[i] = ((LiteralNode)result[i]).Value.ToString();
            }
            DT.Rows.Add(DR);
        }
        return (DT);
    }







    protected void Page_Load(object sender, EventArgs e)
    {
        //Label1.Text = "Press on one button to get University information from DBpedia endPoint";
        //Label1.Visible = true;
        //GridView1.Visible = false;
        SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        string q = @"PREFIX dct: <http://purl.org/dc/terms/> 
                                                                PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>   
                                                                PREFIX  foaf:  <http://xmlns.com/foaf/0.1/> 
                                                                PREFIX  ont:  <http://dbpedia.org/ontology/>
                                                                SELECT DISTINCT    ?AllSyrianUniversities    WHERE {    
                                                                ?AllSyrianUniversities dct:subject <http://dbpedia.org/resource/Category:Universities_in_Syria>.   
                                                              }";

        //Make a SELECT query against the Endpoint
        SparqlResultSet results = endpoint.QueryWithResultSet(q);
        DataTable DT1 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT1 = FillDataTable(rset);
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    { 
        Label1.Visible = false;
        Label2.Visible = false;
        GridView2.Visible = false;
        //Define a remote endpoint
        //Use the DBPedia SPARQL endpoint with the default Graph set to DBPedia
        SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        string q = @"PREFIX dct: <http://purl.org/dc/terms/> 
                                                                PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>   
                                                                PREFIX  foaf:  <http://xmlns.com/foaf/0.1/> 
                                                                PREFIX  ont:  <http://dbpedia.org/ontology/>
                                                                SELECT DISTINCT    ?AllSyrianUniversities    WHERE {    
                                                                ?AllSyrianUniversities dct:subject <http://dbpedia.org/resource/Category:Universities_in_Syria>.   
                                                              }";

        //Make a SELECT query against the Endpoint
        SparqlResultSet results = endpoint.QueryWithResultSet(q);
        DataTable DT1 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT1 = FillDataTable(rset);
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //Higher Institute for Applied Sciences and Technology
        Label1.Text = "	Higher Institute for Applied Sciences and Technology English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?dir)as ?director )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Higher_Institute_for_Applied_Sciences_and_Technology> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Higher_Institute_for_Applied_Sciences_and_Technology> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  OPTIONAL {
                                                                  <http://dbpedia.org/resource/Higher_Institute_for_Applied_Sciences_and_Technology> dbp:director ?dir.
                                                                  <http://dbpedia.org/resource/Higher_Institute_for_Applied_Sciences_and_Technology> foaf:homepage ?homepage .            
                                                                            }
                                                                        }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Text = "Higher Institute for Applied Sciences and Technology Arabic Information";
        Label2.Visible = true;
        SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results2 = endpoint2.QueryWithResultSet(@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?Name  ?Information
                                                                  WHERE {
                                                                   <http://dbpedia.org/resource/Higher_Institute_for_Applied_Sciences_and_Technology> rdfs:comment ?Information.filter langMatches(lang(?Information),'ar'). 
                                                                   <http://dbpedia.org/resource/Higher_Institute_for_Applied_Sciences_and_Technology> rdfs:label ?Name.filter langMatches(lang(?Name),'ar').           
                                                                  }");
        DataTable DT2 = new DataTable();
        if (results2 is SparqlResultSet)
        {
            SparqlResultSet rset2 = (SparqlResultSet)results2;
            DT2 = FillDataTable(rset2);
        }
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //SVU
        Label1.Text = "Syrian Virtual University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president ) ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Syrian_Virtual_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Syrian_Virtual_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  OPTIONAL {
                                                                  <http://dbpedia.org/resource/Syrian_Virtual_University> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/Syrian_Virtual_University> foaf:homepage ?homepage .            
                                                                            }
                                                                    }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;

        Label2.Text = "Syrian Virtual University Arabic Information";
        Label2.Visible = true;
        SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results2 = endpoint2.QueryWithResultSet(@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?Name  ?Information
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Syrian_Virtual_University> rdfs:comment ?Information.filter langMatches(lang(?Information),'ar'). 
                                                                  <http://dbpedia.org/resource/Syrian_Virtual_University> rdfs:label ?Name.filter langMatches(lang(?Name),'ar').           
                                                                     }");
        DataTable DT2 = new DataTable();
        if (results2 is SparqlResultSet)
        {
            SparqlResultSet rset2 = (SparqlResultSet)results2;
            DT2 = FillDataTable(rset2);
        }
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        //albaath
        Label1.Text = "Al-Baath University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Al-Baath_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Al-Baath_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                   OPTIONAL {
                                                                  <http://dbpedia.org/resource/Al-Baath_University> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/Al-Baath_University> foaf:homepage ?homepage .            
                                                                     }
                                                                         }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Text = "Al-Baath University Arabic Information";
        Label2.Visible = true;
        SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results2 = endpoint2.QueryWithResultSet(@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?Name  ?Information
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Al-Baath_University> rdfs:comment ?Information.filter langMatches(lang(?Information),'ar'). 
                                                                  <http://dbpedia.org/resource/Al-Baath_University> rdfs:label ?Name.filter langMatches(lang(?Name),'ar').           
                                                                    }");
        DataTable DT2 = new DataTable();
        if (results2 is SparqlResultSet)
        {
            SparqlResultSet rset2 = (SparqlResultSet)results2;
            DT2 = FillDataTable(rset2);
        }
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        //teshreen
        Label1.Text = "Tishreen University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president ) (str(?typ )as ?type) ?homepage
                                                                  WHERE {
                                                                 <http://dbpedia.org/resource/Tishreen_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                 <http://dbpedia.org/resource/Tishreen_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  OPTIONAL {
                                                                 <http://dbpedia.org/resource/Tishreen_University> dbp:president ?Pr .
                                                                 <http://dbpedia.org/resource/Tishreen_University> dbp:type ?typ .
                                                                 <http://dbpedia.org/resource/Tishreen_University> foaf:homepage ?homepage .            
                                                                     }
                                                                       }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;



        Label2.Text = "Tishreen University Arabic Information";
        Label2.Visible = true;
        SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results2 = endpoint2.QueryWithResultSet(@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?Name  ?Information
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Tishreen_University> rdfs:comment ?Information.filter langMatches(lang(?Information),'ar'). 
                                                                  <http://dbpedia.org/resource/Tishreen_University> rdfs:label ?Name.filter langMatches(lang(?Name),'ar').           
                                                                  }");
        DataTable DT2 = new DataTable();
        if (results2 is SparqlResultSet)
        {
            SparqlResultSet rset2 = (SparqlResultSet)results2;
            DT2 = FillDataTable(rset2);
        }
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        //Aleppo

        Label1.Text = "Aleppo University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/University_of_Aleppo> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/University_of_Aleppo> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  OPTIONAL { <http://dbpedia.org/resource/University_of_Aleppo> dbp:president ?Pr .}
                                                                  OPTIONAL {  <http://dbpedia.org/resource/University_of_Aleppo> foaf:homepage ?homepage .            
                                                                            }
                                                                              }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Text = "Aleppo University Arabic Information";
        Label2.Visible = true;
        SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results2 = endpoint2.QueryWithResultSet(@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                SELECT  DISTINCT    ?Name  ?Information
                                                                WHERE {
                                                                <http://dbpedia.org/resource/University_of_Aleppo> rdfs:comment ?Information.filter langMatches(lang(?Information),'ar'). 
                                                                <http://dbpedia.org/resource/University_of_Aleppo> rdfs:label ?Name.filter langMatches(lang(?Name),'ar').           
                                                                  }");
        DataTable DT2 = new DataTable();
        if (results2 is SparqlResultSet)
        {
            SparqlResultSet rset2 = (SparqlResultSet)results2;
            DT2 = FillDataTable(rset2);
        }
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        //Al-Furat
        Label1.Text = "Al-Furat University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Al-Furat_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Al-Furat_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  optional {
                                                                  <http://dbpedia.org/resource/Al-Furat_University> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/Al-Furat_University> foaf:homepage ?homepage .            
                                                                            }
                                                                    }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;

        Label2.Text = "Al-Furat University Arabic Information";
        Label2.Visible = true;
        SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results2 = endpoint2.QueryWithResultSet(@"PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?Name  ?Information
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Al-Furat_University> rdfs:comment ?Information.filter langMatches(lang(?Information),'ar'). 
                                                                  <http://dbpedia.org/resource/Al-Furat_University> rdfs:label ?Name.filter langMatches(lang(?Name),'ar').           
                                                                     }");
        DataTable DT2 = new DataTable();
        if (results2 is SparqlResultSet)
        {
            SparqlResultSet rset2 = (SparqlResultSet)results2;
            DT2 = FillDataTable(rset2);
        }
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
    }
    ///////////////////////////////////////////////////
    //Private Universities
    /// <summary>
    /// //////////////////////////////////////////////
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button9_Click(object sender, EventArgs e)
    {
        //IUST
        Label1.Text = "International University for Science and Technology English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/International_University_for_Science_and_Technology> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/International_University_for_Science_and_Technology> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                 optional {
                                                                  <http://dbpedia.org/resource/International_University_for_Science_and_Technology> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/International_University_for_Science_and_Technology> foaf:homepage ?homepage .            
                                                                      }}");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Visible = false;
        GridView2.Visible = false;
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        //AIU
        Label1.Text = "Arab International University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Arab_International_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Arab_International_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  optional {
                                                                  <http://dbpedia.org/resource/Arab_International_University> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/Arab_International_University> foaf:homepage ?homepage .            
                                                                     }
                                                                           }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Visible = false;
        GridView2.Visible = false;
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        //SPU
        Label1.Text = "Syrian_Private_University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Syrian_Private_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Syrian_Private_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  <http://dbpedia.org/resource/Syrian_Private_University> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/Syrian_Private_University> foaf:homepage ?homepage .            
                                                                     }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Visible = false;
        GridView2.Visible = false;
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        //Yarmouk_Private_University
        Label1.Text = "Yarmouk_Private_University English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info  ?homepage
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/Yarmouk_Private_University> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Yarmouk_Private_University> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  <http://dbpedia.org/resource/Yarmouk_Private_University> foaf:homepage ?homepage .            
                                                                         } ");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Visible = false;
        GridView2.Visible = false;
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        //Kalamoon
        Label1.Text = "University of Kalamoon  English Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info 
                                                                  WHERE {
                                                                  <http://dbpedia.org/resource/University_of_Kalamoon> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/University_of_Kalamoon> rdfs:label ?name.filter langMatches(lang(?name),'en').          
                                                                      }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Visible = false;
        GridView2.Visible = false;

    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        //Alandalus
        Label1.Text = "Al-Andalus University for Medical Sciences Information";
        Label1.Visible = true;
        SparqlRemoteEndpoint endpoint1 = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"), "http://dbpedia.org");
        SparqlResultSet results1 = endpoint1.QueryWithResultSet(@"PREFIX dbo: <http://dbpedia.org/ontology/> 
                                                                  PREFIX dbp: <http://dbpedia.org/property/> 
                                                                  PREFIX dbr: <http://dbpedia.org/resource/>
                                                                  PREFIX foaf: <http://xmlns.com/foaf/0.1/>
                                                                  PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                                  SELECT  DISTINCT    ?name  ?info (str(?Pr)as ?president )  ?homepage
                                                                  WHERE 
                                                                  {
                                                                  <http://dbpedia.org/resource/Al-Andalus_University_for_Medical_Sciences> rdfs:comment ?info.filter langMatches(lang(?info),'en'). 
                                                                  <http://dbpedia.org/resource/Al-Andalus_University_for_Medical_Sciences> rdfs:label ?name.filter langMatches(lang(?name),'en').
                                                                  <http://dbpedia.org/resource/Al-Andalus_University_for_Medical_Sciences> dbp:president ?Pr .
                                                                  <http://dbpedia.org/resource/Al-Andalus_University_for_Medical_Sciences> foaf:homepage ?homepage .            
                                                                      }");
        DataTable DT1 = new DataTable();
        if (results1 is SparqlResultSet)
        {
            SparqlResultSet rset1 = (SparqlResultSet)results1;
            DT1 = FillDataTable(rset1);
        }
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        Label2.Visible = false;
        GridView2.Visible = false;
    }
} 
    
    
 