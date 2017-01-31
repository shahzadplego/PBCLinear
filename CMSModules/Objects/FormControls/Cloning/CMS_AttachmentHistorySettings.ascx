﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CMS_AttachmentHistorySettings.ascx.cs" 
    Inherits="CMSModules_Objects_FormControls_Cloning_CMS_AttachmentHistorySettings" %>
<div class="form-horizontal">
    <div class="form-group">
        <div class="editing-form-label-cell">
            <cms:LocalizedLabel CssClass="control-label" runat="server" ID="lblFileName" ResourceString="clonning.settings.attachment.filename"
                EnableViewState="false" DisplayColon="true" AssociatedControlID="txtFileName" />
        </div>
        <div class="editing-form-value-cell">
            <cms:CMSTextBox runat="server" ID="txtFileName" MaxLength="240" />
        </div>
    </div>
</div>

