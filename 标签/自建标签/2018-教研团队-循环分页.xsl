<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="eliteLevel" />
    <xsl:param name="hits" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="nodeid" />
    <xsl:output method="html" />
    <xsl:template match="/">
        <NewDataSet>
            <xsl:for-each select="NewDataSet/Table">
                <Table>
                    <GeneralID>
                        <xsl:value-of select="GeneralID"/>
                    </GeneralID>
                    <ItemId>
                        <xsl:value-of select="ItemId"/>
                    </ItemId>
                    <Title>
                        <xsl:value-of select="pe:CutText(pe:RemoveHtml(Title),$titleLength,'…')" />
                    </Title>
                    <DefaultPicUrl>
                        &lt;img src="<xsl:value-of select="pe:UpLoadDir()"/>
                        <xsl:value-of select="DefaultPicUrl"/>" alt="<xsl:value-of select="Title"/>" border="0" /&gt;
                    </DefaultPicUrl>
                    <RedirectLink>
                        <xsl:value-of select="RedirectLink" />
                    </RedirectLink>
                    <Intro>
                        <xsl:value-of select="Intro" />
                    </Intro>
                    <InfoPath>
                        &lt;div class="col u-content" style="background-image: url(<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>); background-size:100%;"&gt;
                        &lt;div class="u-info"&gt;
                        &lt;div class="u-name"&gt;<xsl:value-of select="Title" />&lt;/div&gt;
                        &lt;div class="u-title"&gt;<xsl:value-of select="teacherTitle" />&lt;/div&gt;
                        &lt;div class="u-edu"&gt;<xsl:value-of select="education" />&lt;/div&gt;
                        &lt;div class="u-intro pt-5"&gt;<xsl:value-of select="pe:RemoveHtml(intro)" />&lt;/div&gt;
                        &lt;/div&gt;
                        &lt;a class="u-btn pos_a u-btn-show-teacher-modal" data-pk="<xsl:value-of select="GeneralID" />"
                        data-img="<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>"
                        data-name="<xsl:value-of select="Title" />" data-title="<xsl:value-of select="teacherTitle" />"
                        data-intro="<xsl:value-of select="intro" />"
                        type="button" data-toggle="modal" data-target=".modal-teacher-show" style="cursor: pointer;"&gt; +&lt;/a&gt;
                        &lt;/div&gt;
                    </InfoPath>
                    <Teacherlist>
                        &lt;a href="<xsl:value-of disable-output-escaping="yes" select="pe:GetInfoPath(NodeID,GeneralID,InputTime,PinyinTitle,HtmlPageName)"/>" title="<xsl:value-of select="Teacher_EnName"/>" target="_blank" &gt;
                        &lt;img src="<xsl:value-of select="pe:UpLoadDir()"/>
                        <xsl:value-of select="DefaultPicUrl"/>" alt="<xsl:value-of select="Teacher_EnName"/>" border="0" /&gt;
                        &lt;/a&gt;
                        &lt;a href="<xsl:value-of disable-output-escaping="yes" select="pe:GetInfoPath(NodeID,GeneralID,InputTime,PinyinTitle,HtmlPageName)"/>" target="_blank" class="teaname" &gt;&lt;span&gt;<xsl:value-of select="Teacher_EnName" />&lt;/span&gt;&lt;/a&gt;
                        &lt;br /&gt;
                        &lt;a href="<xsl:value-of disable-output-escaping="yes" select="pe:GetInfoPath(NodeID,GeneralID,InputTime,PinyinTitle,HtmlPageName)"/>" target="_blank" class="teaintro" &gt;&lt;span&gt;教学专长：<xsl:value-of select="Intro" />&lt;/span&gt;&lt;/a&gt;
                    </Teacherlist>
                </Table>
            </xsl:for-each>
        </NewDataSet>
    </xsl:template>
</xsl:stylesheet>