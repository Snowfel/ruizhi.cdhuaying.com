<?xml version="1.0" encoding="utf-8"?>
<xsl:transform version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:pe="labelproc" exclude-result-prefixes="pe">
    <xsl:output method="xml" />
    <xsl:param name="itemId"/>
    <xsl:template match="/">
        <root>
            <!--FieldTipsStart-->
            <GeneralID>
                <xsl:value-of select="/NewDataSet/Table/GeneralID"/>
            </GeneralID>
            <NodeID>
                <xsl:value-of select="/NewDataSet/Table/NodeID"/>
            </NodeID>
            <ModelID>
                <xsl:value-of select="/NewDataSet/Table/ModelID"/>
            </ModelID>
            <Title>
                <xsl:value-of select="pe:EncodeText(/NewDataSet/Table/Title,'htmlencode')"/>
            </Title>
            <TitleIntact>
                <xsl:choose>
                    <xsl:when test="/NewDataSet/Table/TitleIntact !=''">
                        <xsl:value-of select="pe:EncodeText(/NewDataSet/Table/TitleIntact,'htmlencode')"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="pe:EncodeText(/NewDataSet/Table/Title,'htmlencode')"/>
                    </xsl:otherwise>
                </xsl:choose>
            </TitleIntact>
            <age>
                <xsl:value-of select="/NewDataSet/Table/age"/>
            </age>
            <feature>
                <xsl:value-of select="pe:RemoveHtml(/NewDataSet/Table/age)"/>
            </feature>
            <content>
                <xsl:value-of select="pe:RemoveHtml(/NewDataSet/Table/content)"/>
            </content>
            <Hits>
                &lt;script language="JavaScript" type="text/JavaScript" src="<xsl:value-of select="pe:InstallDir()" />Common/GetHits.aspx?id=<xsl:value-of select="/NewDataSet/Table/GeneralID"/>"&gt;&lt;/script&gt;
            </Hits>
            <!--FieldTipsEnd-->
        </root>
    </xsl:template>
</xsl:transform>