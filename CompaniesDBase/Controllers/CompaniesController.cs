﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompaniesDBase.Models;
using System.Threading.Tasks;

namespace CompaniesDBase.Controllers
{
    public class CompaniesController : ApiController
    {
        private CompaniesDBaseContext db = new CompaniesDBaseContext();

        // GET: api/Companies
        public IQueryable<CompanyDTO> GetCompanies()
        {
            var companies = from c in db.Companies
                            select new CompanyDTO()
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                NIPNumber = c.NIPNumber,
                                KRSNumber = c.KRSNumber,
                                REGONNumber = c.REGONNumber

                            };
            return companies;
        }

        // GET: api/Companies?CompanyName=cname
        [HttpGet, Route("api/Companies/CompanyName/{cName}")]
        public IQueryable<CompanyDTO> GetCompanyByName(string cName)
        {
            var companies = from c in db.Companies
                            where c.CompanyName == cName
                            select new CompanyDTO()
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                NIPNumber = c.NIPNumber,
                                KRSNumber = c.KRSNumber,
                                REGONNumber = c.REGONNumber

                            };
            return companies;
        }

        [HttpGet, Route("api/Companies/NIPNumber/{nip}")]
        public IQueryable<CompanyDTO> GetCompanyByNip(string nip)
        {
            var companies = from c in db.Companies
                            where c.NIPNumber == nip
                            select new CompanyDTO()
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                NIPNumber = c.NIPNumber,
                                KRSNumber = c.KRSNumber,
                                REGONNumber = c.REGONNumber

                            };
            return companies;
        }
        [HttpGet, Route("api/Companies/KRSNumber/{krs}")]
        public IQueryable<CompanyDTO> GetCompanyByKrs(string krs)
        {
            var companies = from c in db.Companies
                            where c.KRSNumber == krs
                            select new CompanyDTO()
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                NIPNumber = c.NIPNumber,
                                KRSNumber = c.KRSNumber,
                                REGONNumber = c.REGONNumber

                            };
            return companies;
        }

        [HttpGet, Route("api/Companies/REGONNumber/{regon}")]
        public IQueryable<CompanyDTO> GetCompanyByRegon(string regon)
        {
            var companies = from c in db.Companies
                            where c.REGONNumber == regon
                            select new CompanyDTO()
                            {
                                Id = c.Id,
                                CompanyName = c.CompanyName,
                                NIPNumber = c.NIPNumber,
                                KRSNumber = c.KRSNumber,
                                REGONNumber = c.REGONNumber

                            };
            return companies;
        }

        // GET: api/Companies/5
        [ResponseType(typeof(CompanyDTO))]
        public async Task<IHttpActionResult> GetCompany(int id)
        {
            var company = await db.Companies.Select(c =>
               new CompanyDTO()
               {
                   Id = c.Id,
                   CompanyName = c.CompanyName,
                   NIPNumber = c.NIPNumber,
                   KRSNumber = c.KRSNumber,
                   REGONNumber = c.REGONNumber
               }).SingleOrDefaultAsync(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }
        

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Id)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
               await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Companies
        [ResponseType(typeof(Company))]
        public async Task<IHttpActionResult> PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            await db.SaveChangesAsync();

            var dto = new CompanyDTO()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                NIPNumber = company.NIPNumber,
                KRSNumber = company.KRSNumber,
                REGONNumber = company.REGONNumber
            };

            return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(Company))]
        public async  Task<IHttpActionResult> DeleteCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
            //return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.Id == id) > 0;
        }
    }
}