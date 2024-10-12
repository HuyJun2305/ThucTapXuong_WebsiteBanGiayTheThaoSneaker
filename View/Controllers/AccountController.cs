﻿using API.Data;
using Data.ViewModels;
using DataProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using View.IServices;

namespace View.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var token = await _accountService.SignInAsync(model);
                    if (!string.IsNullOrEmpty(token))
                    {
                        HttpContext.Session.SetString("AuthToken", token);
                        TempData["Welcome"] = "Welcome " + token;
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ViewData["LoginError"] = "Tên đăng nhập hoặc mật khẩu không đúng.";
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _accountService.SignOutAsync();
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> ListCustomer()
        {
            var lstCustomer = await _accountService.GetAllCustomer();
            return View(lstCustomer);
        }
        public async Task<IActionResult> ListEmployee()
        {
            var lstEmployee = await _accountService.GetAllEmployee();
            return View(lstEmployee);
        }
        public async Task<IActionResult> Details(Guid idAccount)
        {
            var account = await _accountService.GetById(idAccount);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: AccountController/Create
        public IActionResult CreateEmployee()
        {
            return View();
        }
        public IActionResult CreateCustomer()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCustomer(CreateAccountModelcs account)
        {
            try
            {
                await _accountService.CreateCustomer(account);
                return RedirectToAction("ListCustomer", "Account");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(CreateAccountModelcs account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _accountService.CreateEmployee(account);
                    return RedirectToAction("ListEmployee", "Account");
                }
                return View(account);
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public async Task<IActionResult> Edit(ApplicationUser idAccount)
        {
            var account = await _accountService.GetById(idAccount.Id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ApplicationUser account, Guid idAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _accountService.Update(account, idAccount);
                    //var userRole = await _userManager.GetRolesAsync(account);
                    //if (userRole.Contains("Employee"))
                    //{
                    //    TempData["UpdateSuccess"] = "Cập nhật thành công";
                    //    RedirectToAction("ListEmployee", "Account");
                    //}
                    //else if(userRole.Contains("Customer"))
                    //{
                    //    TempData["UpdateSuccess"] = "Cập nhật thành công";
                    //    RedirectToAction("ListCustomer", "Account");
                    //}              
                }
                return View("Edit", account);
            }
            catch
            {
                TempData["UpdateFail"] = "Cập nhật không thành công";
                return View("Edit", account);
            }
        }


        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid idAccount)
        {
            try
            {
                var account = await _accountService.GetById(idAccount);
                if (account == null)
                {
                    return NotFound();
                }
                await _accountService.Delete(idAccount);
                TempData["DeleteSuccess"] = "Xóa thành công";
                return View();
            }
            catch
            {
                TempData["DeleteFail"] = "Xóa Thất bại";
                return View();
            }
        }
    }
}

