﻿// Licensed to the .NET Foundation under one or more agreements.
using Utility;

namespace Time_Trucker.Areas.Identity.Pages.Account
        private readonly RoleManager<IdentityRole> _roleManager;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.PhoneNumber = Input.PhoneNumber;


                if (result.Succeeded)
                {
                    string role = Request.Form["rdUserRole"].ToString();
                    if (role == StaticDetails.SupperManagerRole)
                    {
                        await _userManager.AddToRoleAsync(user, StaticDetails.SupperManagerRole);
                    }
                    else
                    {
                        if (role == StaticDetails.ManagerRole)
                        {
                            await _userManager.AddToRoleAsync(user, StaticDetails.ManagerRole);
                        }
                        else
                        {
                            {
                                await _userManager.AddToRoleAsync(user, StaticDetails.EmployeeRole);
                            }
                        }
                    }
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        if (User.IsInRole(StaticDetails.ManagerRole))
                        {
                            TempData["success"] = "Employee registered successfully";
                            return RedirectToPage("/Customer/Home/Index");
                        }
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }