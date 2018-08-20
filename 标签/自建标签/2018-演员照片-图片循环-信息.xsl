<?xml version="1.0" encoding="utf-8"?>
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
  <xsl:param name="titleLength" />
  <xsl:param name="linkOpenType" />
  <xsl:output method="xml" />
  <xsl:template match="/">
    <NewDataSet>
      <xsl:for-each select="NewDataSet/Table">
        <Table>
          <GeneralID>
            <xsl:value-of select="GeneralID"/>
          </GeneralID>
          <NodeID>
            <xsl:value-of select="NodeID"/>
          </NodeID>
          <Title>
            <xsl:value-of select="pe:CutText(pe:RemoveHtml(Title),$titleLength,'…')" />
          </Title>
          <Intro>
            <xsl:value-of select="pe:CutText(pe:RemoveHtml(Intro),$titleLength,'…')" />
          </Intro>
          <DefaultPicUrl>
            <xsl:choose>
              <xsl:when test="DefaultPicUrl !=''">
                <xsl:if test="pe:IsStartWithhttp(DefaultPicUrl)='false'">
                  <xsl:value-of select="pe:UpLoadDir()"/>
                </xsl:if>
                <xsl:value-of select="DefaultPicUrl"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:value-of select="pe:UpLoadDir()"/>nopic.gif
              </xsl:otherwise>
            </xsl:choose>
          </DefaultPicUrl>
          <backPicUrl>
            &lt;div class="u-img" style="background: url(
            <xsl:choose>
              <xsl:when test="DefaultPicUrl !=''">
                <xsl:if test="pe:IsStartWithhttp(DefaultPicUrl)='false'">
                  <xsl:value-of select="pe:UpLoadDir()"/>
                </xsl:if>
                <xsl:value-of select="DefaultPicUrl"/>
              </xsl:when>
              <xsl:otherwise>
                <xsl:value-of select="pe:UpLoadDir()"/>nopic.gif
              </xsl:otherwise>
            </xsl:choose>
            ) no-repeat center center;"&gt;
            &lt;/div&gt;
          </backPicUrl>
        </Table>
      </xsl:for-each>
    </NewDataSet>
  </xsl:template>
</xsl:transform>