﻿Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security

Public Class frmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login1_Authenticate(sender As Object, e As System.Web.UI.WebControls.AuthenticateEventArgs) Handles Login1.Authenticate
        Dim objLoginBLL As New BLL.LoginBLL
        Dim usuario As New MODEL.Usuario
        Dim dtUsuario As DataTable

        usuario.nomeUsuario = Login1.UserName
        usuario.senha = Login1.Password


        dtUsuario = objLoginBLL.Logar(usuario, 1).Tables(0)

        usuario.codigo = dtUsuario.Rows(0)("cd_usuario")        

        Select Case usuario.codigo
            Case -1
                Login1.FailureText = "Usuario e senha não estão corretos."
                Exit Select
            Case Else
                usuario.acesso = dtUsuario.Rows(0)("cd_acesso")

                Session("sessionUser") = usuario.nomeUsuario
                Session("codUsuario") = usuario.codigo
                Session("acesso") = usuario.acesso
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                Exit Select
        End Select


    End Sub
End Class