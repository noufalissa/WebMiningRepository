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
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "there is three types of programs at Syrian Virtual University";
        Label1.Visible = true;
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        TripleStore store = new TripleStore();
        store.Add(g1);
        //Assume that we fill our Store with data from somewhere

        //Create a dataset for our queries to operate over
        //We need to explicitly state our default graph or the unnamed graph is used
        //Alternatively you can set the second parameter to true to use the union of all graphs
        //as the default graph
        InMemoryDataset ds = new InMemoryDataset(store);

        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);

        //Use the SparqlQueryParser to give us a SparqlQuery object
        //Should get a Graph back from a CONSTRUCT query
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                           prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                                                           prefix owl: <http://www.w3.org/2002/07/owl#>
                                                           SELECT   ?ProgramName 
                                                           WHERE {
                                                           ?t   owl:StudyingAtSVU ?ProgramName 
                                                        }");
        Object results = processor.ProcessQuery(query);
        DataTable DT1 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT1 = FillDataTable(rset);
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;


        // to select Bachelor Programs
        Label2.Text = "Bachelor Programs At SVU";
        Label2.Visible = true;
        SparqlQueryParser sparqlparser2 = new SparqlQueryParser();
        SparqlQuery query2 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                 prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                 prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT ?BachelorPrograms
                WHERE {
                ?t   owl:BachelorProgramAtSVU ?BachelorPrograms
                }");
        Object results2 = processor.ProcessQuery(query2);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset2 = (SparqlResultSet)results2;
        DT2 = FillDataTable(rset2);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;

        // to select Master Programs
        Label3.Text = "Master Programs At SVU";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT ?MasterPrograms 
                WHERE {
                ?t   owl:MasterProgramAtSVU ?MasterPrograms 
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;

        // to select Training Programs
        Label4.Text = "Training Programs At SVU";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?TrainingPrograms 
                WHERE {
                ?t   owl:TrainingProgramAtSVU ?TrainingPrograms 
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "there is three types of programs at Syrian Virtual University";
        Label1.Visible = true;
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        TripleStore store = new TripleStore();
        store.Add(g1);
        //Assume that we fill our Store with data from somewhere

        //Create a dataset for our queries to operate over
        //We need to explicitly state our default graph or the unnamed graph is used
        //Alternatively you can set the second parameter to true to use the union of all graphs
        //as the default graph
        InMemoryDataset ds = new InMemoryDataset(store);

        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);

        //Use the SparqlQueryParser to give us a SparqlQuery object
        //Should get a Graph back from a CONSTRUCT query
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                           prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                                                           prefix owl: <http://www.w3.org/2002/07/owl#>
                                                           SELECT   ?ProgramName 
                                                           WHERE {
                                                           ?t   owl:StudyingAtSVU ?ProgramName 
                                                        }");
        Object results = processor.ProcessQuery(query);
        DataTable DT1 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT1 = FillDataTable(rset);
        GridView1.DataSource = DT1;
        GridView1.DataBind();
        GridView1.Visible = true;
        // to select Bachelor Programs
        Label2.Text = "Bachelor Programs At SVU";
        Label2.Visible = true;
        SparqlQueryParser sparqlparser2 = new SparqlQueryParser();
        SparqlQuery query2 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                                                            prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                                                            prefix owl: <http://www.w3.org/2002/07/owl#>
                                                            SELECT ?BachelorPrograms
                                                            WHERE {
                                                            ?t   owl:BachelorProgramAtSVU ?BachelorPrograms
                                                          }");
        Object results2 = processor.ProcessQuery(query2);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset2 = (SparqlResultSet)results2;
        DT2 = FillDataTable(rset2);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;

        // to select Master Programs
        Label3.Text = "Master Programs At SVU";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT ?MasterPrograms 
                WHERE {
                ?t   owl:MasterProgramAtSVU ?MasterPrograms 
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;

        // to select Training Programs
        Label4.Text = "Training Programs At SVU";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?TrainingPrograms 
                WHERE {
                ?t   owl:TrainingProgramAtSVU ?TrainingPrograms 
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        Label1.Text = "Economic Program Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        //Use the SparqlQueryParser to give us a SparqlQuery object
        //Should get a Graph back from a CONSTRUCT query
        Label2.Text = "Economic Director Informations ";
        Label2.Visible = true;
        // to select the Economic Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                SELECT   ?EconomicDirectorInfo 
                WHERE {
                ?t   owl:EconomicDirectorInfoProperty ?EconomicDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers Economic program
        Label3.Text = "Teachers Of Economic Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser2 = new SparqlQueryParser();
        SparqlQuery query2 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?TeachersEconomic 
                WHERE {
                ?t   owl:TeachersOfEconomic ?TeachersEconomic 
                }");
        Object results2 = processor.ProcessQuery(query2);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset5 = (SparqlResultSet)results2;
        DT3 = FillDataTable(rset5);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Economic
        Label4.Text = "Courses of Economic Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?CoursesEconomic 
                WHERE {
                ?t   owl:CoursesOfEconomic ?CoursesEconomic 
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset6 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset6);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Information Technology Program ITE Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Information Technology Program Director Infomation ";
        Label2.Visible = true;
        // to select the Information Technology Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?InformationTechnologyDirectorInfo
                WHERE {
                ?t   owl:InformationTechnologyDirectorInfoProperty ?InformationTechnologyDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers Information Technology program
        Label3.Text = "Teachers Of Information Technology Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?InformationTechnologyTeachers 
                WHERE {
                ?t   owl:TeachersOfInformationTechnology ?InformationTechnologyTeachers 
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);    
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Information Technology
        Label4.Text = "Courses of Information Technology Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?InformationTechnologyCourses 
                WHERE {
                ?t   owl:CoursesOfInformationTechnology ?InformationTechnologyCourses 
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);    
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Law Program : BL Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Law Informations ";
        Label2.Visible = true;
        // to select the LAW Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?LawDirectorInformation
                WHERE {
                ?t   owl:LawDirectorInfoProperty ?LawDirectorInformation
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers LAW program
        Label3.Text = "Teachers Of Law Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?LawTeachers
                WHERE {
                ?t   owl:TeachersOfLaw ?LawTeachers 
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of LAW
        Label4.Text = "Courses of Law Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?LawCourses
                WHERE {
                ?t   owl:CoursesOfLaw ?LawCourses
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);    
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;    
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Master in Web Sciences Program : MWS Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Web Sciences Program Informations ";
        Label2.Visible = true;
        // to select the Web Sciences Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MWSDirectorInfo 
                WHERE {
                ?t   owl:MWSDirectorInfoProperty ?MWSDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of MWS program
        Label3.Text = "Teachers Of Master in Web Sciences Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MWSTeachers
                WHERE {
                ?t   owl:TeachersOfMWS ?MWSTeachers 
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Master in Web Sciences
        Label4.Text = "Courses of Master in Web Sciences Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MWSCourses
                WHERE {
                ?t   owl:CoursesOfMWS ?MWSCourses
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);     
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Master in Web Technology Program : MWT Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Web Technology Program Informations ";
        Label2.Visible = true;
        // to select the Web Technology Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MWTDirectorInfo 
                WHERE {
                ?t   owl:MWTDirectorInfoProperty ?MWTDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of MWT program
        Label3.Text = "Teachers Of MWT Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MWTTeachers
                WHERE {
                ?t   owl:TeachersOfMWT ?MWTTeachers
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of MWT
        Label4.Text = "Courses of Web Technology Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?CoursesMWT
                WHERE {
                ?t   owl:CoursesOfMWT ?CoursesMWT
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Master in Technology Management Program : PMTM Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Master in Technology Management Program Informations ";
        Label2.Visible = true;
        // to select the Master in Technology Management Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?PMTMDirectorInformatios 
                WHERE {
                ?t   owl:PMTMDirectorInfoProperty ?PMTMDirectorInformatios 
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of Master in Technology Management program
        Label3.Text = "Teachers Of Master in Technology Management Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?PMTMTeachers
                WHERE {
                ?t   owl:TeachersOfPMTM ?PMTMTeachers
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Master in Technology Management
        Label4.Text = "Courses of Master in Technology Management Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?CoursesPMTM
                WHERE {
                ?t   owl:CoursesOfPMTM ?CoursesPMTM
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Master In Quality Management Program : MIQ Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Master in Quality Management Program Informations ";
        Label2.Visible = true;
        // to select the Master in Quality Management Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MIQDirectorInfo 
                WHERE {
                ?t   owl:MIQDirectorInfoProperty ?MIQDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of Master in Quality Management program
        Label3.Text = "Teachers Of Master in Quality Management Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MIQTeachers
                WHERE {
                ?t   owl:TeachersOfMIQ ?MIQTeachers
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Master in Quality Management
        Label4.Text = "Courses of Master in Quality Management Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?CoursesMIQ
                WHERE {
                ?t   owl:CoursesOfMIQ ?CoursesMIQ
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Master in Business Administration Program : MBA Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Master in Business Administration Program Informations ";
        Label2.Visible = true;
        // to select the Master in Business Administration Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MBADirectorInfo 
                WHERE {
                ?t   owl:MBADirectorInfoProperty ?MBADirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of Master in Business Administration program
        Label3.Text = "Teachers Of Master in Business Administration Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MBATeachers
                WHERE {
                ?t   owl:TeachersOfMBA ?MBATeachers
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Master in Business Administration
        Label4.Text = "Courses of Master in Business Administration Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?CoursesMBA
                WHERE {
                ?t   owl:CoursesOfMBA ?CoursesMBA
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        //Bachelor in Mass Communications Technology Program Details
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Bachelor in Mass Communications Technology Program : BMC Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Bachelor in Mass Communications Technology Program Director Informations ";
        Label2.Visible = true;
        // to select the Communications Technology program's Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?MassCommunicationDirectorInfo
                WHERE {
                ?t   owl:MassCommunicationDirectorInfoProperty ?MassCommunicationDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of Bachelor in Mass Communications Technology program
        Label3.Text = "Teachers Of Bachelor in Mass Communications Technology Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?TeachersOfMassCommunicationProgram
                WHERE {
                ?t   owl:TeachersOfMassCommunication ?TeachersOfMassCommunicationProgram
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Bachelor in Communications Technology
        Label4.Text = "Courses of Bachelor in Mass Communications Technology Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?CoursesBMC
                WHERE {
                ?t   owl:CoursesOfMassCommunication ?CoursesBMC
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        //Bachelor in Communications Technology Program Details
        TripleStore store = new TripleStore();
        Graph g1 = new Graph();
        g1.LoadFromFile(Server.MapPath("SVUModeling.rdf"));
        store.Add(g1);
        InMemoryDataset ds = new InMemoryDataset(store);
        //Get the Query processor
        ISparqlQueryProcessor processor = new LeviathanQueryProcessor(ds);
        Label1.Text = "Bachelor in Communications Technology Program : BACT Details";
        Label1.Visible = true;
        GridView1.Visible = false;
        Label2.Text = "Bachelor in Communications Technology Program Informations ";
        Label2.Visible = true;
        // to select the Communications Technology program's Director Informations 
        SparqlQueryParser sparqlparser = new SparqlQueryParser();
        SparqlQuery query = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                SELECT   ?BACTDirectorInfo
                WHERE {
                ?t   owl:TelecommunicationsTechnologyDirectorInfoProperty ?BACTDirectorInfo
                }");
        Object results = processor.ProcessQuery(query);
        DataTable DT2 = new DataTable();
        SparqlResultSet rset = (SparqlResultSet)results;
        DT2 = FillDataTable(rset);
        GridView2.DataSource = DT2;
        GridView2.DataBind();
        GridView2.Visible = true;
        //to retrival the Teachers of Bachelor in Communications Technology program
        Label3.Text = "Teachers Of Bachelor in Communications Technology Program";
        Label3.Visible = true;
        SparqlQueryParser sparqlparser3 = new SparqlQueryParser();
        SparqlQuery query3 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix foaf: <http://xmlns.com/foaf/0.1/#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?BACTTeachers
                WHERE {
                ?t   owl:TeachersOfTelecommunicationsTechnology ?BACTTeachers
                }");
        Object results3 = processor.ProcessQuery(query3);
        DataTable DT3 = new DataTable();
        SparqlResultSet rset3 = (SparqlResultSet)results3;
        DT3 = FillDataTable(rset3);     
        GridView3.DataSource = DT3;
        GridView3.DataBind();
        GridView3.Visible = true;
        //to select Courses Of Bachelor in Communications Technology
        Label4.Text = "Courses of Bachelor in Communications Technology Program";
        Label4.Visible = true;
        SparqlQueryParser sparqlparser4 = new SparqlQueryParser();
        SparqlQuery query4 = sparqlparser.ParseFromString(@"prefix rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
                prefix rdfs: <http://www.w3.org/2000/01/rdf-schema#>
                prefix owl: <http://www.w3.org/2002/07/owl#>
                SELECT   ?BACTCourses
                WHERE {
                ?t   owl:CoursesOfTelecommunicationsTechnology ?BACTCourses
                }");
        Object results4 = processor.ProcessQuery(query4);
        DataTable DT4 = new DataTable();
        SparqlResultSet rset4 = (SparqlResultSet)results4;
        DT4 = FillDataTable(rset4);
        GridView4.DataSource = DT4;
        GridView4.DataBind();
        GridView4.Visible = true;
    }
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
}