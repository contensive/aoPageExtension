VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "AddonClass"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True

Option Explicit
'
Private Csv As Object
Private Main As Object
'
'========================================================================
'   v3.3 Add-on Compatibility
'       To make an Add-on that works the same in v3.3 and v3.4, use this adapter instead of the execute above
'========================================================================
'
Public Function Execute(CsvObject As Object, MainObject As Object, optionString As String, FilterInput As String) As String
    Set Csv = CsvObject
    Call Init(MainObject)
    Execute = GetContent(optionString)
End Function
'
'
'
Public Sub Init(MainObject As Object)
    '
    Set Main = MainObject
    '
    Exit Sub
ErrorTrap:
    Call HandleError("PageExtensionClass", "Init", Err.Number, Err.Source, Err.Description, True, False)
End Sub
'
'===========================================================================================================
'   Tag Type
'       Section - The copy is the same of every page in a section
'       Page - The copy is new for every page it is used on
'               Use this in a template as a page-extension
'===========================================================================================================
'
Public Function GetContent(optionString As String) As String
    On Error GoTo ErrorTrap
    '
    
    Dim PCCParentIDIndex As FastIndexClass
    Dim Stream As String
    Dim ExtensionName As String
    Dim ExtensionType As String
    Dim Copy As String
    Dim PageID As Long
    Dim SectionID As Long
    Dim IsDone As Boolean
    Dim PCCLocal As Variant
    Dim PCCPtr As Long
    Dim SSCLocal As Variant
    Dim SSCCnt As Long
    Dim SSCPtr As Long
    Dim IsWorkflowRendering As Boolean
    Dim IsQuickEditing As Boolean
    '
    If Not (Main Is Nothing) Then
        ExtensionName = Trim(getAggrOption("ExtensionName", optionString))
        If ExtensionName = "" Then
            If Main.IsAdmin() Then
                GetContent = Main.GetAdminHintWrapper("The ExtensionName is blank. To use the Page Extension, set the ExtensionName and select the ExtensionType.")
            End If
        Else
            '
            ' Handle PageID Request Variable
            '
            ExtensionType = LCase(Trim(getAggrOption("ExtensionType", optionString)))
            PageID = Main.RenderedPageID
            'PageID = Main.GetStreamInteger("bid")
            SectionID = Main.RenderedSectionID
            'SectionID = Main.GetStreamInteger("sid")
            IsQuickEditing = Main.IsQuickEditing("Page Content")
            IsWorkflowRendering = Main.IsWorkflowRendering
            '
            Select Case ExtensionType
                Case "section"
                    If SectionID = 0 Then
                        If PageID = 0 Then
                            GetContent = ""
                        Else
                            PCCLocal = Main.GetPCC(Main.IsWorkflowRendering, IsQuickEditing)
                            Set PCCParentIDIndex = Main.PCCParentIDIndex
                            SSCLocal = Main.GetSSC()
                            SSCCnt = UBound(SSCLocal, 2) + 1
                            If (SSCCnt > 0) Then
                                Do While PageID <> 0
                                    For SSCPtr = 0 To SSCCnt - 1
                                        If PageID = kmaEncodeInteger(SSCLocal(SSC_RootPageID, SSCPtr)) Then
                                            Exit For
                                        End If
                                    Next
                                    If SSCPtr < SSCCnt Then
                                        Exit Do
                                    End If
                                    PCCPtr = Main.GetPCCPtr(PageID, IsWorkflowRendering, IsQuickEditing)
                                    If PCCPtr >= 0 Then
                                        PageID = kmaEncodeInteger(PCCLocal(PCC_ParentID, PCCPtr))
                                    End If
                                Loop
                                If SSCPtr < SSCCnt Then
                                    '
                                    ' Section found from rootpageid
                                    '
                                    SectionID = kmaEncodeInteger(SSCLocal(SSC_ID, SSCPtr))
                                End If
                            End If
                        End If
                    End If
                    If SectionID <> 0 Then
                        GetContent = Main.GetContentCopy("PageExtension-Section-" & SectionID & "-" & ExtensionName)
                    End If
                Case "page"
                    If (PageID = 0) And (SectionID <> 0) Then
                        PCCLocal = Main.GetPCC(Main.IsWorkflowRendering, IsQuickEditing)
                        SSCLocal = Main.GetSSC()
                        SSCCnt = UBound(SSCLocal, 2) + 1
                        If (SSCCnt > 0) Then
                            For SSCPtr = 0 To SSCCnt - 1
                                If SectionID = kmaEncodeInteger(SSCLocal(SSC_ID, SSCPtr)) Then
                                    Exit For
                                End If
                            Next
                            If SSCPtr < SSCCnt Then
                                PageID = kmaEncodeInteger(SSCLocal(SSC_RootPageID, SSCPtr))
                            End If
                        End If
                    End If
                    If PageID <> 0 Then
                        GetContent = Main.GetContentCopy("PageExtension-Page-" & PageID & "-" & ExtensionName)
                    End If
                Case Else
                    GetContent = Main.GetAdminHintWrapper("The Extension Type is blank. To use the Page Extension, set the ExtensionName and select the ExtensionType.")
            End Select
        End If
    End If
    '
    Exit Function
ErrorTrap:
    Call HandleError("PageExtensionClass", "GetContent", Err.Number, Err.Source, Err.Description, True, False)
    End Function
    '
    '
    '
    Private Function getAggrOption(optionName As String, optionString As String) As String
    getAggrOption = Csv.GetAddonOption(optionName)
    End Function
