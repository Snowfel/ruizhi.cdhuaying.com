<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="NodeID"/>
    <xsl:param name="TagID"/>
    <xsl:output method="html" version="1.0" encoding="utf-8" indent="no"/>
    <xsl:template match="/">
        <xsl:choose>
            <xsl:when test="NewDataSet/Table">
                <xsl:for-each select="NewDataSet/Table">
                    <div>
                        <xsl:attribute name="class">col u-content</xsl:attribute>
                        <div>
                            <xsl:attribute name="class">u-img</xsl:attribute>
                            <xsl:attribute name="style">background: url(<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>) #0a7fa4 center 0 no-repeat;</xsl:attribute>
                            <a>
                                <xsl:attribute name="href">#modal-video-show</xsl:attribute>
                                <xsl:attribute name="data-url"><xsl:value-of select="linkurl"/></xsl:attribute>
                                <xsl:attribute name="data-title"><xsl:value-of select="Title"/></xsl:attribute>
                                <xsl:attribute name="class">d-block</xsl:attribute>
                            </a>
                        </div>
                        <div>
                            <xsl:attribute name="class">u-info</xsl:attribute>
                            <div>
                                <xsl:attribute name="class">u-title</xsl:attribute>
                                <a>
                                    <xsl:attribute name="href">#modal-video-show</xsl:attribute>
                                    <xsl:attribute name="data-url"><xsl:value-of select="linkurl"/></xsl:attribute>
                                    <xsl:attribute name="data-title"><xsl:value-of select="Title"/></xsl:attribute>
                                    <xsl:value-of select="Title"/>
                                </a>
                            </div>
                            <div>
                                <xsl:attribute name="class">u-intro</xsl:attribute>
                                <a>
                                    <xsl:attribute name="href">#modal-video-show</xsl:attribute>
                                    <xsl:attribute name="data-url"><xsl:value-of select="linkurl"/></xsl:attribute>
                                    <xsl:attribute name="data-title"><xsl:value-of select="Title"/></xsl:attribute>
                                    <xsl:value-of select="pe:RemoveHtml(intro)"/>
                                </a>
                            </div>
                        </div>
                    </div>
                </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>