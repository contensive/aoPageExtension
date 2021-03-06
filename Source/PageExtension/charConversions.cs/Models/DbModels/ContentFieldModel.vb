﻿
Option Explicit On
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Contensive.BaseClasses

Namespace Contensive.Addons.xxxxxCollectionNameSpaceGoesHerexxxxx.Models     '<------ set namespace
    Public Class ContentFieldModel        '<------ set set model Name and everywhere that matches this string
        Inherits baseModel
        Implements ICloneable
        '
        '====================================================================================================
        '-- const
        Public Const contentName As String = "Content Fields"      '<------ set content name
        Public Const contentTableName As String = "ccFields"   '<------ set to tablename for the primary content (used for cache names)
        Private Shadows Const contentDataSource As String = "default"             '<------ set to datasource if not default
        '
        '====================================================================================================
        ' -- instance properties

        Public Property AdminOnly As Boolean
        Public Property Authorable As Boolean
        Public Property Caption As String
        Public Property ContentID As Integer
        Public Property createResourceFilesOnRoot As Boolean
        Public Property DefaultValue As String
        Public Property DeveloperOnly As Boolean
        Public Property editorAddonID As Integer
        Public Property EditSortPriority As Integer
        Public Property EditTab As String
        Public Property HTMLContent As Boolean
        Public Property IndexColumn As Integer
        Public Property IndexSortDirection As Integer
        Public Property IndexSortPriority As Integer
        Public Property IndexWidth As String
        Public Property InstalledByCollectionID As Integer
        Public Property IsBaseField As Boolean
        Public Property LookupContentID As Integer
        Public Property LookupList As String
        Public Property ManyToManyContentID As Integer
        Public Property ManyToManyRuleContentID As Integer
        Public Property ManyToManyRulePrimaryField As String
        Public Property ManyToManyRuleSecondaryField As String
        Public Property MemberSelectGroupID As Integer
        Public Property NotEditable As Boolean
        Public Property Password As Boolean
        Public Property prefixForRootResourceFiles As String
        'Public Property ReadOnly As Boolean
        Public Property RedirectContentID As Integer
        Public Property RedirectID As String
        Public Property RedirectPath As String
        Public Property Required As Boolean
        Public Property RSSDescriptionField As Boolean
        Public Property RSSTitleField As Boolean
        Public Property Scramble As Boolean
        Public Property TextBuffered As Boolean
        Public Property Type As Integer
        Public Property UniqueName As Boolean        '
        '====================================================================================================
        Public Overloads Shared Function add(cp As CPBaseClass) As ContentFieldModel
            Return add(Of ContentFieldModel)(cp)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function create(cp As CPBaseClass, recordId As Integer) As ContentFieldModel
            Return create(Of ContentFieldModel)(cp, recordId)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function create(cp As CPBaseClass, recordGuid As String) As ContentFieldModel
            Return create(Of ContentFieldModel)(cp, recordGuid)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function createByName(cp As CPBaseClass, recordName As String) As ContentFieldModel
            Return createByName(Of ContentFieldModel)(cp, recordName)
        End Function
        '
        '====================================================================================================
        Public Overloads Sub save(cp As CPBaseClass)
            MyBase.save(Of ContentFieldModel)(cp)
        End Sub
        '
        '====================================================================================================
        Public Overloads Shared Sub delete(cp As CPBaseClass, recordId As Integer)
            delete(Of ContentFieldModel)(cp, recordId)
        End Sub
        '
        '====================================================================================================
        Public Overloads Shared Sub delete(cp As CPBaseClass, ccGuid As String)
            delete(Of ContentFieldModel)(cp, ccGuid)
        End Sub
        '
        '====================================================================================================
        Public Overloads Shared Function createList(cp As CPBaseClass, sqlCriteria As String, Optional sqlOrderBy As String = "id") As List(Of ContentFieldModel)
            Return createList(Of ContentFieldModel)(cp, sqlCriteria, sqlOrderBy)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getRecordName(cp As CPBaseClass, recordId As Integer) As String
            Return baseModel.getRecordName(Of ContentFieldModel)(cp, recordId)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getRecordName(cp As CPBaseClass, ccGuid As String) As String
            Return baseModel.getRecordName(Of ContentFieldModel)(cp, ccGuid)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getRecordId(cp As CPBaseClass, ccGuid As String) As Integer
            Return baseModel.getRecordId(Of ContentFieldModel)(cp, ccGuid)
        End Function
        '
        '====================================================================================================
        Public Overloads Shared Function getCount(cp As CPBaseClass, sqlCriteria As String) As Integer
            Return baseModel.getCount(Of ContentFieldModel)(cp, sqlCriteria)
        End Function
        '
        '====================================================================================================
        Public Overloads Function getUploadPath(fieldName As String) As String
            Return MyBase.getUploadPath(Of ContentFieldModel)(fieldName)
        End Function
        '
        '====================================================================================================
        '
        Public Function Clone(cp As CPBaseClass) As ContentFieldModel
            Dim result As ContentFieldModel = DirectCast(Me.Clone(), ContentFieldModel)
            result.id = cp.Content.AddRecord(contentName)
            result.ccguid = cp.Utils.CreateGuid()
            result.save(cp)
            Return result
        End Function
        '
        '====================================================================================================
        '
        Public Function Clone() As Object Implements ICloneable.Clone
            Return Me.MemberwiseClone()
        End Function

    End Class
End Namespace
