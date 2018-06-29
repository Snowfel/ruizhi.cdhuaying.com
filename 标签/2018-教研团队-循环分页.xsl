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
                        &lt;a href="<xsl:value-of disable-output-escaping="yes" select="pe:GetInfoPath(NodeID,GeneralID,InputTime,PinyinTitle,HtmlPageName)"/>" title="<xsl:value-of select="Teacher_EnName"/>" target="_blank" &gt;
                        &lt;img src="<xsl:value-of select="pe:UpLoadDir()"/>
                        <xsl:value-of select="DefaultPicUrl"/>" alt="<xsl:value-of select="Teacher_EnName"/>" border="0" /&gt;
                        &lt;/a&gt;
                        &lt;a href="<xsl:value-of disable-output-escaping="yes" select="pe:GetInfoPath(NodeID,GeneralID,InputTime,PinyinTitle,HtmlPageName)"/>" target="_blank" class="teaname" &gt;&lt;span&gt;<xsl:value-of select="Teacher_EnName" />&lt;/span&gt;&lt;/a&gt;
                        &lt;br /&gt;
                        &lt;a href="<xsl:value-of disable-output-escaping="yes" select="pe:GetInfoPath(NodeID,GeneralID,InputTime,PinyinTitle,HtmlPageName)"/>" target="_blank" class="teaintro" &gt;&lt;span&gt;教学专长：<xsl:value-of select="Intro" />&lt;/span&gt;&lt;/a&gt;
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