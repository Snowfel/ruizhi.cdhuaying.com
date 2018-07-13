<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="hits" />
    <xsl:param name="eliteLevel" />
    <xsl:param name="nodeid" />
    <xsl:param name="tagid" />
    <xsl:output method="html" />
    <xsl:template match="/NewDataSet">
        <xsl:choose>
            <xsl:when test="count(Table) = 0">
            </xsl:when>
            <xsl:otherwise>
                {PE.Label id="2018-广告-二级页面-顶部横幅" outputQty="1" NodeID="<xsl:value-of select="$nodeid"/>" TagID="<xsl:value-of select="$tagid"/>" /}
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>