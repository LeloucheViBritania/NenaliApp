using AutoMapper;
using FinalCaimanProject.DAL;
using FinalCaimanProject.DTOs;
using FinalCaimanProject.Models;
using FinalCaimanProject.VM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCaimanProject.Controllers
{
    [Authorize]
    public class DepartementController : Controller
    {
        DbCaimanContext db = new DbCaimanContext();
        // GET: Departement
        public ActionResult Departement()
        {
            var bd = db.Specialites.ToList();
            ViewBag.Spe = db.Specialites.ToList();
            return View(bd);
        }
        public ActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajouter(Specialite specialite)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                    {
                        var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                        var ext = Path.GetExtension(fileName).ToLower();
                        if (ext == ".jpg" || ext == ".png" || ext == ".jpeg" || ext == ".gif")
                        {
                            specialite.Url_Image = "/Fichier";
                            var path = Path.Combine(Server.MapPath(specialite.Url_Image), fileName);//Enregistrement du fichier dans le dossier Fichier
                            file.SaveAs(path);
                            specialite.ImageSpecialite = fileName;
                        }
                        else
                        {
                            ViewData["SetError"] = "Le fichier selectionné doit etre une image*";
                            return View();
                        }
                        
                    }
                }
                // Verification des champs du formulaire
                #region Verification des champs du formulaire
                if (specialite.SpecialiteName != null)
                {
                    db.Specialites.Add(specialite);
                }
                else
                {
                    ViewData["NameError"] = "Le nom de la Spécialité est requis*";
                    return View();
                }
                if (specialite.SpecialiteInfo != null)
                {
                    db.Specialites.Add(specialite);
                }
                else
                {
                    ViewData["InfoError"] = "La description de la Spécialité est requise";
                    return View();
                }
                if (specialite.ImageSpecialite != null)
                {
                    db.Specialites.Add(specialite);
                }
                else
                {
                    ViewData["ImageError"] = "L'image de la Spécialité est requise";
                    return View();
                }
                if (specialite.SpecialiteColor != null)
                {
                    db.Specialites.Add(specialite);

                }
                else
                {
                    ViewData["ColorError"] = "La couleur de la Spécialité est requise";
                    return View();
                }
                #endregion
                db.SaveChanges();
                ModelState.Clear();

                ViewBag.Message = "Succès";
            }
            return View();
        }

        public ActionResult VueDepartement(int id)
        {

            var bd = db.Specialites.Find(id);
            ViewBag.Membern = db.Members.Where(s => s.SpecialiteId == bd.SpecialiteId && s.MemberIsArchived != true);
            ViewBag.Respo = db.Members.Where(s => s.MemberStatus == "Chef de groupe" && s.SpecialiteId == bd.SpecialiteId).OrderByDescending(x => x.MemberId);
            ViewBag.Adj = db.Members.Where(s => s.MemberStatus != "Chef de groupe" && s.SpecialiteId == bd.SpecialiteId);
            return View(bd);
        }


        [HttpPost]
        public ActionResult VueDepartement(Member member, int id)
        {

            var bd = from s in db.Members select s;
            foreach (var item in bd)
            {
                //fait le verification s'ils sont identiques
                if (member.MemberId == item.MemberId)
                {
                    if (member.MemberStatus == "Chef de groupe" && member.MemberStatus == "Membre simple")
                    {
                        item.MemberStatus = "Adjoint";
                    }
                    else if (member.MemberStatus != "Chef de groupe" && member.MemberStatus != "Membre simple")
                    {
                        item.MemberStatus = "Chef de groupe";
                    }
                    else
                    {
                        item.MemberStatus = "Adjoint";
                    }
                    member = item;

                }

            }
            db.Members.Update(member);
            db.SaveChanges();

            return RedirectToAction("VueDepartement");
        }

        public ActionResult ProfilMember(int id)
        {
            var _context = new DbCaimanContext();
            var memberDtail = _context.Members
                .Include(mem => mem.Competences)
                .Include(mem => mem.SocialNetworks)
                .FirstOrDefault(m => m.MemberId == id);
            var memSpecialite = _context.Specialites.ToList();
            var membTrans = _context.Transports.ToList();

            var memberWithAllDetails = Mapper.Map<Member, ProfilMemberDTO>(memberDtail);


            ProfilMVM profilMVM = new ProfilMVM();
            profilMVM.ProfilMemberDTO = memberWithAllDetails;
            profilMVM.Specialites = memSpecialite;
            profilMVM.Transports = membTrans;
            return View(profilMVM);
        }

        [HttpPost]
        public ActionResult ProfilMember(Member member, Competence competence, SocialNetwork socialNetwork, int id)
        {
            var _context = new DbCaimanContext();
            var memberDtail = _context.Members
                .Include(mem => mem.Competences)
                .Include(mem => mem.SocialNetworks)
                .FirstOrDefault(m => m.MemberId == id);
            var memSpecialite = _context.Specialites.ToList();
            var membTrans = _context.Transports.ToList();

            var memberWithAllDetails = Mapper.Map<Member, ProfilMemberDTO>(memberDtail);


            ProfilMVM profilMVM = new ProfilMVM();
            profilMVM.ProfilMemberDTO = memberWithAllDetails;
            profilMVM.Specialites = memSpecialite;
            profilMVM.Transports = membTrans;

            var bd = db.Members.Find(id);

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null && file.ContentLength > 0)//Vérifie que le fichier existe
                {
                    var fileName = Path.GetFileName(file.FileName); //Récupération du nom du fichier
                    var path = Path.Combine(Server.MapPath("/Fichier"), fileName);//Enregistrement du fichier dans le dossier Fichier
                    member.MemberImageName = fileName;
                    file.SaveAs(path);
                    bd.MemberImageName = fileName;
                    db.Members.Update(bd);
                    db.SaveChanges();
                }
            }
            else if (member.MemberPnom != null)
            {
                bd.MemberName = member.MemberName;
                bd.MemberPnom = member.MemberPnom;
                bd.MemberCommune = member.MemberCommune;
                bd.MemberDescription = member.MemberDescription;
                bd.MemberMail = member.MemberMail;
                bd.MemberQuartier = member.MemberQuartier;
                bd.MemberCommune = member.MemberCommune;
                bd.MemberPhone = member.MemberPhone;
                bd.MemberSex = member.MemberSex;
                bd.MemberStatus = member.MemberStatus;
                bd.TransportMember = member.TransportMember;
                db.Members.Update(bd);
                db.SaveChanges();
            }
            else if ( member.MemberNote != 0)
            {
                bd.MemberNote = member.MemberNote;
                db.Members.Update(bd);
                db.SaveChanges();

            }
            else
            {
                bd.MemberIsArchived = member.MemberIsArchived;
                bd.MemberDateArchive = DateTime.Now;
                db.Members.Update(bd);
                db.SaveChanges();
            }

            if (competence.CompetenceName != null)
            {
                var _con = new DbCaimanContext();


                Member memberAdd = new Member();
                memberAdd = _context.Members.FirstOrDefault(c => c.MemberId == id);
                memberAdd.Competences = new List<Competence>();
                Competence addCompetence = new Competence();
                addCompetence.CompetenceName = competence.CompetenceName;
                memberAdd.Competences.Add(addCompetence);
                _con.Members.Update(memberAdd);
                _con.SaveChanges();
                _con.Dispose();
                /* _Transport.Members = new List<Member>();
                 if (_Specialite != null)
                 {
                     _Specialite.Members.Add(mem);
                     _context.Specialites.Update(_Specialite);
                 }
                 _Transport.Members.Add(mem);

                 _context.Transports.Add(_Transport);
                 _context.SaveChanges();
                 _context.Dispose();*/
            }

            if (socialNetwork.NetworkName != null)
            {
                var _con = new DbCaimanContext();
                Member memberAdd = new Member();
                memberAdd = _context.Members.FirstOrDefault(c => c.MemberId == id);
                memberAdd.SocialNetworks = new List<SocialNetwork>();
                SocialNetwork socialNetwork1 = new SocialNetwork();
                socialNetwork1.NetworkName = socialNetwork.NetworkName;
                socialNetwork1.NetworkLink = socialNetwork.NetworkLink;
                memberAdd.SocialNetworks.Add(socialNetwork1);
                _con.Members.Update(memberAdd);
                _con.SaveChanges();


                /*   db.SocialNetworks.Add(socialNetwork);
                   db.SaveChanges();*/
            }
            return RedirectToAction("ProfilMember", profilMVM);
        }
    }
}