<?xml version="1.0" encoding="utf-8"?>
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
  <xsl:output method="html" />
  <xsl:param name="outputQty"/>
  <xsl:param name="nodeid"/>
  <xsl:param name="titleLength"/>
  <xsl:param name="linkOpenType" />
  <xsl:template match="/NewDataSet">
    <xsl:choose>
      <xsl:when test="count(Table) = 0">
        <xsl:value-of select="$nodeid"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:for-each select="Table">
          {PE.DataSource id="InfoList<xsl:value-of select="NodeID"/>" datasource="2018-演员照片-图片循环-信息" nodeid="<xsl:value-of select="$nodeid"/>" titleLength="<xsl:value-of select="$titleLength"/>" xslt="true" /}
          {PE.Repeat id="InfoList<xsl:value-of select="$nodeid"/>" loop="1000"}
          <xsl:if test="position() = 1">1</xsl:if>
          <div class="col">
            {PE.Field id="InfoList<xsl:value-of select="NodeID"/>" fieldname="backPicUrl" /}
            <div class="u-title">{PE.Field id="InfoList<xsl:value-of select="NodeID"/>" fieldname="Title" /}</div>
            <div class="u-actor">{PE.Field id="InfoList<xsl:value-of select="NodeID"/>" fieldname="Intro" /}</div>
          </div>
          <xsl:if test="position() = 6">6</xsl:if>
          {/PE.Repeat}

        </xsl:for-each>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
</xsl:transform>