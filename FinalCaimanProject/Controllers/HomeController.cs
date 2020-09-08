using AutoMapper;
using FinalCaimanProject.DAL;
using FinalCaimanProject.Models;
using FinalCaimanProject.VM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCaimanProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var _context = new DbCaimanContext();
            /*var allProjet = GetAllProjets();*/
            var VmAllP = new AllProjets();

            /*            var ctx = _context.Projets.Include(MP => MP.ProjetMembers)
                            .ThenInclude(mem => mem.Member).SingleOrDefault(c=>c.ProjetId == 1);*/
            /*            var ctx1 = Mapper.DynamicMap<Projet, ProjetsDTO>(ctx);
            */
            var idallPr = _context.Projets.ToList();

            List<ProjetsDTO> allProjetMembers = new List<ProjetsDTO>();
            foreach (var item in idallPr)
            {
                var ctx2 = _context.Projets.Include(MP => MP.ProjetMembers)
               .ThenInclude(mem => mem.Member).FirstOrDefault(c => c.ProjetId == item.ProjetId);
                if (ctx2 != null)
                {
                    ProjetsDTO monMApp = Mapper.Map<Projet, ProjetsDTO>(ctx2);
                    allProjetMembers.Add(monMApp);
                }

            }

            ViewBag.Alls = allProjetMembers.Where(c => c.IsArchieved == false).OrderByDescending(x=> x.ProjetId); ;
            VmAllP.Specialites = GetSpecilites();

            return View(VmAllP);

        }


        private List<Specialite> GetSpecilites()
        {
            var _context = new DbCaimanContext();
            return _context.Specialites.ToList();
        }

        public ActionResult NewMember()
        {
            var _context = new DbCaimanContext();
            var spe = _context.Specialites.ToList();
            var Tra = _context.Transports.ToList();

            var pm = new SaveMemberViewModel()
            {
                Specialites = spe,
                Transports = Tra
            };

            _context.Dispose();
            return View(pm);
        }

        //Get Projets 




        /*[HttpPost]
        public ActionResult NewMember(SaveMemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var _context = new DbCaimanContext();
                List<Specialite> List = _context.Specialites.ToList();
                ViewBag.SpecialiteList = List;
                Specialite _Specialite = _context.Specialites.FirstOrDefault(Sp => Sp.SpecialiteName == model.SpecialiteName);
                _Specialite.Members = new List<Member>();
                var mem = new Member();
                mem.MemberCommune = model.MemberCommune;
                mem.MemberName = model.MemberName;
                mem.MemberPnom = model.MemberPnom;
                mem.MemberDescription = model.MemberDescription;
                mem.MemberLieuNaissance = model.MemberLieuNaissance;
                mem.MemberNaissance = model.MemberNaissance;
                mem.MemberPhone = model.MemberPhone;
                mem.MemberQuartier = model.MemberQuartier;
                mem.MemberMail = model.MemberMail;
                mem.MemberSex = model.MemberSex;
                Transport _Transport = new Transport { TranportName = model.TranportName };
                _Transport.Members = new List<Member>();

                if (_Specialite != null)
                {
                    _Specialite.Members.Add(mem);
                    _context.Specialites.Update(_Specialite);
                }
                _Transport.Members.Add(mem);

                _context.Transports.Add(_Transport);
                _context.SaveChanges();
                _context.Dispose();

                return View();
            }
            return View(model);
        }*/
        [HttpPost]
        public ActionResult NewMember(Member member)
        {
            var _context = new DbCaimanContext();
            var specialites = _context.Specialites.ToList();
            var Tra = _context.Transports.ToList();
            var vM = new SaveMemberViewModel
            {
                Specialites = specialites,
                Transports = Tra
                
            };

            if (!ModelState.IsValid)
            {
                vM.Member = member;
                return View(vM);
            }
            var tar = new Transport();

            if (member.SpecialiteId == 0)
            {
                ViewBag.PasSpe = "Veuillez d'abord cree une specialite !";
                vM.Member = member;
                return View(vM);
            }
            if (ModelState.IsValid)
            {
                var date = DateTime.Today.Year;
                if (member.MemberNaissance.Year >= date)
                {
                    ViewData["errordate"] = "L'année doit etre inférieure a l'année actuelle";
                    vM.Member = member;
                    return View(vM);
                }

                
                Specialite _Specialite = _context.Specialites.FirstOrDefault(Sp => Sp.SpecialiteId == member.SpecialiteId);
                _Specialite.Members = new List<Member>();
                var memberAdd = new Member();
                memberAdd = member;
                /*memberAdd.MemberCommune = member.MemberCommune;
                memberAdd.MemberName = member.MemberName;
                memberAdd.MemberPnom = member.MemberPnom;
                memberAdd.MemberDescription = member.MemberDescription;
                memberAdd.MemberLieuNaissance = member.MemberLieuNaissance;
                memberAdd.MemberNaissance = member.MemberNaissance;
                memberAdd.MemberPhone = member.MemberPhone;
                memberAdd.MemberQuartier = member.MemberQuartier;
                memberAdd.MemberMail = member.MemberMail;
                memberAdd.MemberTransport = member.MemberTransport;
                memberAdd.MemberSex = member.MemberSex;*/
                Transport _Transport = _context.Transports.FirstOrDefault(Tr=>Tr.TransportId == member.TransportId);
                
                _Transport.Members = new List<Member>();
              

                if (_Specialite != null)
                {
                    _Specialite.Members.Add(memberAdd);
                    _context.Specialites.Update(_Specialite);
                }
                _Transport.Members.Add(memberAdd);

                _context.Transports.Add(_Transport);
                _context.SaveChanges();
                _context.Dispose();

                return RedirectToAction( "ProfilMember", "Departement", new { id = memberAdd.MemberId });
            }
            return View();
        }






        public ActionResult FinishProjet(int id)
        {
            var _context = new DbCaimanContext();
            Projet projetF = _context.Projets.FirstOrDefault(proId => proId.ProjetId == id);
            return View(projetF);
        }



        [HttpPost]
        public ActionResult FinishProjet(Projet proFUp, int id)
        {

            var _contextNoTrack = new DbCaimanContext();

            var projetF = _contextNoTrack.Projets.Include(c => c.ProjetMembers)
                                                     .ThenInclude(m => m.Member)
                                                 .SingleOrDefault(c => c.ProjetId == id);
            if (ModelState.IsValid)
            {
                projetF.IsArchieved = true;
                projetF.ProjetDateFin = DateTime.Now;
                projetF.ProjetMoney = proFUp.ProjetMoney;
                projetF.ProjetObservationFinal = proFUp.ProjetObservationFinal;
                projetF.ProjetProgressBar = 100;
                _contextNoTrack.Projets.Update(projetF);
                _contextNoTrack.SaveChanges();
                var _con = new DbCaimanContext();
                List<int> tempIdList = projetF.ProjetMembers.Select(q => q.MemberId).ToList();
                var temp = _con.Members.Where(q => tempIdList.Contains(q.MemberId)).AsNoTracking();
                _contextNoTrack.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;


                foreach (var selectMember in temp)
                {
                    var _contextF = new DbCaimanContext();
                    var memUPDATE = _contextF.Members.SingleOrDefault(m => m.MemberId == selectMember.MemberId);

                    _contextF.Dispose();

                    memUPDATE.MemberMissionActive -= 1;
                    memUPDATE.MemberMissonFin += 1;

                    _con.Members.Update(memUPDATE);
                }

                _con.SaveChanges();
                return RedirectToAction("ArchiveAllProjet", "Home");
            }
            else
            {
                ViewData["MessageError"] = "Le bilan est requis s'il vous plait *";
                return View(projetF);
            }
           /* return View(projetF);*/
            /* var _contextNoTrack = new DbCaimanContext();

             var projetF = _contextNoTrack.Projets.Include(c => c.ProjetMembers)
                                                      .ThenInclude(m => m.Member).AsNoTracking()
                                                  .SingleOrDefault(c => c.ProjetId == id);
             if (ModelState.IsValid)
             {
                 if (proFUp.ProjetObservationFinal != null)
                 {
                     projetF.IsArchieved = true;
                     projetF.ProjetDateFin = DateTime.Now;
                     projetF.ProjetMoney = proFUp.ProjetMoney;
                     projetF.ProjetObservationFinal = proFUp.ProjetObservationFinal;
                     projetF.ProjetProgressBar = 100;
                     var _con = new DbCaimanContext();
                     List<int> tempIdList = projetF.ProjetMembers.Select(q => q.MemberId).ToList();
                     var temp = _con.Members.Where(q => !tempIdList.Contains(q.MemberId)).AsNoTracking();
                     _contextNoTrack.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                     foreach (var memProjet in temp)
                     {
                         if (memProjet.MemberMissionActive >= 0)
                         {
                             Member memUp = new Member
                             {
                                 MemberId = memProjet.MemberId,
                                 SpecialiteId = memProjet.SpecialiteId,
                                 TransportId = memProjet.TransportId
                             };

                             var ds = _contextNoTrack.Members.SingleOrDefault(s => s.MemberId == memProjet.MemberId);
                             var up = _contextNoTrack.Members.Find(ds.MemberId);
                             up.MemberMissionActive -= 1;
                             up.MemberMissonFin += 1;
                             up.SpecialiteId = memProjet.SpecialiteId;
                             up.TransportId = memProjet.TransportId;
                             _contextNoTrack.Members.Update(up);

                             _contextNoTrack.SaveChanges();
                             var proMP = new ProjetMember
                             {
                                 Member = memUp
                             };
                             projetF.ProjetMembers.Add(proMP);
                         }
                         else
                         {
                             Member memUp = new Member
                             {
                                 MemberId = memProjet.MemberId,
                                 SpecialiteId = memProjet.SpecialiteId,
                                 TransportId = memProjet.TransportId

                             };

                             var ds = _contextNoTrack.Members.SingleOrDefault(s => s.MemberId == memUp.MemberId);
                             var up = _contextNoTrack.Members.Find(ds.MemberId);
                             up.MemberMissonFin += 1;
                             up.SpecialiteId = memUp.SpecialiteId;
                             up.TransportId = memUp.TransportId;
                             _contextNoTrack.Members.Update(up);
                             var proMP = new ProjetMember
                             {
                                 Member = memUp
                             };
                             projetF.ProjetMembers.Add(proMP);
                         }


                     }
                     projetF.ProjetProgressBar = 100;
                     _con.Projets.Update(projetF);
                     _con.SaveChanges();

                     return RedirectToAction("ArchiveAllProjet", "Home");
                 }
                 else
                 {
                     ViewData["MessageError"] = "Le bilan est requis s'il vous plait *";
                     return View(projetF);
                 }

             }
             return View(projetF);*/
        }



        public ActionResult ArchiveAllProjet(int page = 0)
        {
            var _context = new DbCaimanContext();
            /*var allProjet = GetAllProjets();*/
            var VmAllP = new AllProjets();

            var ctx = _context.Projets.Include(MP => MP.ProjetMembers)
                .ThenInclude(mem => mem.Member).SingleOrDefault(c => c.ProjetId == 1);
            var ctx1 = Mapper.DynamicMap<Projet, ProjetsDTO>(ctx);

            var idallPr = _context.Projets.ToList();

            List<ProjetsDTO> allProjetMembers = new List<ProjetsDTO>();
            foreach (var item in idallPr)
            {
                var ctx2 = _context.Projets.Include(MP => MP.ProjetMembers)
               .ThenInclude(mem => mem.Member).FirstOrDefault(c => c.ProjetId == item.ProjetId);
                if (ctx2 != null)
                {
                    ProjetsDTO monMApp = Mapper.Map<Projet, ProjetsDTO>(ctx2);
                    allProjetMembers.Add(monMApp);
                }

            }
            var bedroom = allProjetMembers.Where(c => c.IsArchieved == true);
            const int PageSize = 3; // you can always do something more elegant to set this

            var count = bedroom.Count();

            var data = bedroom.Skip(page * PageSize).Take(PageSize).ToList().OrderByDescending(x=> x.ProjetId);

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            ViewBag.Page = page;
            ViewBag.Alls = data;

            VmAllP.Specialites = GetSpecilites();
            return View(VmAllP);

        }



        public ActionResult OldMembers(int page = 0)
        {
            const int PageSize = 6;

            var _context = new DbCaimanContext();
            var oldMember = _context.Members.Where(m => m.MemberIsArchived == true).ToList();

            var count = oldMember.Count();
            var data = oldMember.Skip(page * PageSize).Take(PageSize).OrderByDescending(c => c.MemberId).ToList();
            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;

            var oldVM = new OldVm();
            oldVM.OldMembers = data;
            oldVM.Specialites = GetSpecilites();
            return View(oldVM);
        }

    }
}