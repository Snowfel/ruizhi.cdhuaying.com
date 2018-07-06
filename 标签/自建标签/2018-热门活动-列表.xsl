<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="hits" />
    <xsl:param name="eliteLevel" />
    <xsl:param name="nodeid" />
    <xsl:param name="isnew" />
    <xsl:param name="dataid" />
    <xsl:output method="html" />
    <xsl:template match="/NewDataSet">
        <xsl:choose>
            <xsl:when test="count(Table) = 0">
            </xsl:when>
            <xsl:otherwise>
                {PE.DataSource id="InfoList_<xsl:value-of select="$dataid"/>" datasource="2018-热门活动-列表-循环分页" nodeid="<xsl:value-of select="$nodeid"/>"  urlpage="true" page="true"  pagesize="<xsl:value-of select="$outputQty"/>"  titleLength="<xsl:value-of select="$titleLength"/>" linkOpenType="<xsl:value-of select="$linkOpenType"/>" isnew="<xsl:value-of select="$isnew"/>" xslt="true" /}
                {PE.Repeat id="InfoList_<xsl:value-of select="$dataid"/>" loop="1000"}
                {PE.field id="InfoList_<xsl:value-of select="$dataid"/>" fieldname="InfoPath" /}
                {/PE.Repeat}
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>