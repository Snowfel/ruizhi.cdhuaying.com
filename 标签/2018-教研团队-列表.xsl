<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:param name="outputQty" />
    <xsl:param name="titleLength" />
    <xsl:param name="linkOpenType" />
    <xsl:param name="hits" />
    <xsl:param name="eliteLevel" />
    <xsl:param name="nodeid" />
    <xsl:output method="html" />
    <xsl:template match="/NewDataSet">
        <xsl:choose>
            <xsl:when test="count(Table) = 0">
            </xsl:when>
            <xsl:otherwise>
                {PE.DataSource id="InfoList" datasource="2018-教研团队-循环分页" nodeid="<xsl:value-of select="$nodeid"/>"  urlpage="true" page="true"  pagesize="<xsl:value-of select="$outputQty"/>"  titleLength="<xsl:value-of select="$titleLength"/>" linkOpenType="<xsl:value-of select="$linkOpenType"/>" xslt="true" /}
                {PE.Repeat id="InfoList" loop="1000"}
                <li>
                    {PE.field id="InfoList" fieldname="InfoPath" /}
                </li>
                {/PE.Repeat}
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>