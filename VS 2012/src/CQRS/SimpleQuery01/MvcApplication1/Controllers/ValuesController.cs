using Newtonsoft.Json;
using QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace MvcApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        private string GetWhereOperator(string @operator)
        {
            var where = string.Empty;

            switch (@operator)
            {
                case "eq":
                    where = "==";
                    break;
                case "ne":
                    where = "!=";
                    break;
                case "cn":
                    //where = 
                    break;
                default:
                    throw new NotImplementedException("Operator not supported: " + @operator);
            }

            return where;
        }

        // GET api/values
        public object Get(
            string sidx, 
            string sord, 
            int page, 
            int rows,
            bool _search = false,
            string filters = null)
        {
            var ctx = new JobsRepository(new EntityContextResolver(new HttpContextWrapper(HttpContext.Current)));

            var sortColumn = sidx;
            var sortDirection = sord;
            var pageIndex = page - 1;
            var pageSize = rows;
            var shouldSearch = _search;

            var q = ctx.GetJobs();

            if (shouldSearch && !string.IsNullOrWhiteSpace(filters))
            {
                dynamic searchFilters = JObject.Parse(filters);

                if (searchFilters != null)
                {
                    var groupOp = (string)searchFilters.groupOp;
                    var rules = searchFilters.rules;
                    var sb = new StringBuilder();

                    foreach (var rule in rules)
                    {
                        var field = (string)rule.field;
                        var data = (string)rule.data;
                        var @operator = (string)rule.op;

                        if (
                            !string.IsNullOrWhiteSpace(field) &&
                            !string.IsNullOrWhiteSpace(data) &&
                            !string.IsNullOrWhiteSpace(@operator))
                        {
                            switch (@operator)
                            {
                                case "eq":
                                    sb.AppendFormat(" {0} {1} {2} {3} ", field, "==", data, @operator);
                                    break;
                                case "ne":
                                    sb.AppendFormat(" {0} {1} {2} {3} ", field, "!=", data, @operator);
                                    break;
                                case "cn":
                                    sb.AppendFormat(" {0}.Contains({1}) {2} ", field, data, @operator);
                                    break;
                                case "gt":
                                    sb.AppendFormat(" {0} {1} {2} {3} ", field, ">", data, @operator);
                                    break;
                                case "lt":
                                    sb.AppendFormat(" {0} {1} {2} {3} ", field, "<", data, @operator);
                                    break;
                                case "ge":
                                    sb.AppendFormat(" {0} {1} {2} {3} ", field, ">=", data, @operator);
                                    break;
                                case "le":
                                    sb.AppendFormat(" {0} {1} {2} {3} ", field, "<=", data, @operator);
                                    break;
                                default:
                                    throw new NotImplementedException("Operator not supported: " + @operator);
                            }
                        }
                    }

                    var where = sb.ToString();

                    if (!string.IsNullOrWhiteSpace(where))
                    {
                        where += " 1 == 1 ";
                        q = q.Where(sb.ToString());
                    }

                    //if (groupOp == "AND")
                    //{
                    //    foreach (var rule in rules)
                    //    {
                    //        //q = q.Where(
                    //        q = q.Where((string)rule.field, (string)rule.data, this.GetWhereOperator((string)rule.op));
                    //    }
                    //}
                    //else
                    //{
                    //    var tmpList = (new List<JobDto>()).AsQueryable();

                    //    foreach (var rule in rules)
                    //    {
                    //        var t = q.Where((string)rule.field, (string)rule.data, this.GetWhereOperator((string)rule.op));

                    //        //tmpList= tmpList.Concat(t);
                    //    }

                    //    q = tmpList.Distinct();
                    //}
                }
            }

            var totalRecords = q.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            if (string.IsNullOrWhiteSpace(sortColumn))
            {
                q = q.OrderBy(x => x.ID);
            }
            else
            {
                q = q.OrderBy(sortColumn + " " + (sortDirection.Equals("asc", StringComparison.InvariantCultureIgnoreCase) ? string.Empty : "descending"));
            }

            q = q.Skip(pageIndex * pageSize).Take(pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = q.ToArray().Select(x => new
                {
                    i = x.ID.ToString(),
                    cell = new[]
                    {
                        x.ID.ToString(),
                        x.Description,
                        x.Minimum.ToString(),
                        x.Maximum.ToString()
                    }
                })
            };

            return jsonData;

            //return JsonConvert.SerializeObject(jsonData);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}