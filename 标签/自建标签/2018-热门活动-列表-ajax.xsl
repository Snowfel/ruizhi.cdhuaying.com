<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ms="urn:schemas-microsoft-com:xslt" xmlns:lewi="http://www.powereasy.net" xmlns:pe="labelproc" exclude-result-prefixes="pe ms lewi">
    <xsl:output method="html" version="1.0" encoding="utf-8" indent="no"/>
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="eliteLevel" />
    <xsl:param name="hits" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="nodeid" />
    <xsl:param name="isnew" />
    <xsl:template match="/">
        <xsl:choose>
            <xsl:when test="NewDataSet/Table">
                <xsl:for-each select="NewDataSet/Table">

                    <div>
                        <xsl:attribute name="class">col-sm-4</xsl:attribute>
                        <div>
                            <xsl:attribute name="class">card</xsl:attribute>
                            <div>
                                <xsl:attribute name="class">card-body</xsl:attribute>
                                <img>
                                    <xsl:attribute name="class">card-img-top</xsl:attribute>
                                    <xsl:attribute name="src"><xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/></xsl:attribute>
                                    <xsl:attribute name="alt"><xsl:value-of select="Title" /></xsl:attribute>
                                </img>
                                <h3><xsl:attribute name="class">card-title</xsl:attribute><xsl:value-of select="pe:CutText(Title,31,'...')" /></h3>
                                <p><xsl:attribute name="class">card-text</xsl:attribute><xsl:value-of select="pe:CutText(pe:RemoveHtml(intro),$titleLength,'…')" disable-output-escaping="yes" /></p>
                                <a>
                                <xsl:attribute name="href"><xsl:value-of select="RedirectLink" /></xsl:attribute>
                                <xsl:attribute name="target">_blank</xsl:attribute>
                                <xsl:attribute name="class">btn btn-primary float-right d-inline-block px-4</xsl:attribute>
                                了解详情
                                </a>
                            </div>
                        </div>
                    </div>
                </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
                <li style="color:red">还没有任何项目！</li>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>