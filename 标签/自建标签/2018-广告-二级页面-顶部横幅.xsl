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
                        <xsl:attribute name="class">g-sub-banner-1</xsl:attribute>
                        <xsl:attribute name="style">background: url(<xsl:value-of select="pe:UpLoadDir()"/><xsl:value-of select="DefaultPicUrl"/>) center center no-repeat;
                        </xsl:attribute>
                        <div>
                            <xsl:attribute name="class">container pt-5</xsl:attribute>
                            {pe.label id="2018-全局-顶部预约表单" /}
                        </div>
                    </div>
                </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>