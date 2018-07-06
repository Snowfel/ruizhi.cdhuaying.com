<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="nodeid" />
    <xsl:param name="dataid" />
    <xsl:output method="html" />
    <xsl:template match="/NewDataSet">
        <xsl:choose>
            <xsl:when test="count(Table) = 0">
            </xsl:when>
            <xsl:otherwise>
                {PE.DataSource id="InfoList_<xsl:value-of select="$dataid"/>" datasource="2018-精彩视频-数据源" nodeid="<xsl:value-of select="$nodeid"/>"  outputQty="<xsl:value-of select="$outputQty"/>"  xslt="true" /}
                {PE.Repeat id="InfoList_<xsl:value-of select="$dataid"/>" loop="1000"}
                {PE.field id="InfoList_<xsl:value-of select="$dataid"/>" fieldname="InfoPath" /}
                {/PE.Repeat}
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>